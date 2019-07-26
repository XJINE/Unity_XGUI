using UnityEngine;
using XJGUI;

public class FieldGUISample1 : MonoBehaviour
{
    #region Field

    public bool   boolValue;
    public int    intValue;
    public string stringValue;

    [Header("Vector")]

    public Vector2 vector2Value;
    public Vector3 vector3Value;
    public Vector4 vector4Value;

    [GUIInfo(Title = "V2I")]
    public Vector2Int vector2IntValue;
    public Vector3Int vector3IntValue;

    [Header("Others")]
    public Color      colorValue;
    public Matrix4x4  matrixValue;
    public CameraType cameraType;

    [GUIInfo(IPv4 = true)]
    public string ipV4Value;

    private FlexWindow window;
    private FieldGUI<FieldGUISample1> fieldGUI;

    #endregion Field

    #region Method

    private void Start()
    {
        this.window = new FlexWindow();
        this.fieldGUI = new FieldGUI<FieldGUISample1>();
    }

    private void OnGUI()
    {
        this.window.Show(() =>
        {
            this.fieldGUI.Show(this);
        });
    }

    #endregion Method
}