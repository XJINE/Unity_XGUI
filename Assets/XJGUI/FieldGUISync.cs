﻿using System.Collections.Generic;
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

    #region Field

    protected List<FieldGUI> fieldGUIs = new List<FieldGUI>();
    protected SyncListString syncList = new SyncListString();

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
    }

    public void Add(FieldGUI fieldGUI)
    {
        this.fieldGUIs.Add(fieldGUI);

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