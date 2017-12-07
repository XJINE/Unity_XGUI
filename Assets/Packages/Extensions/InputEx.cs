using UnityEngine;

/// <summary>
/// 入力に関する拡張機能を実装します。
/// </summary>
public static class InputEx
{
    #region Method

    /// <summary>
    /// 複数の GetKey と 1 つの GetKeyDown を検証します。
    /// </summary>
    /// <param name="keys">
    /// 最後の KeyCode を GetKeyDown として判定する複数の KeyCode 。
    /// </param>
    /// <returns>
    /// 最後のキーがちょうど入力されたタイミングで、すべてのキーが入力されているとき true 。
    /// それ以外のとき false 。
    /// </returns>
    public static bool GetKeysAndDown(params KeyCode[] keys)
    {
        int keyLength = keys.Length - 1;

        for (int i = 0; i < keyLength; i++)
        {
            if (!Input.GetKey(keys[i]))
            {
                return false;
            }
        }

        return Input.GetKeyDown(keys[keyLength]);
    }

    #endregion Method
}