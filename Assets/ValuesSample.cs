using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class ValuesSample : MonoBehaviour
{
    #region Field

    FlexibleWindow flexibleWindow;

    IntsGUI intsGUI;
    FloatsGUI floatsGUI;
    Vector2sGUI vector2sGUI;

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

        this.intsGUI = new IntsGUI() { Title = "Int List", MaxValue = 100, TextFieldWidth = 50 };
        this.intsGUI.Value = this.intList;

        this.floatsGUI = new FloatsGUI() { Title = "Float Array", MinValue = -1, MaxValue = 10 };
        this.floatsGUI.Value = this.floatArray;

        this.vector2sGUI = new Vector2sGUI() { Title = "Vector2 Array", MaxValue = new Vector2(10, 10) };
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
            this.intsGUI.Show();
            this.floatsGUI.Show();
            this.vector2sGUI.Show();
        });
    }

    #endregion Method
}