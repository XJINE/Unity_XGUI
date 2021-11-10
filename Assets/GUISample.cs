using UnityEngine;
using XGUIs;

public class GUISample : MonoBehaviour
{
    private XGUI<float>   floatGUI  = new ("FLOAT", 0, 999f, 4);
    private XGUI<int>     intGUI    = new ("INT", -3, 3);
    private XGUI<Vector2> vectorGUI = new ("Vector", new Vector2(-3f, -3f), new Vector2(3f, 3f), 2);

    public float floatValue = 0;
    public int intValue = 0;
    public Vector2 vectorValue = new Vector2();

    private void OnGUI()
    {
        floatValue  = floatGUI.Show(floatValue);
        intValue    = intGUI.Show(intValue);
        vectorValue = vectorGUI.Show(vectorValue);
        vectorGUI.Slider = false;
    }
}
