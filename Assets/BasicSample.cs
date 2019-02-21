using UnityEngine;
using XJGUI;

public class BasicSample : MonoBehaviour
{
    #region Field

    FlexibleWindow window;

    TabPanel     tabPanel;
    FoldoutPanel foldOutPanel;

    BoolGUI    boolGUI;
    StringGUI  stringGUI;
    IntGUI     intGUI;
    FloatGUI   floatGUI;
    Vector2GUI vector2GUI;
    Vector3GUI vector3GUI;
    Vector4GUI vector4GUI;
    ColorGUI   colorGUI;
    IPv4GUI    ipv4GUI;

    #endregion Field

    void Awake()
    {
        this.window = new FlexibleWindow() { Title = "Basic Sample" };

        this.tabPanel = new TabPanel();

        this.foldOutPanel = new FoldoutPanel()
        {
            Title = "Click to Open/Close"
        };

        this.boolGUI    = new BoolGUI()    { Title = "Bool" };
        this.stringGUI  = new StringGUI()  { Title = "String" };
        this.intGUI     = new IntGUI()     { Title = "Int" };
        this.floatGUI   = new FloatGUI()   { Title = "Float" };
        this.vector2GUI = new Vector2GUI() { Title = "Vector2", Decimals = 1 };
        this.vector3GUI = new Vector3GUI() { Title = "Vector3", MinValue = Vector3.zero };
        this.vector4GUI = new Vector4GUI() { Title = "Vector4", WithSlider = false };
        this.colorGUI   = new ColorGUI()   { Title = "Color" };
        this.ipv4GUI    = new IPv4GUI()    { Title = "IPv4" };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.window.IsVisible = !this.window.IsVisible;
        }
    }

    private void OnGUI()
    {
        #pragma warning disable 0219

        GUILayout.Label("Press [Return] to show/hide window.");

        this.window.Show(() =>
        {
            this.tabPanel.Show
            (new TabPanel.Func("Basic", () =>
            {
                bool   boolValue   = this.boolGUI.Show();
                string stringValue = this.stringGUI.Show();
                int    intValue    = this.intGUI.Show();
                float  floatValue  = this.floatGUI.Show();
            }),
            new TabPanel.Func("Basic", () =>
            {
                this.foldOutPanel.Show(() =>
                {
                    Vector2 vector2Value = this.vector2GUI.Show();
                    Vector3 vector3Value = this.vector3GUI.Show();
                    Vector4 vector4Value = this.vector4GUI.Show();
                });
            }),
            new TabPanel.Func("Basic", () =>
            {
                Color colorValue = this.colorGUI.Show();
                string ipv4Value = this.ipv4GUI.Show();
            }));
        });

        #pragma warning restore 0219
    }
}