namespace XJGUI
{
    public class IntGUI : NumericGUI<int>
    {
        // NOTE:
        // May be have to Notificate user cant decimals.

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