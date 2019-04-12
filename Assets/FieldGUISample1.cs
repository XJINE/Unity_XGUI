using UnityEngine;
using XJGUI;

public class FieldGUISample1 : MonoBehaviour
{
    [System.Serializable]
    public class SampleClass
    {
        public bool boolValue;

        [FieldGUIInfo(FieldWidth = 200)]
        public string stringValue;

        public int intValue;

        [FieldGUIInfo(MaxValue = 0.5f)]
        public float floatValue;

        [Header("Vectors")]

        [FieldGUIInfo(Title = "V2")]
        public Vector2 vector2Value;

        [FieldGUIInfo(Decimals = 3)]
        public Vector3 vector3Value;

        [FieldGUIInfo(MinValue = 0.5f)]
        public Vector4 vector4Value;

        public Vector2Int vector2IntValue;

        public Vector3Int vector3IntValue;

        public Matrix4x4 matrix4x4Value;

        [Header("Others")]

        public Color colorValue;

        [FieldGUIInfo(Hide = true)]
        public Color hideValue;

        [FieldGUIInfo(IPv4 = true)]
        public string  ipv4Value;

        public CameraType enumValue;

        // NOTE:
        // IList is unsupported now.

        public int[] arrayValue;

        // NOTE:
        // This causes an error.

        // public object errorValue
    }

    #region Field

    public SampleClass sampleClass = new SampleClass();

    private FlexibleWindow window;
    private FieldGUI fieldGUI;

    #endregion Field

    #region Method

    void Start()
    {
        this.window = new FlexibleWindow("FieldGUI Sample 1");

        this.fieldGUI = new FieldGUI(this.sampleClass)
        {
            HideUnsupportedGUI = false,
            Foldout = true
        };
    }

    void OnGUI()
    {
        this.window.Show(() =>
        {
            this.fieldGUI.Show();
        });
    }

    #endregion Method
}