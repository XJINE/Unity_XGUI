using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class Sample09_FieldGUISync : MonoBehaviour
{
    // CAUTION:
    // This sample use resources in Packages/CustomNetworkManager.
    // However, XJGUI does not depends on these.

    #region Field

    public FieldGUISync FieldGUISync;

    public FlexibleWindow flexibleWindow = new FlexibleWindow();

    protected FieldGUI fieldGUI;

    [FieldGUIInfo(Title = "Hide UnsupportedGUI")]
    public bool boolValue = true;

    // NOTE:
    // If you want to sync a field, set Sync = true (default). And if not, set false.
    // If you want to change default setting, set XJGUILayout.DefaultSync = false.

    [FieldGUIInfo(Sync = true)]
    public string stringValue1 = "Sync";

    [FieldGUIInfo(Sync = false)]
    public string stringValue2 = "No Sync";

    [FieldGUIInfo(Hide = true)]
    public int intValueHide = 5;

    [FieldGUIInfo(MinValue = 0, MaxValue = 100)]
    public float floatValue = 10;

    public Vector3 vector3Value = new Vector3(1, 1, 1);

    [FieldGUIInfo(Group = "Values")]
    public List<string> stringValues = new List<string> { "a", "i", "u" };

    [FieldGUIInfo(Group = "Values", Decimals = 1)]
    public float[] floatValues = new float[] { 0, 1, 2 };

    [FieldGUIInfo(Group = "Values")]
    public List<Vector3> vector3Values = new List<Vector3>() { Vector3.one, Vector3.up, Vector3.back };

    [FieldGUIInfo(Group = "Values", HSV = true)]
    public List<Color> colorValues = new List<Color>() { Color.red, Color.green, Color.blue };

    [FieldGUIInfo(Title = "Camera Type Enum")]
    public CameraType enumValue = CameraType.Game;

    public List<CameraType> enumValues
        = new List<CameraType>() { CameraType.Preview, CameraType.VR };

    [FieldGUIInfo(IPv4 = true)]
    public string ipv4Value = "0.7.7.7";

    [FieldGUIInfo(IPv4 = true)]
    public string[] ipv4Values = new string[] { "192.168.11.1", "127.0.0.1" };

    #endregion Field

    #region Method

    void Start()
    {
        this.fieldGUI = new FieldGUI();
        this.fieldGUI.Value = this;

        // NOTE:
        // If you want to sync FieldGUI values, add to FieldGUISync.

        this.FieldGUISync.Add(this.fieldGUI);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.flexibleWindow.ToggleVisibility();
        }
    }

    void OnGUI()
    {
        // NOTE:
        // FieldGUISync also works and sync values when client GUIs are not shown.

        this.flexibleWindow.Show(() =>
        {
            this.fieldGUI.Show();
        });
    }

    // NOTE:
    // Regist this function to FieldGUISync.syncedEventHandler from Inspector.

    public void OnSynced() 
    {
        Debug.Log("SYNCED!");
    }

    #endregion Method
}