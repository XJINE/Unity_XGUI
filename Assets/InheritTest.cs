using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using XGUIs;

public class InheritTest : MonoBehaviour
{
    [Range(0, 1)]
    public Vector3 temp;

    public Vector3 temp2;

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
        new Child();
    }
}
