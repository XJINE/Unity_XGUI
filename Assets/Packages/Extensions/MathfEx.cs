public static class MathfEx
{
    /// <summary>
    /// 符号もしくは 0 を返します。
    /// </summary>
    /// <param name="value">
    /// 符号もしくは 0 を検出する値。
    /// </param>
    /// <returns>
    /// 正の値のとき 1, 負の値のとき -1, 0 のとき 0 。
    /// </returns>
    public static int SignOrZero(float value)
    {
        if (value < 0)
        {
            return -1;
        }
        else if (value > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}