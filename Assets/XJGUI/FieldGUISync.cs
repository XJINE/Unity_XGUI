using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using XJGUI;

public class FieldGUISync : NetworkBehaviour
{
    #region Class

    protected struct ValueUpdate
    {
        public int     valueIndex;

        public int     valueInt;
        public float   valueFloat;
        public bool    valueBool;
        public string  valueString;
        public Vector2 valueVector2;
        public Vector3 valueVector3;
        public Vector4 valueVector4;
    }

    #endregion Class

    #region Field

    public FieldGUI fieldGUI;

    protected SyncListStruct<ValueUpdate> syncList  = new SyncListStruct<ValueUpdate>();

    #endregion Field

    #region Method

    public void Start()
    {
        // Initialize.

        for (int i = 0; i < this.fieldGUI.GUIs.Count; i++)
        {
            Type type = this.fieldGUI.GUIs[i].Type;

            if (type == typeof(int))
            {
                this.syncList.Add(new ValueUpdate() { valueIndex = 0, valueInt = (int)this.fieldGUI.GUIs[i].GetValue(), });
            }
        }

        // Register Handler.

        this.syncList.Callback += OnSyncListUpdated;
    }

    public void Update()
    {
        for (int i = 0; i < this.fieldGUI.GUIs.Count; i++)
        {
            if (!this.fieldGUI.GUIs[i].IsUpdate)
            {
                continue;
            }

            Type type = this.fieldGUI.GUIs[i].Type;
            object value = this.fieldGUI.GUIs[i].GetValue();

            if (type == typeof(int))     { this.syncList[i] = new ValueUpdate() { valueInt     = (int)    value }; }
            if (type == typeof(float))   { this.syncList[i] = new ValueUpdate() { valueFloat   = (float)  value }; }
            if (type == typeof(bool))    { this.syncList[i] = new ValueUpdate() { valueBool    = (bool)   value }; }
            if (type == typeof(string))  { this.syncList[i] = new ValueUpdate() { valueString  = (string) value }; }
            if (type == typeof(Vector2)) { this.syncList[i] = new ValueUpdate() { valueVector2 = (Vector2)value }; }
            if (type == typeof(Vector3)) { this.syncList[i] = new ValueUpdate() { valueVector3 = (Vector3)value }; }
            if (type == typeof(Vector4)) { this.syncList[i] = new ValueUpdate() { valueVector4 = (Vector4)value }; }
        }
    }

    private void OnSyncListUpdated(SyncListStruct<ValueUpdate>.Operation op, int index)
    {
        object value = 0;
        //bool   isList = false;

        Type type = this.fieldGUI.GUIs[index].Type;
        //isList = type is IList;

             if (type == typeof(int))     { value = this.syncList[index].valueInt;     }
        else if (type == typeof(float))   { value = this.syncList[index].valueFloat;   }
        else if (type == typeof(bool))    { value = this.syncList[index].valueBool;    }
        else if (type == typeof(string))  { value = this.syncList[index].valueString;  }
        else if (type == typeof(Vector2)) { value = this.syncList[index].valueVector2; }
        else if (type == typeof(Vector3)) { value = this.syncList[index].valueVector3; }
        else if (type == typeof(Vector4)) { value = this.syncList[index].valueVector4; }

        this.fieldGUI.GUIs[index].SetValue(value);
    }

    #endregion Method
}