# Unity_XJGUI

Utilities to make a lot of OnGUI. It is easy & fast.
Especially "FieldGUI" makes GUIs from your field.

Step by step samples are included.

## Standard Samples

![](https://github.com/XJINE/Unity_XJGUI/blob/master/Screenshots/01.png)

XJGUI able to generate following type GUI.

    int, float, string, bool, Vector2, Vector3, Vector4,
    Color, Enum, IPv4, and these array or List<>.

## FlexibleWindow, Foldout & Tab Panel

<img src="https://github.com/XJINE/Unity_XJGUI/blob/master/Screenshots/02.gif" width="100%" height="auto" />

FlexibleWindow automatically expand its width/height when needed. And easy to hide and drag.

Foldout & Tab panel able to hide or group GUIs.

## FieldGUI

![](https://github.com/XJINE/Unity_XJGUI/blob/master/Screenshots/03.png)

FieldGUI is main component in this utility.
FieldGUI automatically generates GUI from field,
and these GUI's settings are able to control from Attribute.

## FieldGUISync

![](https://github.com/XJINE/Unity_XJGUI/blob/master/Screenshots/04.png)

FieldGUI able to sync with clients through UNET.

NOTE: There are `Packages/CustomNetworkManager/` in resources, but XJGUI not depends on these.
These are included for sample.
