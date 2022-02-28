# Unity_XGUI

Utilities to make a lot of OnGUI. It is easy & fast.

## Dependencies

You have to import following assets to use this asset.

- [Unity_ExpressionParser](https://github.com/XJINE/Unity_ExpressionParser)

## Various GUI

<img src="https://github.com/XJINE/Unity_XGUI/blob/main/screenshot01.png" width="100%" height="auto" />

XGUI includes following type GUI.

<table>
<tr><td> int     </td><td> float     </td><td> string      </td><td> bool       </td><td> Enum       </td></tr>
<tr><td> Vector2 </td><td> Vector3   </td><td> Vector4     </td><td> Vector2Int </td><td> Vector3Int </td></tr>
<tr><td> Color   </td><td> Matrix4x4 </td><td> IList&lt;T&gt; (List&lt;T&gt;, T[]) </td></tr>
</table>

## Various Panel

``FlexWindow`` automatically scale its width and height when needed.

``ScrollPanel`` shows scroll handle when needed.

``FoldoutPanel`` & ``TabPanel`` hide or group some GUIs.


## FlexGUI

FlexGUI provides common feels to make GUI.

Usually, it is needed to define corresponding GUI.

```csharp
BoolGUI   _boolGUI   = new ("Bool"  );
StringGUI _stringGUI = new ("String") { Width = 250 };
IntGUI    _intGUI    = new ("Int"   ) { MinValue = 0, MaxValue = 100 };
```

FlexGUI needs only a Type of the value.

```csharp
FlexGUI<bool>   _boolGUI   = new ("Bool"  );
FlexGUI<string> _stringGUI = new ("String") { Width = 250 };
FlexGUI<int>    _intGUI    = new ("Int"   ) { MinValue = 0, MaxValue = 100 };
```
