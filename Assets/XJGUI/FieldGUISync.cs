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

    protected FieldGUI fieldGUI;
    protected SyncListUpdateInfo syncList = new SyncListUpdateInfo();

    #endregion Field

    #region Method

    public void SetFieldGUI(FieldGUI fieldGUI)
    {
        this.fieldGUI = fieldGUI;

        for (int i = 0; i < this.fieldGUI.GUIs.Count; i++)
        {
            //if(this.fieldGUI.GUIs[i])
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
            // "index" shows the GUI is updated or not. 
            // When updated, the value shows index of the value list, and when not, the value shows less than 0.

            // NOTE:
            // There is no reason to implement with logic which use "Dirty".
            // Because "UpdateInfo" is struct.

            int index;
            string value;

            this.fieldGUI.GUIs[i].GetSyncValue(out index, out value);

            if (index < 0 || this.fieldGUI.GUIs[i].IsUnsupported)
            {
                continue;
            }

            this.syncList[i] = new UpdateInfo(index, value);
        }
    }

    private void OnSyncListUpdated(SyncListStruct<UpdateInfo>.Operation op, int i)
    {
        if (op != SyncList<UpdateInfo>.Operation.OP_SET)
        {
            return;
        }

        this.fieldGUI.GUIs[i].SetSyncValue(this.syncList[i].index, this.syncList[i].value);
    }

    #endregion Method
}