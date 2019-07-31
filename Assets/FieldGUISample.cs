using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class FieldGUISample : MonoBehaviour
{
    #region Field

    public bool boolValue;
    [Range(0, 3)]
    public int intValue;
    public string stringValue;
    [GUI(Width = 300)]
    public string longStringValue;
    [GUI(Hide = true)]
    public string hideValue;

    [Header("Vector")]

    public Vector2 vector2Value;
    public Vector3 vector3Value;
    [GUI(MinValue = 0, MaxValue = 10)][Range(0, 1)]
    public Vector4 vector4Value;
    [GUI(Title = "V2I")]
    public Vector2Int vector2IntValue;
    public Vector3Int vector3IntValue;

    [Header("Others")]

    public bool hideUnSupportedGUI;
    public Material materialValue;

    public Color colorValue;
    public Matrix4x4 matrixValue;
    [GUI(Width = 300)]
    public CameraType cameraTypeA;
    public CameraType cameraTypeB;
    public UserStruct userStructValue;

    [Header("Array")]
    public int[] intArrayValue;
    public List<UserStruct> structListValue;
    public List<CameraType>[] enumListArrayValue = new List<CameraType>[]
    {
        new List<CameraType>(){ CameraType.Game,       CameraType.Preview   },
        new List<CameraType>(){ CameraType.Reflection, CameraType.SceneView },
    };

    private FlexWindow window;
    private FieldGUI<FieldGUISample> fieldGUI;

    #endregion Field

    #region Method

    private void Start()
    {
        this.window = new FlexWindow("FieldGUI Sample");
        this.fieldGUI = new FieldGUI<FieldGUISample>();
    }

    private void OnGUI()
    {
        this.window.Show(() =>
        {
            this.fieldGUI.Show(this);
        });

        this.fieldGUI.HideUnsupportedGUI = this.hideUnSupportedGUI;
    }

    #endregion Method
}