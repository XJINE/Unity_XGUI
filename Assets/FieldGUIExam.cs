using System.Collections.Generic;
using UnityEngine;
using XJGUI;

public class FieldGUIExam : MonoBehaviour
{
    #region Field

    public FlexibleWindow flexWindow = new FlexibleWindow();
    public FieldGUI fieldGUI;
    public FieldGUISync fieldGUISync;

    public List<CameraClearFlags>enums = new List<CameraClearFlags>
    { CameraClearFlags.Color, CameraClearFlags.Color, CameraClearFlags.Color };

    #endregion Field

    void Start()
    {
        this.fieldGUI = new FieldGUI() { Value = this };
        this.fieldGUISync.Add(this.fieldGUI);
    }

    void Update()
    {
    }

    void OnGUI()
    {
        this.flexWindow.Show(() =>
        {
            this.fieldGUI.Show();
        });
    }
}