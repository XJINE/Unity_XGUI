using System.Collections.Generic;
using UnityEngine;
using XGUI;

[System.Serializable]
public class SampleClassA
{
    public int          IntValue;
    // public float        FloatValue;
    // public int[]        IntArray;
    // public SampleClassB sampleB;
}

// [System.Serializable]
// public class SampleClassB
// {
//     public List<Vector2> VectorArray;
// }

public class FieldGUISample : MonoBehaviour
{
    public SampleClassA sampleA;
    private FieldGUI<SampleClassA> fieldGUI = new ();

    void Update()
    {
        sampleA = fieldGUI.Show(sampleA);
    }
}