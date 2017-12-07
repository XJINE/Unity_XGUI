using System;
using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class ToolbarSample : MonoBehaviour
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

    int[] toolbarIntValues;
    Toolbar<int> toolbarInt;

    Toolbar<SampleEnum> toolbarEnum;

    List<SampleClass> toolbarSampleClassValues;
    Toolbar<SampleClass> toolbarSampleClass;

    #endregion Field

    #region Method

    void Start ()
    {
        this.flexibleWindow = new FlexibleWindow()
        {
            MinWidth = 300,
            MinHeight = 300,
        };

        this.toolbarIntValues = new int[] { 0, 5, 10, 15 };

        this.toolbarInt = new Toolbar<int>()
        {
            Title = "Toolbar Int",
            Values = this.toolbarIntValues
        };

        Array enumArray = Enum.GetValues(typeof(SampleEnum));
        SampleEnum[] enums = new SampleEnum[enumArray.Length];
        enumArray.CopyTo(enums, 0);

        this.toolbarEnum = new Toolbar<SampleEnum>()
        {
            Title = "Toolbar Enum",
            GridX = 3,
            Values = enums,
            Foldout = true
        };

        SampleClass sample1 = new SampleClass();
        SampleClass sample2 = new SampleClass();
        SampleClass sample3 = new SampleClass();

        this.toolbarSampleClassValues = new List<SampleClass>()
        {
            sample1, sample2, sample3
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