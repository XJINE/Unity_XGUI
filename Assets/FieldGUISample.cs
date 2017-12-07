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

        [FieldGUIInfo(MinValue = 0, MaxValue = 10, Decimals = 3)]
        public float sampleFloat = 4;
        private float privateFloat = -1;
    }

    #region Field

    public SampleClass sampleClass;

    public FieldGUI fieldGUI;

    #endregion Field

    #region Method

    void Start ()
    {
        this.sampleClass = new SampleClass();
        this.fieldGUI = new FieldGUI(this.sampleClass);

        DebugEx.LogField(this.sampleClass);
    }
    
    void OnGUI ()
    {
        this.fieldGUI.Show();
    }

    #endregion Method
}