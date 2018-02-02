using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class Sample08_FieldGUI : MonoBehaviour
{
    // NOTE:
    // FieldGUI generates and shows GUI automatically.
    // Public and supported type fields are shown.
    // Supported types are introduced in previous samples.

    #region Field

    public FlexibleWindow flexibleWindow = new FlexibleWindow();

    public FieldGUI fieldGUI;

    // NOTE:
    // You can set some settings with Attribute.
    // If you want to hide some field from FieldGUI, use "Hide" option.

    [FieldGUIInfo(Title = "Hide UnsupportedGUI")]
    public bool boolValue = false;

    public string stringValue = "Sample";

    [FieldGUIInfo(Group = "Simple Value", Hide = true)]
    public int intValueHide = 5;

    [FieldGUIInfo(Group = "Simple Value", MinValue = 0, MaxValue = 100)]
    public float floatValue = 10;

    [FieldGUIInfo(Group = "Simple Value")]
    public List<int> intValues = new List<int>() { 0, 1, 2 };

    [FieldGUIInfo(Group = "Simple Value", Decimals = 1)]
    public float[] floatValues = new float[] { 0, 1, 2 };

    [FieldGUIInfo(Group = "Vector Value")]
    public Vector3 vector3Value = new Vector3(1, 1, 1);

    [FieldGUIInfo(Group = "Vector Value")]
    public List<Vector3> vector3Values = new List<Vector3>() { Vector3.one, Vector3.up, Vector3.back };

    [FieldGUIInfo(HSV = false)]
    public Color colorValue = new Color(1, 0, 0, 0.5f);

    [FieldGUIInfo(Title = "Camera Type Enum")]
    public CameraType enumValue = CameraType.Game;

    [FieldGUIInfo(IPv4 = true)]
    public string ipV4Value = "0.7.7.7";

    #endregion Field

    void Start()
    {
        this.fieldGUI = new FieldGUI();
        this.fieldGUI.Value = this;
    }

    void OnGUI()
    {
        // NOTE:
        // This sample set "this" instance to FieldGUI.Value, so fields include "flexWindow" & "fieldGUI".
        // These are unsupported value. FieldGUI default setting generates "UnsupportedGUI" & hide them.
        // If you need to check them, set HideUnsupportedGUI option false.

        this.fieldGUI.HideUnsupportedGUI = this.boolValue;

        this.flexibleWindow.Show(() =>
        {
            this.fieldGUI.Show();
        });
    }
}