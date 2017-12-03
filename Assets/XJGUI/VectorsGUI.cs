using System.Collections.Generic;

namespace XJGUI
{
    public abstract class VectorsGUI<T> : ValuesGUI<T> where T : struct
    {
        #region Property

        public int DecimalPlaces { get; set; }

        public virtual bool Horizontal { get; set; }

        #endregion Property

        #region Method

        public override ICollection<T> Show()
        { 
            XJGUILayout.VerticalLayout(() =>
            {
                if (base.Title != null)
                {
                    this.foldOutPanel.Show(delegate ()
                    {
                        ShowComponentGUI();
                    });
                }
                else
                {
                    ShowComponentGUI();
                }
            });

            return base.value;
        }

        protected abstract void ShowComponentGUI();

        #endregion Method
    }
}