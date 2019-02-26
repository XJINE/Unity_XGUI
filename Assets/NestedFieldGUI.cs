using UnityEngine;

namespace XJGUI
{
    [System.Serializable]
    public class Parent
    {
        //public int data1 = 111;
        public Child child1;
    }

    [System.Serializable]
    public class Child
    {
        public int data2 = 222;
        //public float data3 = 333;
    }

    public class NestedFieldGUI : MonoBehaviour
    {
        public Parent parent;

        public FieldGUI fieldGUI;

        void Start()
        {
            XJGUILayout.DefaultFieldGUIFoldout = false;
            this.fieldGUI = new FieldGUI("NEST TEST", this.parent);
        }

        private void OnGUI()
        {
            this.fieldGUI.Show();
        }
    }
}