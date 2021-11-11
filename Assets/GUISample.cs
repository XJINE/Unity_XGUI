using System;
using System.Collections.Generic;
using UnityEngine;
using XGUI;

public class GUISample : MonoBehaviour
{
    private FlexGUI<int[]>       intArrayGUI     = new("INT_ARRAY");
    private FlexGUI<List<int>>   intListGUI      = new("INT_LIST");
    private FlexGUI<List<int[]>> intArrayListGUI = new("INT_ARRAY_List");
    
    public int[] intValues;
    public List<int> intList;
    public List<int[]> intArrayList;

    // private IListGUI<int, int[]>      temp  = new IListGUI<int, int[]>();
    // private IListGUI<int, IList<int>> temp2 = new IListGUI<int, IList<int>>();
    // private ElementGUI<int[]>         temp3;

    private void Start()
    {
        // IListGUI<int, IList<int>> listGUI = new IListGUI<int, IList<int>>();
        // ElementGUI<List<int>> elementGUI = listGUI;

        // List<int> intList = new List<int>();
        // IList<int> IIntList = intList;
        // intList = IIntList;

        intArrayList = new List<int[]>
        {
            new[] {1, 2, 3, 4, 5},
            new[] {6, 7, 8, 9, 10}
        };
    }

    private void OnGUI()
    {
        intValues = intArrayGUI.Show(intValues);
        intList = intListGUI.Show(intList);
        intArrayList = intArrayListGUI.Show(intArrayList);
    }
}
