using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class Sample07_Toolbar : MonoBehaviour
{
    // NOTE:
    // Toolbar return selected index value.
    // However, in almost case, I think you should use
    // Enum & EnumGUI to switch your operation or any others.
    // This GUI is implemented for standard GUILayout.Toolbar user.

    #region Class

    public class SampleClass
    {
        public string name;

        public override string ToString() { return name; }
    }

    #endregion Class

    #region Field

    FlexibleWindow flexibleWindow;
    Toolbar<int> toolbarInt;
    Toolbar<CameraType> toolbarEnum;
    Toolbar<SampleClass> toolbarObject;

    CameraType currentEnum;
    CameraType[] enumValues = new CameraType[] { CameraType.Game,
                                                 CameraType.VR,
                                                 CameraType.SceneView };
    SampleClass currentObject;
    List<SampleClass> objectValues = new List<SampleClass>()
    {
        new SampleClass() { name = "ObjectA" },
        new SampleClass() { name = "ObjectB" },
        new SampleClass() { name = "ObjectC" }
    };

    int currentInt;
    int[] intValues = new int[] {  2,  3,  5,  7,
                                  11, 13, 17, 19,
                                  23, 29, 31, 37 };

    #endregion Field

    #region Method

    void Start ()
    {
        this.flexibleWindow = new FlexibleWindow();

        this.currentEnum = CameraType.Game;
        this.toolbarEnum = new Toolbar<CameraType>()
        {
            Title = "Toolbar Enum",
            Value = this.currentEnum,
            Values = this.enumValues,
        };

        this.currentObject = this.objectValues[2];
        this.toolbarObject = new Toolbar<SampleClass>()
        {
            Title = "Toolbar Sample Class",
            Value = this.currentObject,
            Values = this.objectValues
        };

        this.currentInt = this.intValues[1];
        this.toolbarInt = new Toolbar<int>()
        {
            Title = "Toolbar Int",
            Value = this.currentInt,
            Values = this.intValues,
            GridX = 4,
            Foldout = true
        };
    }

    void OnGUI()
    {
        this.flexibleWindow.Show(() =>
        {
            this.currentEnum = this.toolbarEnum.Show();
            this.currentObject = this.toolbarObject.Show();
            this.currentInt = this.toolbarInt.Show();
        });

        Debug.Log(currentEnum.ToString() + " / "
                + currentObject.ToString() + " / "
                + currentInt.ToString());
    }

    #endregion Method
}