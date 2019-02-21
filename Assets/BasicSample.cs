using UnityEngine;
using XJGUI;

public class BasicSample : MonoBehaviour
{
    #region Field

    public bool    boolValue;
    public string  stringValue;
    public int     intValue;
    public float   floatValue;
    public Vector2 vector2Value;
    public Vector3 vector3Value;
    public Vector4 vector4Value;
    public Color   colorValue;
    public string  ipv4Value;

    private FlexibleWindow window;

    private TabPanel     tabPanel;
    private FoldoutPanel foldOutPanel;

    private BoolGUI    boolGUI;
    private StringGUI  stringGUI;
    private IntGUI     intGUI;
    private FloatGUI   floatGUI;
    private Vector2GUI vector2GUI;
    private Vector3GUI vector3GUI;
    private Vector4GUI vector4GUI;
    private ColorGUI   colorGUI;
    private IPv4GUI    ipv4GUI;

    #endregion Field

    void Awake()
    {
        this.window = new FlexibleWindow() { Title = "Basic Sample" };

        this.tabPanel = new TabPanel();

        this.foldOutPanel = new FoldoutPanel()
        {
            Title = "Click to Open/Close"
        };

        this.boolGUI    = new BoolGUI()    { Title = "Bool"   };
        this.stringGUI  = new StringGUI()  { Title = "String" };
        this.intGUI     = new IntGUI()     { Title = "Int"    };
        this.floatGUI   = new FloatGUI()   { Title = "Float"  };
        this.vector2GUI = new Vector2GUI() { Title = "Vector2", Decimals = 1 };
        this.vector3GUI = new Vector3GUI() { Title = "Vector3", MinValue = Vector3.zero };
        this.vector4GUI = new Vector4GUI() { Title = "Vector4", WithSlider = false };
        this.colorGUI   = new ColorGUI()   { Title = "Color" };
        this.ipv4GUI    = new IPv4GUI()    { Title = "IPv4"  };
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
                this.boolValue   = this.boolGUI.Show();
                this.stringValue = this.stringGUI.Show();
                this.intValue    = this.intGUI.Show();
                this.floatValue  = this.floatGUI.Show();
            }),
            new TabPanel.Func("Vector", () =>
            {
                this.foldOutPanel.Show(() =>
                {
                    this.vector2Value = this.vector2GUI.Show();
                    this.vector3Value = this.vector3GUI.Show();
                    this.vector4Value = this.vector4GUI.Show();
                });
            }),
            new TabPanel.Func("Advance", () =>
            {
                this.colorValue = this.colorGUI.Show();
                this.ipv4Value  = this.ipv4GUI.Show();
            }));
        });

        #pragma warning restore 0219
    }
}