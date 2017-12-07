using UnityEngine;

public class HSVColorTest : MonoBehaviour
{
    #region Field

    /// <summary>
    /// オブジェクトの描画に利用するレンダラ。
    /// </summary>
    protected new Renderer renderer;

    /// <summary>
    /// 現在の色。
    /// </summary>
    public HSVColor hsvColor;

    /// <summary>
    /// 変化先の色。
    /// </summary>
    public HSVColor lerpHSVColor;

    /// <summary>
    /// 変化率。
    /// </summary>
    public float lerpRatio = 0;

    /// <summary>
    /// 変化にかかる時間。
    /// </summary>
    public float lerpDurationSec = 5;

    /// <summary>
    /// 変化にかかる時間のカウンタ。
    /// </summary>
    protected float lerpDurationSecCounter = 0;

    #endregion Field

    #region Method

    /// <summary>
    /// 開始時に呼び出されます。
    /// </summary>
    protected virtual void Start ()
    {
        this.renderer     = GetComponent<Renderer>();
        this.hsvColor     = new HSVColor(Color.red);
        this.lerpHSVColor = new HSVColor(Color.green);
    }

    /// <summary>
    /// 更新時に呼び出されます。
    /// </summary>
    protected virtual void Update ()
    {
        this.lerpDurationSecCounter += Time.deltaTime;
        this.lerpRatio = Mathf.Min(1, this.lerpDurationSecCounter / this.lerpDurationSec);

        this.renderer.material.color =
            this.hsvColor.LerpH(this.lerpHSVColor.h, this.lerpRatio).ToRGBColor();

        if (this.lerpRatio == 1)
        {
            this.hsvColor     = this.lerpHSVColor;
            this.lerpHSVColor = new HSVColor(HSVColorLibrary.GetRandomHueColors360Standard());

            this.lerpDurationSecCounter = 0;
        }
    }

    #endregion Method
}