using UnityEngine;

public class GizmosExSample : MonoBehaviour
{
    protected virtual void OnDrawGizmos()
    {
        GizmosEx.SaveColor();

        Gizmos.color = Color.red;

        GizmosEx.DrawCross(base.transform.position, 1);

        Gizmos.color = Color.green;

        GizmosEx.DrawArrow(base.transform.position, base.transform.position + new Vector3(1, 1, 1) * 3);

        GizmosEx.LoadColor();
    }
}