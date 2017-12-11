using UnityEngine;
using UnityEngine.Networking;


// NOTE:
// SyncVar が Field.SetValue に対応するのが一番良い。
// 
// Message でやるメリット・デメリット
// - FieldGUI が NetworkBehaviour でなくて良くなる。
// - Receive 時のフックが可能。
// - SyncList などの用意が不要かも。
// SyncList でやるメリット・デメリット
// - 特に送受信を考慮しなくて良くなる。
// - 
// - FieldGUI が NetworkBehaviour である必要があるかも。
// -- Sync する内容だけ、SyncList で共有する、という手はあるが。

public class Sync : NetworkBehaviour
{
    #region Class

    public class ValueUpdateMessageType
    {
        public const short ValueUpdate = MsgType.Highest + 1;
    }

    public class ValueUpdateMessage : MessageBase
    {
        public object value;
        public int index;
    }

    #endregion Class

    #region Field

    protected int reliableChannel = 1;

    #endregion Field

    protected void SetRealiableChannel()
    {
        this.reliableChannel = NetworkManager.singleton.channels.FindIndex((channel) =>
        {
            return channel == QosType.Reliable;
        });

        if (this.reliableChannel == -1)
        {
            NetworkManager.singleton.channels.Add(QosType.Reliable);
            this.reliableChannel = NetworkManager.singleton.channels.Count - 1;
        }
    }

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
        //fieldGUIs[message.index]
        //fieldInfos[message.fieldInfoIndex].SetValue(base.data, message.value);
    }

    public struct UpdateValue<T>
    {
        int index;
        public T value;
    }

    public SyncListStruct<UpdateValue<T>> syncList;

}