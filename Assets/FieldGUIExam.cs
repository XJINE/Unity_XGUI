using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class FieldGUIExam : MonoBehaviour
{
    #region Field

    public FlexibleWindow flexWindow = new FlexibleWindow();
    public FieldGUI fieldGUI;
    public FieldGUISync fieldGUISync;

    public List<bool>boolList = new List<bool> { true, false, false };

    #endregion Field

    void Start()
    {
        this.fieldGUI = new FieldGUI() { Value = this };
        this.fieldGUISync.Add(this.fieldGUI);
    }

    void OnGUI()
    {
        this.flexWindow.Show(() =>
        {
            this.fieldGUI.Show();
        });
    }
}