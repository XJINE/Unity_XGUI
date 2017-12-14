using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using XJGUI;

public class FieldGUISync : NetworkBehaviour
{
    #region Class

    protected struct UpdateInfo
    {
        public int     updateIndex;
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
    // protected SyncListStruct<T> syncList = new SyncListStruct<T>();

    protected class SyncListUpdateInfo : SyncListStruct<UpdateInfo> { }

    #endregion Class

    #region Field

    protected FieldGUI fieldGUI;
    protected SyncListUpdateInfo syncList = new SyncListUpdateInfo();

    #endregion Field

    #region Method

    public void SetFieldGUI(FieldGUI fieldGUI)
    {
        this.fieldGUI = fieldGUI;

        for (int i = 0; i < this.fieldGUI.GUIs.Count; i++)
        {
            Type type = this.fieldGUI.GUIs[i].Type;
            this.syncList.Add(new UpdateInfo());
        }

        this.syncList.Callback += OnSyncListUpdated;
    }

    [ServerCallback]
    public void Update()
    {
        if (this.fieldGUI == null)
        {
            return;
        }

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
            bool isIListType = this.fieldGUI.GUIs[i].IsIListType;

            UpdateInfo info = new UpdateInfo() { updateIndex = updateIndex };

                 if (type == typeof(int))     { info.valueInt     = (int)    (isIListType ? ((IList<int>)value)    [updateIndex] : value); }
            else if (type == typeof(float))   { info.valueFloat   = (float)  (isIListType ? ((IList<float>)value)  [updateIndex] : value); }
            else if (type == typeof(bool))    { info.valueBool    = (bool)   (isIListType ? ((IList<bool>)value)   [updateIndex] : value); }
            else if (type == typeof(string))  { info.valueString  = (string) (isIListType ? ((IList<string>)value) [updateIndex] : value); }
            else if (type == typeof(Vector2)) { info.valueVector2 = (Vector2)(isIListType ? ((IList<Vector2>)value)[updateIndex] : value); }
            else if (type == typeof(Vector3)) { info.valueVector3 = (Vector3)(isIListType ? ((IList<Vector3>)value)[updateIndex] : value); }
            else if (type == typeof(Vector4)) { info.valueVector4 = (Vector4)(isIListType ? ((IList<Vector4>)value)[updateIndex] : value); }

            this.syncList[i] = info;
            //this.syncList.Dirty(i);
        }
    }

    private void OnSyncListUpdated(SyncListStruct<UpdateInfo>.Operation op, int index)
    {
        if (op != SyncList<UpdateInfo>.Operation.OP_SET)
        {
            return;
        }

        object value = 0;
        int valueIndex = this.syncList[index].updateIndex;
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