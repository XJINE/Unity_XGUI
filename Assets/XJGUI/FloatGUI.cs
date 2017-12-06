namespace XJGUI
{
    public class FloatGUI : NumericGUI<float>
    {
        protected override float CorrectValue(float value)
        {
            value = base.CorrectValue(value);

            return (float)System.Math.Round(value, base.Decimals);
        }
    }
}