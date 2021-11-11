using System;
using System.Collections.Generic;
using UnityEngine;
using XGUIs;

public class GUISample : MonoBehaviour
{
    // private FlexGUI<int[]> intArrayGUI = new();
    public int[] intValues;

    private IListGUI<int, int[]>      temp  = new IListGUI<int, int[]>();
    private IListGUI<int, IList<int>> temp2 = new IListGUI<int, IList<int>>();
    private ElementGUI<int[]>         temp3;

    private void Start()
    {
        // この変換に問題あり
        temp3 = temp2;

        // この変換は問題なし
        temp3 = temp;

        // この変換は問題なし
        // int[] array = new[] { 1,2 };
        // IList<int> ilist = array;

        // この変換で問題あり
        // int[] array = new[] {1, 2};
        // IList<int> list = array;
        // array = list;
    }

    private void OnGUI()
    {
        // intValues = temp2.Show(intValues);
        // intValues = intArrayGUI.Show(intValues);
    }
}
