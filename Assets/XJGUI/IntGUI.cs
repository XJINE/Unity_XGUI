namespace XJGUI
{
    public class IntGUI : NumericGUI<int>
    {
        public override int Decimals
        {
            get
            {
                return 0;
            }
            set
            {
                base.decimals = 0;
            }
        }
    }
}