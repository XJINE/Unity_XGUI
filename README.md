# Unity_XJGUI

Utilities to make a lot of OnGUI. It is easy & fast.
Especially, ``FieldGUI`` makes GUI from your field automatically.

## Import to Your Project

You can import this asset from UnityPackage.

- [XJGUI.unitypackage](https://github.com/XJINE/Unity_XJGUI/blob/master/XJGUI.unitypackage)

## BasicSample

<img src="https://github.com/XJINE/Unity_XJGUI/blob/master/screenshot.png" width="100%" height="auto" />

BasicSample shows simply how to use.

XJGUI able to generate following type GUI.

    int, float, string, bool,
    Vector2, Vector3, Vector4,
    Vector2Int, Vector3Int,
    Matrix4x4, Color, Enum, IPv4,

### FlexibleWindow, FoldoutPanel & TabPanel

``FlexibleWindow`` automatically expand its width/height when needed.
And it is able to hide and drag without any settings.

``FoldoutPanel`` & ``TabPanel`` are able to hide or group some GUIs.

## FieldGUI

<img src="https://github.com/XJINE/Unity_XJGUI/blob/master/screenshot.png" width="100%" height="auto" />

FieldGUI is main component in this utility.
FieldGUI automatically generates GUI from field,
and these GUI's settings are able to control from Attribute.

## NOTE

Previous version which includes IListGUI & SyncFunction are included in "Old" branch.