using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class FieldGUISyncSample : MonoBehaviour
{
    #region Field

    public FieldGUISync FieldGUISync;

    public FlexibleWindow flexWindow = new FlexibleWindow();

    protected FieldGUI fieldGUI;

    [FieldGUIInfo(Title = "Hide UnsupportedGUI")]
    public bool boolValue = true;

    public string stringValue1 = "Sync";

    [FieldGUIInfo(Sync = false)]
    public string stringValue2 = "No Sync";

    [FieldGUIInfo(MinValue = 0, MaxValue = 100)]
    public int intValue = 0;

    [FieldGUIInfo(Hide = true)]
    public int intValueHide = 5;

    public float floatValue = 10;

    public Vector3 vector3Value = new Vector3(1, 1, 1);

    public List<bool> boolValues = new List<bool> { true, false, false };

    public List<string> stringValues = new List<string> { "a", "i", "u" };

    [FieldGUIInfo(Decimals = 1)]
    public float[] floatValues = new float[] { 0, 1, 2 };

    public List<Vector3> vector3Values = new List<Vector3>() { Vector3.one, Vector3.up, Vector3.back };

    [FieldGUIInfo(Title = "Camera Clear Enum")]
    public CameraClearFlags enumValue = CameraClearFlags.Skybox;

    [FieldGUIInfo(IPv4 = true)]
    public string ipV4Value = "0.7.7.7";

    #endregion Field

    public enum sample
    {
        value1 = 0,
        value2 = 1,
    }

    void Start()
    {
        this.fieldGUI = new FieldGUI();
        this.fieldGUI.Value = this;

        this.FieldGUISync.SetFieldGUI(this.fieldGUI);

        this.flexWindow.MinWidth = 300;
        this.flexWindow.MinHeight = 300;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.flexWindow.IsVisible = !this.flexWindow.IsVisible;
        }
    }

    void OnGUI()
    {
        this.fieldGUI.HideUnsupportedGUI = this.boolValue;

        this.flexWindow.Show(() =>
        {
            this.fieldGUI.Show();
        });
    }
}