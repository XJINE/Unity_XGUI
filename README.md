# Unity_XGUI

Utilities to make a lot of OnGUI. It is easy & fast.
Especially, ``FieldGUI`` automatically makes GUI from your class and struct.

## Import to Your Project

You can import this asset from UnityPackage.

- [XGUI.unitypackage](https://github.com/XJINE/Unity_XGUI/blob/master/XGUI.unitypackage)

## BasicSample

<img src="https://github.com/XJINE/Unity_XGUI/blob/master/screenshot01.png" width="100%" height="auto" />

BasicSample shows simply how to use. XGUI includes following type GUI.

<table>
<tr><td> int     </td><td> float     </td><td> string      </td><td> bool       </td><td> Enum       </td></tr>
<tr><td> Vector2 </td><td> Vector3   </td><td> Vector4     </td><td> Vector2Int </td><td> Vector3Int </td></tr>
<tr><td> Color   </td><td> Matrix4x4 </td><td> User Struct </td><td> User Class </td><td> IList<T>   </td></tr>
</table>

### FlexWindow, FoldoutPanel & TabPanel

``FlexWindow`` automatically scale its width and height when needed.
``FoldoutPanel`` & ``TabPanel`` are able to hide or group some GUIs.

## FieldGUI

<img src="https://github.com/XJINE/Unity_XGUI/blob/master/screenshot02.png" width="100%" height="auto" />

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