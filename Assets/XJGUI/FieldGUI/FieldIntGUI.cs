namespace XJGUI
{
    public class FieldIntGUI : FieldGUIBase<int>
    {
        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new IntGUI()
            {
                Value = (int)base.FieldInfo.GetValue(base.Data),
                Title = base.GUIAttribute.Title,
                BoldTitle = base.GUIAttribute.BoldTitle,
                MinValue = (int)base.GUIAttribute.MinValue,
                MaxValue = (int)base.GUIAttribute.MaxValue,
            };
        }

        #endregion Method
    }
}