using System;
using UnityEngine;
using UnityEngine.Networking;
using XJGUI;

public class FieldGUISyncer : NetworkBehaviour
{
    #region Class

    // NOTE:
    // MessageBase can't define object type in field.
    // Only 'Basic' type is allowed.

    public class ValueUpdateMessageType
    {
        public const short ValueUpdateInt     = MsgType.Highest + 1;
        public const short ValueUpdateFloat   = MsgType.Highest + 2;
        public const short ValueUpdateBool    = MsgType.Highest + 3;
        public const short ValueUpdateString  = MsgType.Highest + 4;
        public const short ValueUpdateVector2 = MsgType.Highest + 5;
        public const short ValueUpdateVector3 = MsgType.Highest + 6;
        public const short ValueUpdateVector4 = MsgType.Highest + 7;
    }

    public class ValueUpdateMessage : MessageBase
    {
        public int index;
        public int valueIndex;
    }

    // NOTE:
    // We can't use Generics <T> because of the string.
    // Unity wil shows caution about MessageBase class definition.

    public class ValueUpdateMessageInt     : ValueUpdateMessage { public int     value; }
    public class ValueUpdateMessageFloat   : ValueUpdateMessage { public float   value; }
    public class ValueUpdateMessageBool    : ValueUpdateMessage { public bool    value; }
    public class ValueUpdateMessageString  : ValueUpdateMessage { public string  value; }
    public class ValueUpdateMessageVector2 : ValueUpdateMessage { public Vector2 value; }
    public class ValueUpdateMessageVector3 : ValueUpdateMessage { public Vector3 value; }
    public class ValueUpdateMessageVector4 : ValueUpdateMessage { public Vector4 value; }

    #endregion Class

    #region Field

    public FieldGUI fieldGUI;

    protected int reliableChannel = 1;

    SyncListInt intlist = new SyncListInt();

    #endregion Field

    #region Method

    void Start()
    {
        if (base.isClient)
        {
            NetworkManager.singleton.client.RegisterHandler
                (ValueUpdateMessageType.ValueUpdateInt, ReceiveValueUpdateMessageInt);
            NetworkManager.singleton.client.RegisterHandler
                (ValueUpdateMessageType.ValueUpdateFloat, ReceiveValueUpdateMessageFloat);
            NetworkManager.singleton.client.RegisterHandler
                (ValueUpdateMessageType.ValueUpdateBool, ReceiveValueUpdateMessageBool);
            NetworkManager.singleton.client.RegisterHandler
                (ValueUpdateMessageType.ValueUpdateString, ReceiveValueUpdateMessageString);
            NetworkManager.singleton.client.RegisterHandler
                (ValueUpdateMessageType.ValueUpdateVector2, ReceiveValueUpdateMessageVector2);
            NetworkManager.singleton.client.RegisterHandler
                (ValueUpdateMessageType.ValueUpdateVector3, ReceiveValueUpdateMessageVector3);
            NetworkManager.singleton.client.RegisterHandler
                (ValueUpdateMessageType.ValueUpdateVector4, ReceiveValueUpdateMessageVector4);
        }
    }

    public void SendMessage(object value)
    {
        for (int i = 0; i < this.fieldGUI.GUIs.Count; i++)
        {
            if (this.fieldGUI.GUIs[i].IsUpdate)
            {
                ValueUpdateMessageInt message = new ValueUpdateMessageInt();
                message.index = i;
                //message.value = this.fieldGUI.FieldGUIs[i].GetValue();

                NetworkServer.SendByChannelToAll
                    (ValueUpdateMessageType.ValueUpdateInt, message, this.reliableChannel);
            }
        }
    }

    public void ReceiveValueUpdateMessageInt(NetworkMessage message)
    {
        ValueUpdateMessageInt valueUpdateMessage = message.ReadMessage<ValueUpdateMessageInt>();
        this.fieldGUI.GUIs[valueUpdateMessage.index].SetValue(valueUpdateMessage.value);
    }

    public void ReceiveValueUpdateMessageFloat(NetworkMessage message)
    {
        ValueUpdateMessageFloat valueUpdateMessage = message.ReadMessage<ValueUpdateMessageFloat>();
        this.fieldGUI.GUIs[valueUpdateMessage.index].SetValue(valueUpdateMessage.value);
    }

    public void ReceiveValueUpdateMessageString(NetworkMessage message)
    {
        ValueUpdateMessageString valueUpdateMessage = message.ReadMessage<ValueUpdateMessageString>();
        this.fieldGUI.GUIs[valueUpdateMessage.index].SetValue(valueUpdateMessage.value);
    }

    public void ReceiveValueUpdateMessageBool(NetworkMessage message)
    {
        ValueUpdateMessageBool valueUpdateMessage = message.ReadMessage<ValueUpdateMessageBool>();
        this.fieldGUI.GUIs[valueUpdateMessage.index].SetValue(valueUpdateMessage.value);
    }

    public void ReceiveValueUpdateMessageVector2(NetworkMessage message)
    {
        ValueUpdateMessageVector2 valueUpdateMessage = message.ReadMessage<ValueUpdateMessageVector2>();
        this.fieldGUI.GUIs[valueUpdateMessage.index].SetValue(valueUpdateMessage.value);
    }

    public void ReceiveValueUpdateMessageVector3(NetworkMessage message)
    {
        ValueUpdateMessageVector3 valueUpdateMessage = message.ReadMessage<ValueUpdateMessageVector3>();
        this.fieldGUI.GUIs[valueUpdateMessage.index].SetValue(valueUpdateMessage.value);
    }

    public void ReceiveValueUpdateMessageVector4(NetworkMessage message)
    {
        ValueUpdateMessageVector4 valueUpdateMessage = message.ReadMessage<ValueUpdateMessageVector4>();
        this.fieldGUI.GUIs[valueUpdateMessage.index].SetValue(valueUpdateMessage.value);
    }

    #endregion Method
}