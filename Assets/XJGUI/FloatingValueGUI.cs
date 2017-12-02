namespace XJGUI
{
    public abstract class FloatingValueGUI <T> : ValueGUI <T> where T : struct
    {
        public int decimalPlaces = 2;
    }
}