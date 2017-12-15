using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class FieldGUISample : MonoBehaviour
{
    #region Field

    public FlexibleWindow flexWindow = new FlexibleWindow();

    public FieldGUI fieldGUI;

    [FieldGUIInfo(Title = "Hide UnsupportedGUI")]
    public bool boolValue = false;

    public string stringValue = "Sample";

    [FieldGUIInfo(MinValue = 0, MaxValue = 100)]
    public int intValue = 0;

    [FieldGUIInfo(Hide = true)]
    public int intValueHide = 5;

    public float floatValue = 10;

    public Vector2 vector2Value = new Vector2(0, 0);

    public Vector3 vector3Value = new Vector3(1, 1, 1);

    public Vector4 vector4Value = new Vector4(1, 1, 1, 1);

    public List<int> intValues = new List<int>() { 0, 1, 2 };

    [FieldGUIInfo(Decimals = 1)]
    public float[] floatValues = new float[] { 0, 1, 2 };

    public List<Vector3> vector3Values = new List<Vector3>() { Vector3.one, Vector3.up, Vector3.back };

    [FieldGUIInfo(Title = "Camera Clear Enum")]
    public CameraClearFlags enumValue = CameraClearFlags.Skybox;

    [FieldGUIInfo(IPv4 = true)]
    public string ipV4Value = "0.7.7.7";

    #endregion Field

    void Start()
    {
        this.flexWindow.MinWidth = 300;
        this.flexWindow.MinHeight = 300;
        this.fieldGUI = new FieldGUI();
        this.fieldGUI.Value = this;
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