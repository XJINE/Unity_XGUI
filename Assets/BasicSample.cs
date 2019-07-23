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
    public Matrix4x4  matrixValue;
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
    private Matrix4x4GUI  matrixGUI;
    private IPv4GUI       ipv4GUI;
    private EnumGUI<CameraType> enumGUI;

    #endregion Field

    void Awake()
    {
        XJGUILayout.DefaultMinValueVector2Int = new Vector2Int(-999, -999);
        XJGUILayout.DefaultMaxValueVector2Int = new Vector2Int(999, 999);

        this.window = new FlexibleWindow("Basic Sample");

        this.tabPanel     = new TabPanel    ();
        this.foldoutPanel = new FoldoutPanel("Click to Open / Close");
        this.scrollPanel  = new ScrollPanel () { MinHeight = 100 };

        this.boolGUI       = new BoolGUI      ("Bool"        );
        this.stringGUI     = new StringGUI    ("String"      ) { FieldWidth = 250 };
        this.intGUI        = new IntGUI       ("Int"         );
        this.floatGUI      = new FloatGUI     ("Float", -1, 1);
        this.vector2GUI    = new Vector2GUI   ("Vector2"     ) { Decimals = 1 };
        this.vector3GUI    = new Vector3GUI   ("Vector3"     ) { MinValue = Vector3.zero };
        this.vector4GUI    = new Vector4GUI   ("Vector4"     ) { WithSlider = false };
        this.vector2IntGUI = new Vector2IntGUI("Vector2Int"  );
        this.vector3IntGUI = new Vector3IntGUI("Vector3Int", Vector3Int.zero, Vector3Int.one);
        this.colorGUI      = new ColorGUI     ("Color"       );
        this.matrixGUI     = new Matrix4x4GUI ("Matrix4x4"   );
        this.ipv4GUI       = new IPv4GUI      ("IPv4"        );
        this.enumGUI = new EnumGUI<CameraType>("Enum"        );
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
        Debug.Log(this.floatValue);
        #pragma warning disable 0219

        GUILayout.Label("Press [Return] to show/hide window.");

        this.window.Show(() =>
        {
            this.tabPanel.Show
            (new TabPanel.Func("Basic", () =>
            {
                this.boolValue = this.boolGUI.Show(this.boolValue);
                this.stringValue = this.stringGUI.Show(this.stringValue);
                this.intValue = this.intGUI.Show(this.intValue);
                this.floatValue = this.floatGUI.Show(this.floatValue);
            }),
            new TabPanel.Func("Vector & Matrix", () =>
            {
                this.foldoutPanel.Show(() =>
                {
                    this.vector2Value = this.vector2GUI.Show(this.vector2Value);
                    this.vector3Value = this.vector3GUI.Show(this.vector3Value);
                    this.vector4Value = this.vector4GUI.Show(this.vector4Value);
                });

                this.vector2IntValue = this.vector2IntGUI.Show(this.vector2IntValue);
                this.vector3IntValue = this.vector3IntGUI.Show(this.vector3IntValue);

                this.matrixValue = this.matrixGUI.Show(this.matrixValue);
            }),
            new TabPanel.Func("Others", () =>
            {
                this.colorValue = this.colorGUI.Show(this.colorValue);
                this.ipv4Value = this.ipv4GUI.Show(this.ipv4Value);
                this.enumValue = this.enumGUI.Show(this.enumValue);

                this.scrollPanel.Show(() =>
                {
                    GUILayout.Box("BOX", GUILayout.Width(300), GUILayout.Height(300));

                    XJGUILayout.Label("Long Text, Long Text, Long Text, Long Text, Long Text, Long Text"
                                    + "Long Text, Long Text, Long Text, Long Text, Long Text, Long Text"
                                    + "Long Text, Long Text, Long Text, Long Text, Long Text, Long Text",
                                       XJGUILayout.LabelOption.NoWrap
                                     | XJGUILayout.LabelOption.Bold);
                });
            }));
        });

        #pragma warning restore 0219
    }
}