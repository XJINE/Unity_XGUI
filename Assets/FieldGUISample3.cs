using UnityEngine;
using XJGUI;

// NOTE:
// struct type FieldGUI sample.

public class FieldGUISample3 : MonoBehaviour
{
    #region Struct

    [System.Serializable]
    public struct SampleStructA
    {
        public int value;
        public SampleStructB child1;
        public SampleStructB child2;
    }

    [System.Serializable]
    public struct SampleStructB
    {
        public int value;
    }

    #endregion Struct

    #region Field

    public SampleStructA sampleStructA;
    public SampleStructB sampleStructB;

    private FlexibleWindow window;
    private FieldGUI fieldGUISampleStructA;
    private FieldGUI fieldGUISampleStructB;

    #endregion Field

    #region Method

    void Start()
    {
        this.window = new FlexibleWindow("FieldGUI Sample 3");
        this.fieldGUISampleStructA = new FieldGUI(this.sampleStructA);
        this.fieldGUISampleStructB = new FieldGUI(this.sampleStructB);
    }

    void OnGUI()
    {
        this.window.Show(() =>
        {
            this.sampleStructA = (SampleStructA)this.fieldGUISampleStructA.Show();
            this.sampleStructB = (SampleStructB)this.fieldGUISampleStructB.Show();

            // NOTE:
            // These are not working correctly.

            //this.fieldGUISampleStructA.Show();
            //this.fieldGUISampleStructB.Show();
        });
    }

    #endregion Method
}