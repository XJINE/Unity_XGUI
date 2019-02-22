using UnityEngine;
using XJGUI;

public class FieldGUISample : MonoBehaviour
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

        [FieldGUIInfo(Title = "V2")]
        public Vector2 vector2Value;

        [FieldGUIInfo(Decimals = 3)]
        public Vector3 vector3Value;

        public Vector4 vector4Value;

        public Vector2Int vector2IntValue;

        public Vector3Int vector3IntValue;

        public Color colorValue;

        [FieldGUIInfo(IPv4 = true)]
        public string  ipv4Value;
    }

    public SampleClass sampleClass = new SampleClass();

    private FlexibleWindow window;
    private FieldGUI fieldGUI;

    void Start()
    {
        this.window = new FlexibleWindow() { Title = "FieldGUISample", MinWidth = 300 };
        this.fieldGUI = new FieldGUI() { Value = this.sampleClass };
    }

    void OnGUI()
    {
        this.window.Show(() =>
        {
            this.fieldGUI.Show();
        });
    }
}