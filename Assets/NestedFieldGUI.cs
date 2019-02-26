using UnityEngine;

namespace XJGUI
{
    [System.Serializable]
    public class ParentClass
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
        public int valueA;
        public int valueB;
    }

    [System.Serializable]
    public class Grandson
    {
        public int value = 3;
    }

    [System.Serializable]
    public struct ParentStruct
    {
        public int value;
        public ChildStruct child;
    }

    [System.Serializable]
    public struct ChildStruct
    {
        public int value;
        public GrandsonStruct grandson;
    }

    [System.Serializable]
    public struct GrandsonStruct
    {
        public int value;
    }

    public class NestedFieldGUI : MonoBehaviour
    {
        public FlexibleWindow window;
        public FieldGUI fieldGUIParentClass;
        public FieldGUI fieldGUIParentStruct;
        public FieldGUI fieldGUIGrandsonStruct;

        public ParentClass parentClass;
        public ParentStruct parentStruct;
        public GrandsonStruct grandsonStruct;

        void Start()
        {
            XJGUILayout.DefaultFieldGUIFoldout = true;

            this.window = new FlexibleWindow();

            this.fieldGUIParentClass = new FieldGUI(this.parentClass);
            this.fieldGUIParentStruct = new FieldGUI(this.parentStruct);
            this.fieldGUIGrandsonStruct = new FieldGUI(this.grandsonStruct);
        }

        private void OnGUI()
        {
            this.window.Show(() =>
            {
                this.fieldGUIParentClass.Show();
                this.parentStruct = (ParentStruct)this.fieldGUIParentStruct.Show();
                this.grandsonStruct = (GrandsonStruct)this.fieldGUIGrandsonStruct.Show();
            });
        }
    }
}