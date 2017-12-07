using UnityEngine;

public class InputExSample : MonoBehaviour
{
    #region Method

    /// <summary>
    /// 更新時に呼び出されます。
    /// </summary>
    protected virtual void Update()
    {
        if (InputEx.GetKeysAndDown(KeyCode.LeftControl, KeyCode.Return))
        {
            Debug.Log("KEY COMBINATION!");
        }
    }

    #endregion Method
}