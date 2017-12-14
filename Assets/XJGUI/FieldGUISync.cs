using System;
using UnityEngine;
using UnityEngine.Networking;
using XJGUI;

public class FieldGUISync : NetworkBehaviour
{
    #region Class

    protected struct UpdateValue
    {
        public int     index;
        public int     valueInt;
        public float   valueFloat;
        public bool    valueBool;
        public string  valueString;
        public Vector2 valueVector2;
        public Vector3 valueVector3;
        public Vector4 valueVector4;
    }

    // NOTE:
    // Following SyncList define is illegal. Unity will notify the error.
    // We have to define a inherit class.
    // protected SyncListStruct<UpdateValue> syncList = new SyncListStruct<UpdateValue>();

    protected class SyncListUpdateValue : SyncListStruct<UpdateValue> { }

    #endregion Class

    #region Field

    public FieldGUI fieldGUI;

    protected SyncListUpdateValue syncList = new SyncListUpdateValue();

    #endregion Field

    #region Method

    public void Start()
    {
        for (int i = 0; i < this.fieldGUI.GUIs.Count; i++)
        {
            Type type = this.fieldGUI.GUIs[i].Type;
            this.syncList.Add(new UpdateValue());
        }

        this.syncList.Callback += OnSyncListUpdated;
    }

    public void Update()
    {
        for (int i = 0; i < this.fieldGUI.GUIs.Count; i++)
        {
            // NOTE:
            // "UpdateIndex" shows the GUI is updated or not. 
            // When updated, the value shows index of the value list, and when not, the value shows less than 0.

            int updateIndex = this.fieldGUI.GUIs[i].UpdateIndex;

            if (updateIndex < 0)
            {
                continue;
            }

            Type type = this.fieldGUI.GUIs[i].Type;
            object value = this.fieldGUI.GUIs[i].GetValue();

                if (type == typeof(int))     { this.syncList[i] = new UpdateValue() { valueInt     = (int)    value, index = updateIndex }; }
           else if (type == typeof(float))   { this.syncList[i] = new UpdateValue() { valueFloat   = (float)  value, index = updateIndex }; }
           else if (type == typeof(bool))    { this.syncList[i] = new UpdateValue() { valueBool    = (bool)   value, index = updateIndex }; }
           else if (type == typeof(string))  { this.syncList[i] = new UpdateValue() { valueString  = (string) value, index = updateIndex }; }
           else if (type == typeof(Vector2)) { this.syncList[i] = new UpdateValue() { valueVector2 = (Vector2)value, index = updateIndex }; }
           else if (type == typeof(Vector3)) { this.syncList[i] = new UpdateValue() { valueVector3 = (Vector3)value, index = updateIndex }; }
           else if (type == typeof(Vector4)) { this.syncList[i] = new UpdateValue() { valueVector4 = (Vector4)value, index = updateIndex }; }
        }
    }

    private void OnSyncListUpdated(SyncListStruct<UpdateValue>.Operation op, int index)
    {
        if (op != SyncList<UpdateValue>.Operation.OP_DIRTY)
        {
            return;
        }

        object value = 0;
        int valueIndex = this.syncList[index].index;
        Type type = this.fieldGUI.GUIs[index].Type;

             if (type == typeof(int))     { value = this.syncList[index].valueInt;     }
        else if (type == typeof(float))   { value = this.syncList[index].valueFloat;   }
        else if (type == typeof(bool))    { value = this.syncList[index].valueBool;    }
        else if (type == typeof(string))  { value = this.syncList[index].valueString;  }
        else if (type == typeof(Vector2)) { value = this.syncList[index].valueVector2; }
        else if (type == typeof(Vector3)) { value = this.syncList[index].valueVector3; }
        else if (type == typeof(Vector4)) { value = this.syncList[index].valueVector4; }

        this.fieldGUI.GUIs[index].SetValue(value, valueIndex);
    }

    #endregion Method
}