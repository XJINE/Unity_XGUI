using UnityEngine;

/// <summary>
/// HSV で表現される色の構造体です。
/// </summary>
[System.Serializable]
public struct HSVColor
{
    #region Field

    /// <summary>
    /// Hue.
    /// </summary>
    public float h;

    /// <summary>
    /// Satulatin.
    /// </summary>
    public float s;

    /// <summary>
    /// Value.
    /// </summary>
    public float v;

    /// <summary>
    /// Alpha.
    /// </summary>
    public float a;

    /// <summary>
    /// 変換用の一時的な変数。
    /// </summary>
    private static float tempH, tempS, tempV;

    #endregion Field

    #region Constructor

    /// <summary>
    /// 新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="rgbColor">
    /// HSV Color に変換する RGB Color.
    /// </param>
    public HSVColor(Color rgbColor)
    {
        Color.RGBToHSV(rgbColor, out tempH, out tempS, out tempV);

        this.h = tempH;
        this.s = tempS;
        this.v = tempV;
        this.a = rgbColor.a;
    }

    #endregion Constructor

    #region Method

    /// <summary>
    /// HSV パラメータを CSV 形式の文字列にして返します。
    /// </summary>
    /// <returns>
    /// CSV 文字列。
    /// </returns>
    public override string ToString()
    {
        return h + ", " + s + ", " + v + ", " + a;
    }

    /// <summary>
    /// RGB Color を取得します。
    /// </summary>
    /// <returns>
    /// RGB Color.
    /// </returns>
    public Color ToRGBColor()
    {
        Color rgbColor = Color.HSVToRGB(this.h, this.s, this.v);
        rgbColor.a = this.a;

        return rgbColor;
    }

    /// <summary>
    /// GrayScale Color にします。
    /// </summary>
    /// <returns>
    /// GrayScale Color にします。
    /// </returns>
    public HSVColor ToGrayScale()
    {
        return new HSVColor()
        {
            h = this.h,
            s = 0,
            v = this.v,
            a = this.a
        };
    }

    /// <summary>
    /// Lerp した結果を取得します。
    /// </summary>
    /// <param name="to">
    /// 最終的な値。
    /// </param>
    /// <param name="ratio">
    /// 変化率。
    /// </param>
    /// <returns>
    /// Lerp した結果。
    /// </returns>
    public HSVColor Lerp(HSVColor to, float ratio)
    {
        return new HSVColor()
        {
            h = Mathf.Lerp(this.h, to.h, ratio),
            s = Mathf.Lerp(this.h, to.s, ratio),
            v = Mathf.Lerp(this.h, to.v, ratio),
            a = Mathf.Lerp(this.h, to.a, ratio)
        };
    }

    /// <summary>
    /// H 成分を Lerp した結果を取得します。
    /// </summary>
    /// <param name="to">
    /// 最終的な値。
    /// </param>
    /// <param name="ratio">
    /// 変化率。
    /// </param>
    /// <returns>
    /// Lerp した結果。
    /// </returns>
    public HSVColor LerpH(float to, float ratio)
    {
        return new HSVColor()
        {
            h = Mathf.Lerp(this.h, to, ratio),
            s = this.s,
            v = this.v,
            a = this.a
        };
    }

    /// <summary>
    /// S 成分を Lerp した結果を取得します。
    /// </summary>
    /// <param name="to">
    /// 最終的な値。
    /// </param>
    /// <param name="ratio">
    /// 変化率。
    /// </param>
    /// <returns>
    /// Lerp した結果。
    /// </returns>
    public HSVColor LerpS(float to, float ratio)
    {
        return new HSVColor()
        {
            h = this.h,
            s = Mathf.Lerp(this.s, to, ratio),
            v = this.v,
            a = this.a
        };
    }

    /// <summary>
    /// V 成分を Lerp した結果を取得します。
    /// </summary>
    /// <param name="to">
    /// 最終的な値。
    /// </param>
    /// <param name="ratio">
    /// 変化率。
    /// </param>
    /// <returns>
    /// Lerp した結果。
    /// </returns>
    public HSVColor LerpV(float to, float ratio)
    {
        return new HSVColor()
        {
            h = this.h,
            s = this.s,
            v = Mathf.Lerp(this.v, to, ratio),
            a = this.a
        };
    }

    #endregion Method
}