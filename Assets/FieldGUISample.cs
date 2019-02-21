using UnityEngine;
using XJGUI;

public class FieldGUISample : MonoBehaviour
{
    [System.Serializable]
    public class SampleClass
    {
        public bool     boolValue;
        public string   stringValue;
        public int      intValue;
        public float   floatValue;
        public Vector2 vector2Value;
        public Vector3 vector3Value;
        public Vector4 vector4Value;
        public Color   colorValue;
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