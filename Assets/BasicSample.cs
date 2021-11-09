using System.Collections.Generic;
using UnityEngine;
using XGUI;

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

    public int[] intArrayValue;
    public List<UserStruct> structListValue;

    public List<List<UserStruct>> structListListValue = new List<List<UserStruct>>()
    {
        new List<UserStruct>() { new UserStruct() },
        new List<UserStruct>() { }
    };

    public List<CameraType>[] enumListArrayValue = new List<CameraType>[]
    {
        new List<CameraType>() { CameraType.Game, CameraType.Reflection },
        new List<CameraType>() { CameraType.VR,   CameraType.SceneView  }
    };

    public CameraType  enumSelect;
    public float       floatListSelect;
    public List<float> floatListValue = new List<float>() { 0, 1.414f, 2.236f, 3.141f };
    public string      stringArraySelect;
    public string[]    stringArrayValue = new string[] { "Alpha", "Bravo", "Charlie",
                                                         "Delta", "Echo",  "Foxtrot",
                                                         "Golf",  "Hotel", "India",
                                                         "Juliet" };

    private FlexWindow   window;
    private TabPanel     tabPanel;
    private FoldoutPanel foldoutPanel;
    private ScrollPanel  scrollPanel;

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
    private EnumGUI<CameraType> enumGUI;

    private IListGUI<int[]>                  intArrayGUI;
    private IListGUI<List<UserStruct>>       structListGUI;
    private IListGUI<List<List<UserStruct>>> structListListGUI;
    private IListGUI<List<CameraType>[]>     enumListArrayGUI;
    private Selection<float>                 floatListSelection;
    private Selection<string>                stringArraySelection;
    private Selection<CameraType>            enumSelection;

    #endregion Field

    #region Method

    void Awake()
    {
        XGUILayout.DefaultMinValueVector2Int = new Vector2Int(-999, -999);
        XGUILayout.DefaultMaxValueVector2Int = new Vector2Int(999, 999);

        this.window = new FlexWindow("Basic Sample");

        this.tabPanel     = new TabPanel    ();
        this.foldoutPanel = new FoldoutPanel("Click to Open / Close");
        this.scrollPanel  = new ScrollPanel () { MinHeight = 100 };

        this.boolGUI       = new BoolGUI      ("Bool"        );
        this.stringGUI     = new StringGUI    ("String"      ) { Width = 250 };
        this.intGUI        = new IntGUI       ("Int"         );
        this.floatGUI      = new FloatGUI     ("Float", -1, 1);
        this.vector2GUI    = new Vector2GUI   ("Vector2"     ) { Digits = 1 };
        this.vector3GUI    = new Vector3GUI   ("Vector3"     ) { MinValue = Vector3.zero };
        this.vector4GUI    = new Vector4GUI   ("Vector4"     ) { Slider = false };
        this.vector2IntGUI = new Vector2IntGUI("Vector2Int"  );
        this.vector3IntGUI = new Vector3IntGUI("Vector3Int", Vector3Int.zero, Vector3Int.one);
        this.colorGUI      = new ColorGUI     ("Color"       );
        this.matrixGUI     = new Matrix4x4GUI ("Matrix4x4"   );
        this.enumGUI       = new EnumGUI<CameraType> ("Enum" );

        this.intArrayGUI       = new IListGUI<int[]>("Int[]");
        this.structListGUI     = new IListGUI<List<UserStruct>>("List<UserStruct>");
        this.structListListGUI = new IListGUI<List<List<UserStruct>>>("List<List<UserStruct>>");
        this.enumListArrayGUI  = new IListGUI<List<CameraType>[]>("List<CameraType>[]");

        this.enumSelection         = new Selection<CameraType>("Enum");
        this.floatListSelection    = new Selection<float>("Toolbar<float>");
        this.stringArraySelection  = new Selection<string>("SelectionGrid<string>");
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
            (("Basic", () =>
            {
                this.boolValue   = this.boolGUI.Show(this.boolValue);
                this.stringValue = this.stringGUI.Show(this.stringValue);
                this.intValue    = this.intGUI.Show(this.intValue);
                this.floatValue  = this.floatGUI.Show(this.floatValue);
            }),
            ("Vector & Matrix", () =>
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
            ("Others", () =>
            {
                this.colorValue = this.colorGUI.Show(this.colorValue);
                this.enumValue = this.enumGUI.Show(this.enumValue);

                this.scrollPanel.Show(() =>
                {
                    GUILayout.Box("BOX", GUILayout.Width(300), GUILayout.Height(300));

                    XGUILayout.Label("Long Text, Long Text, Long Text, Long Text, Long Text, Long Text"
                                   + "Long Text, Long Text, Long Text, Long Text, Long Text, Long Text"
                                   + "Long Text, Long Text, Long Text, Long Text, Long Text, Long Text",
                                      XGUILayout.LabelOption.NoWrap
                                    | XGUILayout.LabelOption.Bold);
                });
            }),
            ("Array", () =>
            {
                this.intArrayGUI.Show(this.intArrayValue);
                this.structListGUI.Show(this.structListValue);
                this.structListListGUI.Show(this.structListListValue);
                this.enumListArrayGUI.Show(this.enumListArrayValue);

                this.enumSelect        = this.enumSelection.Show(this.enumSelect);
                this.floatListSelect   = this.floatListSelection.Show(this.floatListSelect, this.floatListValue);
                this.stringArraySelect = this.stringArraySelection.Show(this.stringArraySelect, this.stringArrayValue, 3);
            }));
        });

        #pragma warning restore 0219
    }

    #endregion Method
}