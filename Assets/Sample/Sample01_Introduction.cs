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
        // this.flexibleWindow.IsVisible
        // this.flexibleWindow.IsDraggable
        // this.flexibleWindow.MinHeight/MaxHeight
        // this.flexibleWindow.MinWidth/MaxWidth

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // NOTE:
            // You can use ToggleVisibility function instead of following code.
            // this.flexibleWindow.ToggleVisibility();

            this.flexibleWindow.IsVisible = !this.flexibleWindow.IsVisible;
        }
    }

    void OnGUI()
    {
        this.flexibleWindow.Show(() =>
        {
            // NOTE:
            // You can get the result of GUI operation as return value.
            // Or Value property is also show the result.

            this.intValue = this.intGUI.Show();

            this.floatGUI.Show();
            this.floatValue = this.floatGUI.Value;
        });
    }
}