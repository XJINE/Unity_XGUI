using UnityEngine;

public class DebugExSample : MonoBehaviour
{
    void Start()
    {
        DebugEx.Log("HERE01 : " + Vector3.zero);
        DebugEx.Log("HERE02 : " + Vector3.zero, ", ");
        DebugEx.Log("HERE03 : " + Vector3.zero, 0.01f, ", ");
        DebugEx.Log("HERE04 : " + Vector3.zero, 0.01f, base.name, ", ");

        DebugEx.LogWarning("HERE05 : " + Vector3.zero, 0.01f, base.name, ", ");
        DebugEx.LogError  ("HERE06 : " + Vector3.zero, 0.01f, base.name, ", ");

        DebugEx.LogIf(true,  "HERE07 : " + Vector3.zero, 0.01f, base.name, ", ");
        DebugEx.LogIf(false, "HERE08 : " + Vector3.zero, 0.01f, base.name, ", ");
        DebugEx.LogWarningIf(true, "HERE09 : " + Vector3.zero, 0.01f, base.name, ", ");
        DebugEx.LogErrorIf  (true, "HERE10 : " + Vector3.zero, 0.01f, base.name, ", ");
    }
}