using System;
using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class Sample05_Toolbar : MonoBehaviour
{
    #region Class

    public enum SampleEnum
    {
        value1, value2, value3, value4, value5, value6, value7, value8, value9, value0
    }

    public class SampleClass { }

    #endregion Class

    #region Field

    FlexibleWindow flexibleWindow;
    Toolbar<int> toolbarInt;
    Toolbar<SampleEnum> toolbarEnum;
    Toolbar<SampleClass> toolbarSampleClass;

    int[] toolbarIntValues = new int[] { 0, 5, 10, 15 };
    List<SampleClass> toolbarSampleClassValues = new List<SampleClass>()
    {
        new SampleClass(), new SampleClass(), new SampleClass()
    };

    #endregion Field

    #region Method

    void Start ()
    {
        this.flexibleWindow = new FlexibleWindow();

        this.toolbarInt = new Toolbar<int>()
        {
            Title = "Toolbar Int",
            Values = this.toolbarIntValues
        };

        this.toolbarEnum = new Toolbar<SampleEnum>()
        {
            Title = "Toolbar Enum",
            GridX = 3,
            //Values = Enum.GetValues(typeof(SampleEnum)),
            Foldout = true
        };

        this.toolbarSampleClass = new Toolbar<SampleClass>()
        {
            Title = "Toolbar Sample Class",
            Values = this.toolbarSampleClassValues,
        };
    }

    void OnGUI()
    {
        this.flexibleWindow.Show(() =>
        {
            this.toolbarInt.Show();
            this.toolbarEnum.Show();
            this.toolbarSampleClass.Show();
        });
    }

    #endregion Method
}