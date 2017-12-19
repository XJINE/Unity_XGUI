using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class Sample05_Values : MonoBehaviour
{
    // CAUTION:
    // IList type GUI cannot detect some array length is changed from Inspector.
    // (List length changing is able to detect.)

    #region Field

    FlexibleWindow flexibleWindow;

    BoolsGUI boolsGUI;
    StringsGUI stringsGUI;

    IntsGUI intsGUI;
    FloatsGUI floatsGUI;
    Vector2sGUI vector2sGUI;

    ColorsGUI colorsGUI;
    IPv4sGUI ipv4sGUI;
    EnumsGUI<CameraClearFlags> enumsGUI;

    public List<bool> boolList;
    public string[] stringArray;

    public List<int> intList;
    public float[] floatArray;
    public List<Vector2> vector2Array;

    public List<Color> colorList;
    public string[] ipv4Array;
    public CameraClearFlags[] enumsArray;

    #endregion Field

    #region Method

    void Start ()
    {
        this.flexibleWindow = new FlexibleWindow();

        this.boolsGUI = new BoolsGUI()
        {
            Title = "BoolList",
            Value = this.boolList
        };

        this.stringsGUI = new StringsGUI()
        {
            Title = "String Array",
        };
        this.stringsGUI.Value = this.stringArray;

        this.intsGUI = new IntsGUI()
        {
            Title = "Int List",
            Value = this.intList,
            MinValue = -100,
            MaxValue = 100,
        };

        this.floatsGUI = new FloatsGUI()
        {
            Title = "Float Array",
            Value = this.floatArray,
        };

        this.vector2sGUI = new Vector2sGUI()
        {
            Title = "Vector2 Array",
            MinValue = new Vector2(-10, -10),
            MaxValue = new Vector2(10, 10),
            Value = this.vector2Array
        };

        this.colorsGUI = new ColorsGUI()
        {
            Title = "Colors",
            Value = this.colorList
        };

        this.ipv4sGUI = new IPv4sGUI()
        {
            Title = "IPv4s",
            Value = this.ipv4Array,
        };

        this.enumsGUI = new EnumsGUI<CameraClearFlags>()
        {
            Title = "Enums",
            Value = this.enumsArray,
        };
    }

    void OnGUI()
    {
        this.flexibleWindow.Show(() =>
        {
            this.boolsGUI.Show();
            this.stringsGUI.Show();

            this.intsGUI.Show();
            this.floatsGUI.Show();
            this.vector2sGUI.Show();

            this.colorsGUI.Show();
            this.ipv4sGUI.Show();
            this.enumsGUI.Show();
        });
    }

    #endregion Method
}