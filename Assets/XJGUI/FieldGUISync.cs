using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using XJGUI;

public class FieldGUISync : NetworkBehaviour
{
    // NOTE:
    // There are 2 implement pattern to sync. The one is using Message, another one is using SyncList.
    // Message pattern is not so bad, but it needs to define custom message type with MsgType.Highest.
    // MsgType should be unique. So when the user use another custom message type in their project,
    // user have to solve the problem about MsgType conflict. That is nonsense.
    // (By the way, SyncList use msg inside it!)

    // CAUTION:
    // "SyncList not Initialized" error is not depend on connection type such as Server or Client.
    // Even if Client access some SyncList, it is not occurs.

    #region Field

    protected List<FieldGUI> fieldGUIs = new List<FieldGUI>();
    protected SyncListString syncList = new SyncListString();

    #endregion Field

    #region Method

    // CAUTION:
    // In Editor, NetworkBehaviour.Awake/OnEnable is called before connect network.
    // However, in build application, Awake/OnEnable is called when connect network.
    // (Checked in Unity 2017.02)

    protected void Awake()
    {
        this.syncList.Callback += OnSyncListUpdated;
    }

    protected void OnEnable()
    {
        for (int i = 0; i < this.fieldGUIs.Count; i++)
        {
            for (int j = 0; j < this.fieldGUIs[i].GUIs.Count; j++)
            {
                this.syncList.Add("");
            }
        }
    }

    protected void Update()
    {
        if (this.fieldGUIs.Count == 0)
        {
            return;
        }

        int fieldGUICount = 0;
        int syncListIndex = 0;

        for (int i = 0; i < this.fieldGUIs.Count; i++)
        {
            fieldGUICount = this.fieldGUIs[i].GUIs.Count;

            for (int j = 0; j < this.fieldGUIs[i].GUIs.Count; j++)
            {
                if (!this.fieldGUIs[i].GUIs[j].Sync)
                {
                    continue;
                }

                this.fieldGUIs[i].GUIs[j].SetTitleColor(GetTitleColor());

                // NOTE:
                // If use "isClient", Host is also ignored.

                if (!this.isServer)
                {
                    continue;
                }

                // NOTE:
                // There is no reason to implement with logic which use "Dirty".
                // Because "UpdateInfo" is struct.

                string syncValue = this.fieldGUIs[i].GUIs[j].GetSyncValue();

                if (syncValue == null || this.fieldGUIs[i].GUIs[j].Unsupported)
                {
                    continue;
                }

                this.syncList[syncListIndex + j] = syncValue;
            }

            syncListIndex += fieldGUICount;
        }
    }

    protected void OnDisable()
    {
        for (int i = 0; i < this.fieldGUIs.Count; i++)
        {
            for (int j = 0; j < this.fieldGUIs[i].GUIs.Count; j++)
            {
                this.fieldGUIs[i].GUIs[j].SetTitleColor(null);
            }
        }

        this.syncList.Clear();
    }

    public void Add(FieldGUI fieldGUI)
    {
        if (this.fieldGUIs.Contains(fieldGUI))
        {
            return;
        }

        this.fieldGUIs.Add(fieldGUI);

        // CAUTION:
        // If already start as Server, add new data to this.syncList.
        // When network not start, base.isServer always returns false.
        // So in such case, initialize syncList in OnEnable function.
        // It called when start as Client or Server(Host).
        // 
        // If not check this, "SyncList not Initialized" will occurs at "this.syncList.Add("")".
        // This error is not appear in Editor, only in build application.

        if (!base.isServer)
        {
            return;
        }

        for (int i = 0; i < fieldGUI.GUIs.Count; i++)
        {
            this.syncList.Add("");
        }
    }

    private void OnSyncListUpdated(SyncListString.Operation op, int syncListIndex)
    {
        if (op != SyncListString.Operation.OP_SET)
        {
            return;
        }

        int fieldGUIsIndex = 0;
        int fieldCount = 0;

        for (fieldGUIsIndex = 0; fieldGUIsIndex < this.fieldGUIs.Count; fieldGUIsIndex++)
        {
            fieldCount += fieldGUIs[fieldGUIsIndex].GUIs.Count;

            if (syncListIndex < fieldCount)
            {
                break;
            }
        }

        int fieldIndex = syncListIndex - (fieldCount - this.fieldGUIs[fieldGUIsIndex].GUIs.Count);

        this.fieldGUIs[fieldGUIsIndex].GUIs[fieldIndex].SetSyncValue(this.syncList[syncListIndex]);
    }

    private Color? GetTitleColor()
    {
        if (NetworkServer.active)
        {
            return XJGUILayout.DefaultSyncColorServer;
        }
        else if (NetworkClient.active && NetworkManager.singleton.IsClientConnected())
        {
            return XJGUILayout.DefaultSyncColorClient;
        }

        return null;
    }

    #endregion Method
}