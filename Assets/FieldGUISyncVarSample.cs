using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;
using XJGUI;

public class FieldGUISyncVarSample : NetworkBehaviour
{
    #region Field

    public FlexibleWindow flexWindow = new FlexibleWindow();

    public FieldGUI fieldGUI;

    [SyncVar]
    public int syncValue = 5;

    [SyncVar]
    [FieldGUIInfo(Title = "Hide UnsupportedGUI")]
    public bool boolValue = false;

    [SyncVar]
    public string stringValue = "Sample";

    [SyncVar]
    [FieldGUIInfo(MinValue = 0, MaxValue = 100)]
    public int intValue = 0;

    [SyncVar]
    [FieldGUIInfo(HideInGUI = true)]
    public int intValueHide = 5;

    [SyncVar]
    public float floatValue = 10;

    [SyncVar]
    public Vector2 vector2Value = new Vector2(0, 0);

    [SyncVar]
    public Vector3 vector3Value = new Vector3(1, 1, 1);

    [SyncVar]
    public Vector4 vector4Value = new Vector4(1, 1, 1, 1);

    //[SyncVar]
    public List<int> intValues = new List<int>() { 0, 1, 2 };

    //[SyncVar]
    [FieldGUIInfo(Decimals = 1)]
    public float[] floatValues = new float[] { 0, 1, 2 };

    //[SyncVar]
    public List<Vector3> vector3Values = new List<Vector3>() { Vector3.one, Vector3.up, Vector3.back };

    [SyncVar]
    [FieldGUIInfo(Title = "Camera Clear Enum")]
    public CameraClearFlags enumValue = CameraClearFlags.Skybox;

    [SyncVar]
    [FieldGUIInfo(IPv4 = true)]
    public string ipV4Value = "0.7.7.7";

    #endregion Field

    void Start()
    {
        this.flexWindow.MinWidth = 300;
        this.flexWindow.MinHeight = 300;
        this.fieldGUI = new FieldGUI(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.flexWindow.IsVisible = !this.flexWindow.IsVisible;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FieldInfo[] fieldInfos = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                if (fieldInfo.Name == "syncValue")
                {
                    fieldInfo.SetValue(this, (int)fieldInfo.GetValue(this) + 1);
                }
            }
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2, Screen.height/2, 500, 500), "VALUE : " + this.syncValue);

        this.fieldGUI.HideUnsupportedGUI = this.boolValue;

        this.flexWindow.Show(() =>
        {
            this.fieldGUI.Show();
        });
    }
}