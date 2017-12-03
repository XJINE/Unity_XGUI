using UnityEngine;
using XJGUI;

public class Sample : MonoBehaviour
{
    FlexibleWindow flexibleWindow;

    TabPanel tabPanel;
    FoldoutPanel foldOutPanel;

    BoolGUI boolGUI;
    IntGUI intGUI;
    FloatGUI floatGUI;

    Vector2GUI vector2GUI;

    Toolbar toolBar;
    IPv4GUI ipv4GUI;

    void Start()
    {
        this.flexibleWindow = new FlexibleWindow()
        {
            minWidth  = 300,
            minHeight = 300,
        };

        //this.tabPanel = new TabPanel() { labels = new string[] { "Value", "Else" } };

        //this.foldOutPanel = new FoldoutPanel() { title = "Vector", boldTitle = true, Value = false};

        //this.boolGUI = new BoolGUI() { title = "Bool Value", boldTitle = true, Value = false};

        //this.intGUI = new IntGUI() { title = "int Value", minValue = 0, maxValue = 100, };

        //this.floatGUI = new FloatGUI() { title = "float Value", Value = 50, minValue = 0, maxValue = 100, decimals = 3, };

        this.vector2GUI = new Vector2GUI() { Value = new Vector2(0.5f, 0.5f), title = "Vector2 Value", decimals = 1, minValue = new Vector2(-1, -1), maxValue = new Vector2(1, 1) };

        //this.toolBar = new Toolbar() { title = "Toolbar", labels = new string[] { "A", "B", "C" } };

        //this.ipv4GUI = new IPv4GUI() { title = "IPV4", Value = "127.0.0.1", };
    }

    void OnGUI()
    {
        this.flexibleWindow.Show(() =>
        {
            this.vector2GUI.Show();

            //this.tabPanel.Show(() => 
            //{
            //    this.boolGUI.Show();
            //    this.intGUI.Show();
            //    this.floatGUI.Show();

            //    this.foldOutPanel.Show(() => 
            //    {
            //        this.floatGUI.Show();
            //    });

            //    this.toolBar.Show();
            //    this.ipv4GUI.Show();
            //});
        });
    }
}