//using System;
//using UnityEngine;
//using XJ.Unity3D.XJGUI;

//public class Sample : MonoBehaviour
//{
//    #region Field

//    private FlexibleWindow flexibleWindow;

//    private TabPanel tabPanel;

//    private IntGUI intGUI1;
//    private IntGUI intGUI2;

//    private FloatGUI floatGUI1;
//    private FloatGUI floatGUI2;

//    private Vector2GUI vector2GUI1;
//    private Vector2GUI vector2GUI2;

//    private Vector3GUI vector3GUI1;
//    private Vector3GUI vector3GUI2;

//    private Vector4GUI vector4GUI1;
//    private Vector4GUI vector4GUI2;

//    private BoolGUI boolGUI;
//    private Toolbar toolbar;
//    private IPv4GUI ipv4GUI;

//    #endregion Field

//    void Awake()
//    {
//        this.flexibleWindow = new FlexibleWindow("Sample", 0, 0, 200, 100, 500, 500, true, true);

//        this.tabPanel = new TabPanel(null, false, 0, "Value", "Vector","Others");

//        this.intGUI1 = new IntGUI("int value (1)", false, 0, -10, 10, 50, false);
//        this.intGUI2 = new IntGUI("int value (2)", true, 0, -10, 10, 0, true);

//        this.floatGUI1 = new FloatGUI("float value (1)", false, 0.01f, -10, 10, 2, 50, false);
//        this.floatGUI2 = new FloatGUI("float value (2)", true, 0.01f, -10, 10, 3, 0, true);

//        this.vector2GUI1 = new Vector2GUI("Vector2 (1)", false, null, new Vector2(-10, -10), new Vector2(10, 10), 2, 50, false, true);
//        this.vector2GUI2 = new Vector2GUI("Vector2 (2)", true, null, new Vector2(-10, -10), new Vector2(10, 10), 3, 50, true, true);

//        this.vector3GUI1 = new Vector3GUI("Vector3 (1)", false, null, new Vector3(-10, -10, -10), new Vector3(10, 10, 10), 2, 50, false, true);
//        this.vector3GUI2 = new Vector3GUI("Vector3 (2)", true, null, new Vector3(-10, -10, -10), new Vector3(10, 10, 10), 3, 50, true, true);

//        this.vector4GUI1 = new Vector4GUI("Vector4 (1)", false, null, new Vector4(-10, -10, -10, -10), new Vector4(10, 10, 10, 10), 2, 50, false, true);
//        this.vector4GUI2 = new Vector4GUI("Vector4 (2)", true, null, new Vector4(-10, -10, -10, -10), new Vector4(10, 10, 10, 10), 3, 50, true, false);

//        this.ipv4GUI = new IPv4GUI("IPV4", true, "127.0.0.1");
//        this.boolGUI = new BoolGUI("bool", true, true);
//        this.toolbar = new Toolbar("Toolbar", true, 0, "Label1", "Label2", "Label3");
//    }

//    protected virtual void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.C))
//        {
//            this.flexibleWindow.IsVisible = !this.flexibleWindow.IsVisible;
//        }
//    }

//    void OnGUI()
//    {
//        this.flexibleWindow.Show(ControlWindow);
//    }

//    private void ControlWindow(int windowId)
//    {
//        XJ.Unity3D.XJGUI.GUILayout.BoldLabel("XJ.Unity3D.GUILayout.Sample");

//        this.tabPanel.Show(new Action[] { ValueSettings,
//                                          VectorSettings,
//                                          OtherSettings });
//    }

//    private void ValueSettings()
//    {
//        this.intGUI1.Show();
//        this.intGUI2.Show();

//        this.floatGUI1.Show();
//        this.floatGUI2.Show();
//    }

//    private void VectorSettings()
//    {
//        this.vector2GUI1.Show();
//        this.vector2GUI2.Show();

//        this.vector3GUI1.Show();
//        this.vector3GUI2.Show();

//        this.vector4GUI1.Show();
//        this.vector4GUI2.Show();
//    }

//    private void OtherSettings()
//    {
//        this.ipv4GUI.Show();
//        this.boolGUI.Show();
//        this.toolbar.Show();
//    }
//}