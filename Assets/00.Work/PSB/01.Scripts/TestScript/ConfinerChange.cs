using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfinerChange : MonoBehaviour
{
    public List<PolygonCollider2D> boundingShapes;
    public int myIndex = 0;
    public CinemachineConfiner2D confiner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCollider")
        {
            confiner.m_BoundingShape2D = boundingShapes[myIndex];
        }
    }

}
