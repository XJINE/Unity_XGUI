using System.Collections.Generic;
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
        public string sampleString = "SAMPLE";

        [FieldGUIInfo(MinValue = 0, MaxValue = 100)]
        public int sampleInt = 0;

        [FieldGUIInfo(HideInGUI = true)]
        public int sampleIntHide = 0;

        [FieldGUIInfo(MinValue = 0, MaxValue = 10, Decimals = 3)]
        public float sampleFloat = 4;

        private float privateFloat = -1;

        [FieldGUIInfo(MinValue = 0, MaxValue = 5)]
        public List<Vector3> vector3List;

        public SampleEnum sampleEnum;
    }

    #region Field

    public SampleClass sampleClass;

    public FlexibleWindow flexibleWindow;

    public FieldGUI fieldGUI;

    #endregion Field

    #region Method

    void Start ()
    {
        this.sampleClass = new SampleClass();
        this.sampleClass.vector3List = new List<Vector3>() { Vector3.one, Vector3.zero, Vector3.up, Vector3.right };

        this.flexibleWindow = new FlexibleWindow()
        {
            MinWidth = 400,
            MinHeight = 300,
        };

        this.fieldGUI = new FieldGUI(this.sampleClass);
    }
    
    void OnGUI ()
    {
        this.flexibleWindow.Show(() =>
        {
            this.fieldGUI.Show();
        });
    }

    #endregion Method
}