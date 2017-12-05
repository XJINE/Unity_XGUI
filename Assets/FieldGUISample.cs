using UnityEngine;
using XJGUI;

public class FieldGUISample : MonoBehaviour
{
    public enum SampleEnum
    {
        value1,
        value2
    }

    public class SampleClass
    {
        public SampleEnum sampleEnum;
    }

    public SampleClass sampleClass;

    public FieldGUI fieldGUI;

    void Start ()
    {
        this.sampleClass = new SampleClass();
        this.fieldGUI = new FieldGUI(this.sampleClass);
    }
    
    void OnGUI ()
    {
        this.fieldGUI.Show();
    }
}