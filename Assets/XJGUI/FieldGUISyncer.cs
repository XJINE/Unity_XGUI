using System;
using UnityEngine;
using UnityEngine.Networking;
using XJGUI;

// https://docs.unity3d.com/jp/current/Manual/UNetMessages.html

public class FieldGUISyncer : NetworkBehaviour
{
    #region Class

    // NOTE:
    // MessageBase can't define object type in field.
    // Only 'Basic' type is allowed.

    public class ValueUpdateMessageType
    {
        public const short ValueUpdate = MsgType.Highest + 1;
    }

    public class ValueUpdateMessage : NetworkMessage//MessageBase
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

    #endregion Field

    #region Method

    void Start()
    {
        if (base.isClient)
        {
            // NOTE:
            // https://docs.unity3d.com/ScriptReference/Networking.NetworkMessageDelegate.html

            NetworkManager.singleton.client.RegisterHandler(ValueUpdateMessageType.ValueUpdate, Some);
        }
    }

    public void SendMessage(object value)
    {

        for (int i = 0; i < this.fieldGUI.FieldGUIs.Count; i++)
        {
            if (this.fieldGUI.FieldGUIs[i].IsUpdate)
            {
                NetworkServer.SendByChannelToAll(ValueUpdateMessageType.ValueUpdate, message, this.reliableChannel);
            }
        }
    }

    public void Some(ValueUpdateMessage message)
    {
        //NON.
    }

    public void ReceiveValueUpdateMessage(ValueUpdateMessageInt message)
    {
        this.fieldGUI.FieldGUIs[message.index].SetValue(message.value);
    }

    public void ReceiveValueUpdateMessage(ValueUpdateMessageFloat message)
    {
        this.fieldGUI.FieldGUIs[message.index].SetValue(message.value);
    }

    public void ReceiveValueUpdateMessage(ValueUpdateMessageBool message)
    {
        this.fieldGUI.FieldGUIs[message.index].SetValue(message.value);
    }

    public void ReceiveValueUpdateMessage(ValueUpdateMessageString message)
    {
        this.fieldGUI.FieldGUIs[message.index].SetValue(message.value);
    }

    public void ReceiveValueUpdateMessage(ValueUpdateMessageVector2 message)
    {
        this.fieldGUI.FieldGUIs[message.index].SetValue(message.value);
    }

    public void ReceiveValueUpdateMessage(ValueUpdateMessageVector3 message)
    {
        this.fieldGUI.FieldGUIs[message.index].SetValue(message.value);
    }

    public void ReceiveValueUpdateMessage(ValueUpdateMessageVector4 message)
    {
        this.fieldGUI.FieldGUIs[message.index].SetValue(message.value);
    }

    #endregion Method
}