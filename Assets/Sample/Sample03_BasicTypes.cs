using UnityEngine;
using XJGUI;

public class Sample03_BasicTypes : MonoBehaviour
{
    private FlexibleWindow flexibleWindow;

    private IntGUI    intGUI;
    private FloatGUI  floatGUI;
    private BoolGUI   boolGUI;
    private StringGUI stringGUI;

    private Vector2GUI vector2GUI;
    private Vector3GUI vector3GUI;
    private Vector4GUI vector4GUI;

    void Start()
    {
        this.flexibleWindow = new FlexibleWindow();

        this.intGUI    = new IntGUI()    { Title = "Int Value"   };
        this.floatGUI  = new FloatGUI()  { Title = "Float Value" };
        this.boolGUI   = new BoolGUI()   { Title = "Bool Value"  };
        this.stringGUI = new StringGUI() { Title = "String Value", Value = "aiueo"};

        this.vector2GUI = new Vector2GUI() { Title = "Vector2 Value" };
        this.vector3GUI = new Vector3GUI() { Title = "Vector3 Value", Decimals = 3 };
        this.vector4GUI = new Vector4GUI() { Title = "Vector4 Value", WithSlider = false };
    }

    void OnGUI()
    {
        this.flexibleWindow.Show(() =>
        {
            this.intGUI.Show();
            this.floatGUI.Show();
            this.boolGUI.Show();
            this.stringGUI.Show();

            this.vector2GUI.Show();
            this.vector3GUI.Show();
            this.vector4GUI.Show();
        });
    }
}