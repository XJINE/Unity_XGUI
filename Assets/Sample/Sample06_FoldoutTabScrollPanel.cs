using UnityEngine;
using XJGUI;

public class Sample06_FoldoutTabScrollPanel : MonoBehaviour
{
    private FlexibleWindow flexibleWindow;

    private TabPanel tabPanel;
    private FoldoutPanel foldoutPanel;
    private ScrollPanel scrollPanel;

    private IntGUI intGUI;
    private FloatGUI floatGUI;
    private StringGUI stringGUI;
    private BoolGUI boolGUI;

    private Vector2GUI vector2GUI;
    private Vector3GUI vector3GUI;
    private Vector4GUI vector4GUI;

    private IPv4GUI ipv4GUI;
    private ColorGUI colorGUI;

    void Start()
    {
        this.flexibleWindow = new FlexibleWindow();
        this.flexibleWindow.MaxHeight = 200;

        this.tabPanel = new TabPanel()
        {
            Labels = new string[] { "Basic" , "Vectors", "Others" }
        };

        this.foldoutPanel = new FoldoutPanel()
        {
            Title = "Vectors"
        };

        this.scrollPanel = new ScrollPanel()
        {
            MinWidth = 500,
            MinHeight = 150,
        };

        this.intGUI = new IntGUI() { Title = "Int Value" };
        this.floatGUI = new FloatGUI() { Title = "Float Value" };
        this.stringGUI = new StringGUI() { Title = "String Value" };
        this.boolGUI = new BoolGUI() { Title = "Bool Value" };

        this.vector2GUI = new Vector2GUI() { Title = "Vector2 Value" };
        this.vector3GUI = new Vector3GUI() { Title = "Vector3 Value" };
        this.vector4GUI = new Vector4GUI() { Title = "Vector4 Value" };

        this.ipv4GUI = new IPv4GUI() { Title = "IPv4 Value" };
        this.colorGUI = new ColorGUI() { Title = "Color Value" };
    }

    void OnGUI()
    {
        this.flexibleWindow.Show(() =>
        {
            this.tabPanel.Show(ShowBasicGUIs, ShowVectorGUIs, ShowOtherGUIs);
        });
    }

    private void ShowBasicGUIs()
    {
        this.intGUI.Show();
        this.floatGUI.Show();
        this.stringGUI.Show();
        this.boolGUI.Show();
    }

    private void ShowVectorGUIs()
    {
        this.foldoutPanel.Show(() => 
        {
            this.scrollPanel.Show(() => 
            {
                this.vector2GUI.Show();
                this.vector3GUI.Show();
                this.vector4GUI.Show();
            });
        });
    }

    private void ShowOtherGUIs()
    {
        this.ipv4GUI.Show();
        this.colorGUI.Show();
    }
}