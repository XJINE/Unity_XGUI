using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using XGUI;

public class InheritTest : MonoBehaviour
{
    public class Parent
    {
        public Parent()
        {
            Debug.Log("Parent");
        }
    }
    
    public class Child : Parent
    {
        public Child()
        {
            Debug.Log("Child");
        }
    }
    
    void Start()
    {
        FlexWindow temp = new FlexWindow();

        new Child();
    }
}
