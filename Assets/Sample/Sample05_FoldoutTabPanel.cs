using UnityEngine;
using XJGUI;

public class Sample05_FoldoutTabPanel : MonoBehaviour
{
    private FlexibleWindow flexibleWindow;

    private ColorGUI colorGUI;
    private ColorGUI colorGUIHSV;
    private EnumGUI<CameraClearFlags> enumGUI;
    private IPv4GUI ipv4GUI;

    public Color colorValue;
    public Color colorValueHSV;
    public CameraClearFlags enumValue;
    public string ipv4Value;

    void Start()
    {
        this.flexibleWindow = new FlexibleWindow();

        this.colorGUI = new ColorGUI()
        {
            Title = "Color Value",
            Value = this.colorValue,
        };

        this.colorGUIHSV = new ColorGUI()
        {
            Title = "Color Value HSV",
            Value = this.colorValue,
            HSV   = true
        };

        this.enumGUI = new EnumGUI<CameraClearFlags>()
        {
            Title = "Enum Value",
            Value = this.enumValue
        };

        this.ipv4GUI = new IPv4GUI()
        {
            Title = "IPv4 Value",
            Value = this.ipv4Value,
        };
    }

    void OnGUI()
    {
        this.flexibleWindow.Show(() =>
        {
            this.colorValue    = this.colorGUI.Show();
            this.colorValueHSV = this.colorGUIHSV.Show();
            this.enumValue     = this.enumGUI.Show();
            this.ipv4Value     = this.ipv4GUI.Show();
        });
    }
}