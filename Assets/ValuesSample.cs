using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class ValuesSample : MonoBehaviour
{
    #region Field

    FlexibleWindow flexibleWindow;

    BoolsGUI boolsGUI;
    StringsGUI stringsGUI;

    IntsGUI intsGUI;
    FloatsGUI floatsGUI;
    Vector2sGUI vector2sGUI;

    public List<bool> boolList;
    public string[] stringArray;

    public List<int> intList;
    public float[] floatArray;
    public List<Vector2> vector2Array;

    #endregion Field

    #region Method

    void Start ()
    {
        this.flexibleWindow = new FlexibleWindow()
        {
            MinWidth = 300,
            MinHeight = 300,
        };

        this.boolsGUI = new BoolsGUI()
        {
            Title = "BoolList",
            Value = this.boolList
        };

        this.stringsGUI = new StringsGUI()
        {
            Title = "String Array",
            Value = this.stringArray
        };

        this.intsGUI = new IntsGUI()
        {
            Title = "Int List",
            Value = this.intList,
            MinValue = -100,
            MaxValue = 100,
            FieldWidth = 50
        };

        this.floatsGUI = new FloatsGUI()
        {
            Title = "Float Array",
            MinValue = -1,
            MaxValue = 10
        };
        this.floatsGUI.Value = this.floatArray;

        this.vector2sGUI = new Vector2sGUI()
        {
            Title = "Vector2 Array",
            MinValue = new Vector2(-10, -10),
            MaxValue = new Vector2(10, 10)
        };
        this.vector2sGUI.Value = this.vector2Array;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.intList.Add(0);
        }
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
        });
    }

    #endregion Method
}