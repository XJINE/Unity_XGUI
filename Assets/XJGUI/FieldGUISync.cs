using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using XJGUI;

public class FieldGUISync : NetworkBehaviour
{
    // NOTE:
    // There are 2 implement pattern to sync, the one is using Message, another one is using SyncList.
    // Message pattern is not so bad, but it needs to define custom message type with MsgType.Highest.
    // MsgType must be unique. So when the user use another custom message type in their project,
    // user have to solve the problem about MsgType conflict. That is nonsense.

    #region Class

    protected struct UpdateInfo
    {
        public int index;
        public string value;

        public UpdateInfo(int index, string value)
        {
            this.index = index;
            this.value = value;
        }
    }

    // NOTE:
    // Following SyncList define is illegal. Unity will notify the error.
    // We have to define a inherit class.
    // protected SyncListStruct<T> syncList = new SyncListStruct<T>();

    protected class SyncListUpdateInfo : SyncListStruct<UpdateInfo> { }

    #endregion Class

    #region Field

    protected List<FieldGUI> fieldGUIs = new List<FieldGUI>();
    protected SyncListUpdateInfo syncList = new SyncListUpdateInfo();

    #endregion Field

    #region Method

    protected void Awake()
    {
        this.syncList.Callback += OnSyncListUpdated;
    }

    public void Update()
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
                // "index" shows the GUI is updated or not.
                // When updated, the value shows 0 or index of the updated value,
                // and when not, the value shows less than 0.

                // NOTE:
                // There is no reason to implement with logic which use "Dirty".
                // Because "UpdateInfo" is struct.

                int index;
                string value;

                this.fieldGUIs[i].GUIs[j].GetSyncValue(out index, out value);

                if (index < 0 || this.fieldGUIs[i].GUIs[j].Unsupported)
                {
                    continue;
                }

                this.syncList[syncListIndex + j] = new UpdateInfo(index, value);
            }

            syncListIndex += fieldGUICount;
        }
    }

    protected void OnDisable()
    {
        // NOTE:
        // Called when NetworkServer/Client is not active.

        for (int i = 0; i < this.fieldGUIs.Count; i++)
        {
            for (int j = 0; j < this.fieldGUIs[i].GUIs.Count; j++)
            {
                this.fieldGUIs[i].GUIs[j].SetTitleColor(null);
            }
        }
    }

    public void Add(FieldGUI fieldGUI)
    {
        this.fieldGUIs.Add(fieldGUI);

        for (int i = 0; i < fieldGUI.GUIs.Count; i++)
        {
            this.syncList.Add(new UpdateInfo());
        }
    }

    private void OnSyncListUpdated(SyncListStruct<UpdateInfo>.Operation op, int syncListIndex)
    {
        if (op != SyncList<UpdateInfo>.Operation.OP_SET)
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

        this.fieldGUIs[fieldGUIsIndex].GUIs[fieldIndex]
            .SetSyncValue(this.syncList[syncListIndex].index, this.syncList[syncListIndex].value);
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