using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeverGimmick : Gimmick, Unity.VisualScripting.IInitializable
{
    [SerializeField] private Grid grid;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)  //Player Layer
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            Vector3 rot = grid.transform.rotation.eulerAngles;
            rot.x = 180;
            grid.transform.rotation = Quaternion.Euler(rot);
        }
    }

    public override bool Check()
    {
        return true;
    }

    public void Initialize()
    {
        grid = FindAnyObjectByType<Grid>();
    }


}
