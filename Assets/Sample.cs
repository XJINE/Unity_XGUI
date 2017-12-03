using UnityEngine;
using XJGUI;

public class Sample : MonoBehaviour
{
    FlexibleWindow flexibleWindow;

    TabPanel tabPanel;

    IntGUI intGUI;
    //FloatGUI floatGUI;

    void Start()
    {
        this.flexibleWindow = new FlexibleWindow()
        {
            minWidth  = 300,
            minHeight = 300,
        };

        this.tabPanel = new TabPanel() { labels = new string[] { "Value", "Else" } };
        this.intGUI = new IntGUI() { title = "int Value", minValue = 0, maxValue = 100, };
        //this.floatGUI = new FloatGUI() { title = "float Value", Value = 50, minValue = 0, maxValue = 100, decimals = 3, };
    }

    void OnGUI()
    {
        this.flexibleWindow.Show(() =>
        {
            this.tabPanel.Show(() => 
            {
                Debug.Log(this.intGUI.Show());
                //Debug.Log(this.floatGUI.Show());
            });
        });
    }
}