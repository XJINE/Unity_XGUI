using UnityEngine.Networking;
using XJGUI;

public class Sync : NetworkBehaviour
{
    #region Class

    public class ValueUpdateMessageType
    {
        public const short ValueUpdate = MsgType.Highest + 1;
    }

    public class ValueUpdateMessage : MessageBase
    {
        public int index;
        public object value;
        public int valueIndex;
    }

    #endregion Class

    #region Field

    public FieldGUI fieldGUI;

    protected int reliableChannel = 1;

    #endregion Field

    public void SendMessage(object value)
    {
        ValueUpdateMessage message = new ValueUpdateMessage()
        {
            index = 0,
            value = value
        };

        NetworkServer.SendByChannelToAll(ValueUpdateMessageType.ValueUpdate, message, this.reliableChannel);
    }

    public void ReceiveMessage(ValueUpdateMessage message)
    {
        this.fieldGUI.FieldGUIs[message.index].SetValue(message.value);
    }
}