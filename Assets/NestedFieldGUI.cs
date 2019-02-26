using UnityEngine;

namespace XJGUI
{
    [System.Serializable]
    public class Parent
    {
        public float data1 = 111;
        public Child child;
    }

    [System.Serializable]
    public class Child
    {
        public float data2 = 222;
        public float data3 = 333;
        public Grandson grandson;
    }

    [System.Serializable]
    public class Grandson
    {
        public float data4 = 444;
        public float data5 = 555;
    }

    public class NestedFieldGUI : MonoBehaviour
    {
        public FlexibleWindow window;
        public FieldGUI fieldGUI;
        public Parent parent;

        void Start()
        {
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