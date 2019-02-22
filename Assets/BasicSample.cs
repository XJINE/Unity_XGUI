using UnityEngine;
using XJGUI;

public class BasicSample : MonoBehaviour
{
    #region Field

    public bool       boolValue;
    public string     stringValue;
    public int        intValue;
    public float      floatValue;
    public Vector2    vector2Value;
    public Vector3    vector3Value;
    public Vector4    vector4Value;
    public Vector2Int vector2IntValue;
    public Vector3Int vector3IntValue;
    public Color      colorValue;
    public string     ipv4Value;
    public CameraType enumValue;

    private FlexibleWindow window;
    private TabPanel       tabPanel;
    private FoldoutPanel   foldoutPanel;
    private ScrollPanel    scrollPanel;

    private BoolGUI       boolGUI;
    private StringGUI     stringGUI;
    private IntGUI        intGUI;
    private FloatGUI      floatGUI;
    private Vector2GUI    vector2GUI;
    private Vector3GUI    vector3GUI;
    private Vector4GUI    vector4GUI;
    private Vector2IntGUI vector2IntGUI;
    private Vector3IntGUI vector3IntGUI;
    private ColorGUI      colorGUI;
    private IPv4GUI       ipv4GUI;
    private EnumGUI<CameraType> enumGUI;

    #endregion Field

    void Awake()
    {
        this.window = new FlexibleWindow() { Title = "Basic Sample" };

        this.tabPanel     = new TabPanel();
        this.foldoutPanel = new FoldoutPanel() { Title = "Click to Open/Close" };
        this.scrollPanel  = new ScrollPanel()  { MinHeight = 100 };

        this.boolGUI       = new BoolGUI()       { Title = "Bool"   };
        this.stringGUI     = new StringGUI()     { Title = "String" };
        this.intGUI        = new IntGUI()        { Title = "Int"    };
        this.floatGUI      = new FloatGUI()      { Title = "Float"  };
        this.vector2GUI    = new Vector2GUI()    { Title = "Vector2", Decimals = 1 };
        this.vector3GUI    = new Vector3GUI()    { Title = "Vector3", MinValue = Vector3.zero };
        this.vector4GUI    = new Vector4GUI()    { Title = "Vector4", WithSlider = false };
        this.vector2IntGUI = new Vector2IntGUI() { Title = "Vector2Int" };
        this.vector3IntGUI = new Vector3IntGUI() { Title = "Vector3Int" };
        this.colorGUI      = new ColorGUI()      { Title = "Color" };
        this.ipv4GUI       = new IPv4GUI()       { Title = "IPv4"  };
        this.enumGUI = new EnumGUI<CameraType>() { Title = "Enum"  };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.window.IsVisible = !this.window.IsVisible;
        }
    }

    void OnGUI()
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
                this.foldoutPanel.Show(() =>
                {
                    this.vector2Value = this.vector2GUI.Show();
                    this.vector3Value = this.vector3GUI.Show();
                    this.vector4Value = this.vector4GUI.Show();
                });

                this.vector2IntValue = this.vector2IntGUI.Show();
                this.vector3IntValue = this.vector3IntGUI.Show();
            }),
            new TabPanel.Func("Others", () =>
            {
                this.colorValue = this.colorGUI.Show();
                this.ipv4Value  = this.ipv4GUI.Show();
                this.enumValue  = this.enumGUI.Show();

                this.scrollPanel.Show(() =>
                {
                    GUILayout.Box("BOX", GUILayout.Width(300), GUILayout.Height(300));

                    XJGUILayout.Label("Long Text, Long Text, Long Text, Long Text, Long Text, Long Text"
                                    + "Long Text, Long Text, Long Text, Long Text, Long Text, Long Text"
                                    + "Long Text, Long Text, Long Text, Long Text, Long Text, Long Text",
                                    XJGUILayout.LabelOption.NoWrap | XJGUILayout.LabelOption.Bold);
                });
            }));
        });

        #pragma warning restore 0219
    }
}