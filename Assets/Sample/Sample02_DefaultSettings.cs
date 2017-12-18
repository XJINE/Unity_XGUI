using UnityEngine;
using XJGUI;

public class Sample02_DefaultSettings : MonoBehaviour
{
    private FlexibleWindow flexibleWindow;
    private IntGUI intGUI1;
    private IntGUI intGUI2;

    public int intValue1;
    public int intValue2;

    void Start()
    {
        // NOTE:
        // There are many default settings in XJGUILayout.
        // You can set the default values before you generate XJGUI.
        // It helps you when define each GUIs settings.

        XJGUILayout.DefaultValueInt = 50;
        XJGUILayout.DefaultMaxValueInt = 100;

        this.flexibleWindow = new FlexibleWindow()
        {
            Title = "Sample02"
        };

        this.intGUI1 = new IntGUI()
        {
            Title = "Int Value 1"
        };

        // NOTE:
        // You can override default settings.

        this.intGUI2 = new IntGUI()
        {
            Title = "Int Value 2",
            MaxValue = 10,
            MinValue = 0,
        };
    }

    void OnGUI()
    {
        this.flexibleWindow.Show(() =>
        {
            this.intValue1 = this.intGUI1.Show();
            this.intValue2 = this.intGUI2.Show();
        });
    }
}