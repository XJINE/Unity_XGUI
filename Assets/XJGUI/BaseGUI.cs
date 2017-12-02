using UnityEngine;

public class BaseGUI <T>
{
    #region Field

    protected T value;

    public string title;

    public bool boldTitle;

    #endregion Field

    #region Property

    public virtual T Value
    {
        get { return this.value; }
        set { this.value = value; }
    }

    #endregion Property

    #region Method

    protected virtual void ShowTitle()
    {
        if (this.title == null)
        {
            return;
        }

        if (this.boldTitle)
        {
            XJGUILayout.BoldLabel(this.title);
        }
        else
        {
            GUILayout.Label(this.title);
        }
    }

    #endregion Method
}