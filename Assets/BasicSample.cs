using UnityEngine;
using XJGUI;

public class BasicSample : MonoBehaviour
{
    public enum SampleEnum
    {
        Value1 = 0,
        Value2 = 1,
        Value3 = 3,
        Value4 = 3,
    }

    FlexibleWindow flexibleWindow;

    TabPanel tabPanel;
    FoldoutPanel foldOutPanel;

    BoolGUI boolGUI;
    StringGUI stringGUI;
    IntGUI intGUI;
    FloatGUI  floatGUI;

    Vector2GUI vector2GUI;
    Vector3GUI vector3GUI;
    Vector4GUI vector4GUI;

    ColorGUI colorGUI;
    ColorGUI colorGUIHSV;
    Toolbar<string> toolBar;
    EnumGUI<SampleEnum> enumGUI;
    IPv4GUI ipv4GUI;

    void Start()
    {
        this.flexibleWindow = new FlexibleWindow()
        {
            Title = "Sample",
            MinWidth  = 300,
            MinHeight = 300,
        };

        this.tabPanel = new TabPanel()
        {
            Labels = new string[] { "Basic", "Vector", "Special" }
        };

        this.foldOutPanel = new FoldoutPanel()
        {
            Title = "Vector",
            Value = false
        };

        this.boolGUI = new BoolGUI()
        {
            Title = "Bool Value",
            BoldTitle = true,
            Value = false
        };

        this.stringGUI = new StringGUI()
        {
            Title = "String Value",
            Value = "XJGUI"
        };

        this.intGUI = new IntGUI()
        {
            Title = "int Value",
        };

        this.floatGUI = new FloatGUI()
        {
            Title = "float Value",
            Value = 50,
            MinValue = 0,
            MaxValue = 100,
            Decimals = 3,
        };

        this.enumGUI = new EnumGUI<SampleEnum>()
        {
            Value = SampleEnum.Value2,
            Title = "Sample Enum Value",
            ButtonWidth = 100
        };

        this.vector2GUI = new Vector2GUI()
        {
            Value = new Vector2(0.5f, 0.5f),
            Title = "Vector2 Value",
            Decimals = 1,
            MinValue = new Vector2(-1, -1),
            MaxValue = new Vector2(1, 1)
        };

        this.vector3GUI = new Vector3GUI()
        {
            Title = "Vector3 Value",
            MinValue = new Vector3(0, 0, 0),
            MaxValue = new Vector3(100, 100, 100),
        };

        this.vector4GUI = new Vector4GUI()
        {
            Title = "Vector4 Value",
            MinValue = new Vector4(-1, -2, -3, -4),
            MaxValue = new Vector4(1, 2, 3, 4),
        };

        this.colorGUI = new ColorGUI()
        {
            Title = "RGB Color"
        };

        this.colorGUIHSV = new ColorGUI()
        {
            Title = "HSV Color",
            HSVMode = true
        };

        this.toolBar = new Toolbar<string>()
        {
            Title = "Toolbar",
            Values = new string[] { "A", "B", "C" }
        };

        this.ipv4GUI = new IPv4GUI()
        {
            Title = "IPV4",
            Value = "7.7.7.7",
        };
    }

    void OnGUI()
    {
        this.flexibleWindow.Show(() =>
        {
            this.tabPanel.Show(TabPanel_Basic, TabPanel_Vector, tabPanel_Special);
        });
    }

    void TabPanel_Basic()
    {
        this.boolGUI.Show();
        this.stringGUI.Show();
        this.intGUI.Show();
        this.floatGUI.Show();
        this.enumGUI.Show();
    }

    void TabPanel_Vector()
    {
        this.foldOutPanel.Show(() =>
        {
            this.vector2GUI.Show();
            this.vector3GUI.Show();
            this.vector4GUI.Show();
        });
    }

    void tabPanel_Special()
    {
        this.colorGUI.Show();
        //this.colorGUIHSV.Show();
        this.toolBar.Show();
        this.ipv4GUI.Show();
    }
}