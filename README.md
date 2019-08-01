# Unity_XJGUI

Utilities to make a lot of OnGUI. It is easy & fast.
Especially, ``FieldGUI`` automatically makes GUI from your class and struct.

## Import to Your Project

You can import this asset from UnityPackage.

- [XJGUI.unitypackage](https://github.com/XJINE/Unity_XJGUI/blob/master/XJGUI.unitypackage)

## BasicSample

<img src="https://github.com/XJINE/Unity_XJGUI/blob/master/screenshot01.png" width="100%" height="auto" />

BasicSample shows simply how to use. XJGUI includes following type GUI.

| int    | Vector2    | Color       |
| float  | Vector3    | Matrix4x4   |
| string | Vector4    | User Class  |
| bool   | Vector2Int | User Struct |
| Enum   | Vector3Int | IList<T>    |

### FlexWindow, FoldoutPanel & TabPanel

``FlexWindow`` automatically scale its width and height when needed.
``FoldoutPanel`` & ``TabPanel`` are able to hide or group some GUIs.

## FieldGUI

<img src="https://github.com/XJINE/Unity_XJGUI/blob/master/screenshot02.png" width="100%" height="auto" />

``FieldGUI`` is main component in this utility.
``FieldGUI`` automatically generates GUI from your class or struct field,
and these GUI's settings are able to control from the attributes.

It needs only a few steps like this.

```csharp
public SampleClass sampleClass = new SampleClass();
private FieldGUI fieldGUI;

fieldGUI = new FieldGUI(this.sampleClass);

void OnGUI()
{
    this.fieldGUI.Show();
}
```