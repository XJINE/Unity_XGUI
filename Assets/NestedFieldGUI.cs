using UnityEngine;

namespace XJGUI
{
    [System.Serializable]
    public class Parent
    {
        public int value = 0;
        public ChildA childA;
        public ChildB childB;
    }

    [System.Serializable]
    public class ChildA
    {
        public int value = 1;
        public Grandson grandson;
    }

    [System.Serializable]
    public struct ChildB
    {
        public int value;
    }

    [System.Serializable]
    public class Grandson
    {
        public int value = 3;
    }

    public class NestedFieldGUI : MonoBehaviour
    {
        public FlexibleWindow window;
        public FieldGUI fieldGUI;
        public Parent parent;

        void Start()
        {
            XJGUILayout.DefaultFieldGUIFoldout = true;
            this.window   = new FlexibleWindow();
            this.fieldGUI = new FieldGUI(this.parent);
        }

        private void OnGUI()
        {
            this.window.Show(() =>
            {
                this.fieldGUI.Show();
            });
        }
    }
}