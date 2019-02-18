using UnityEngine;
using XJGUI;

public class PanelGUITest : MonoBehaviour
{
    FlexibleWindow window;
    FoldoutPanel foldOutPanel;

    void Start()
    {
        this.window       = new FlexibleWindow() { Title = "WINDOW" };
        this.foldOutPanel = new FoldoutPanel() { Title = "FOLD_OUT" };
    }

    private void OnGUI()
    {
        this.window.Show(() =>
        {
            this.foldOutPanel.Show(() => { GUILayout.Label("TEST"); });
        });
    }
}