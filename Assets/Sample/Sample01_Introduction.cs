using UnityEngine;
using XJGUI;

public class Sample01_Introduction : MonoBehaviour
{
    private FlexibleWindow flexibleWindow;
    private IntGUI intGUI;
    private FloatGUI floatGUI;

    public int intValue;
    public float floatValue;

    void Start()
    {
        // NOTE:
        // Any other settings.
        //this.flexibleWindow.IsVisible
        //this.flexibleWindow.IsDraggable
        //this.flexibleWindow.MinHeight/MaxHeight
        //this.flexibleWindow.MinWidth/MaxWidth

        this.flexibleWindow = new FlexibleWindow();
        this.flexibleWindow.Title = "Sample01";

        this.intGUI = new IntGUI()
        {
            Title = "Int Value",
            BoldTitle = true,
            Value = this.intValue,
            MinValue = -10,
            MaxValue = 10,
        };

        this.floatGUI = new FloatGUI()
        {
            Title = "Float Value",
            Value = this.floatValue,
            MinValue = 0,
            MaxValue = 100,
            Decimals = 3,
        };
    }

    void OnGUI()
    {
        this.flexibleWindow.Show(() =>
        {
            // NOTE:
            // You can receive the result of GUI operation as return value.

            this.intValue = this.intGUI.Show();
            this.floatValue = this.floatGUI.Show();
        });
    }
}