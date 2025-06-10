using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmosScript : MonoBehaviour
{
    public Color gizmoColor = Color.green;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(transform.position, gameObject.transform.localScale);
    }
}
