﻿using UnityEngine;
using XJGUI;

[System.Serializable]
public struct UserStruct
{
    public Vector3 vector3Value;
    public int     intValue;
}

public class FieldGUISample1 : MonoBehaviour
{
    #region Field

    public bool   boolValue;
    public int    intValue;
    public string stringValue;
    [GUIInfo(Hide = true)]
    public string hideValue;

    [Header("Vector")]

    public Vector2 vector2Value;
    public Vector3 vector3Value;
    [GUIInfo(Min = 1, Max = 2)]
    public Vector4 vector4Value;
    [GUIInfo(Title = "V2I")]
    public Vector2Int vector2IntValue;
    public Vector3Int vector3IntValue;

    [Header("Others")]

    public Color colorValue;
    public Matrix4x4 matrixValue;
    [GUIInfo(Width = 300)]
    public CameraType cameraTypeA;
    public CameraType cameraTypeB;
    [GUIInfo(IPv4 = true)]
    public string ipV4Value;

    //public UserStruct userStructValue;

    private FlexWindow window;
    private FieldGUI<FieldGUISample1> fieldGUI;

    #endregion Field

    #region Method

    private void Start()
    {
        this.window = new FlexWindow();
        this.fieldGUI = new FieldGUI<FieldGUISample1>();
    }

    private void OnGUI()
    {
        this.window.Show(() =>
        {
            this.fieldGUI.Show(this);
        });
    }

    #endregion Method
}