using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class ValuesSample : MonoBehaviour
{
    #region Field

    FlexibleWindow flexibleWindow;

    IntsGUI intsGUI;

    public List<int> intList;

    #endregion Field

    void Start ()
    {
        this.flexibleWindow = new FlexibleWindow()
        {
            MinWidth = 300,
            MinHeight = 300,
        };

        this.intsGUI = new IntsGUI() { Title = "IntsGUI" };

        //this.intList = new List<int>();

        this.intsGUI.Value = this.intList;
    }

    void OnGUI()
    {
        this.flexibleWindow.Show(() =>
        {
            this.intsGUI.Show();
        });
    }
}