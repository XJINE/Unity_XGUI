using UnityEngine;
using XJGUI;

// NOTE:
// Class and nested values sample.

public class FieldGUISample2 : MonoBehaviour
{
    #region Class

    [System.Serializable]
    public class SampleClass
    {
        public int value = 1;

        public SampleClassChild child1;
        public SampleClassChild child2;
    }

    [System.Serializable]
    public class SampleClassChild
    {
        public int value = 2;

        public SampleClassGrandChild grandChild;

        public SampleStruct sampleStruct;
    }

    [System.Serializable]
    public class SampleClassGrandChild
    {
        public int value = 3;
    }

    [System.Serializable]
    public struct SampleStruct
    {
        public int value;
    }

    #endregion Class

    #region Field

    public SampleClass sampleClass;

    private FlexibleWindow window;
    private FieldGUI fieldGUI;

    #endregion Field

    #region Method

    void Start()
    {
        this.window = new FlexibleWindow("FieldGUI Sample 2");
        this.fieldGUI = new FieldGUI(this.sampleClass);
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