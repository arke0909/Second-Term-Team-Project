using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrainGimmick : Gimmick, IInitializable
{
    [Header("Player")]
    [SerializeField] private GameObject player;

    [Header("Value")]
    public float distanceValue = 10f;
    public float arrowSpeed = 5f;
    private Vector2 direction;

    private bool isMove = false;

    private void Update()
    {
        float distancePlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distancePlayer < distanceValue && !isMove)
        {
            StartMove();
        }
        else if (distancePlayer > distanceValue)
        {
            isMove = false;
        }

        if (isMove == true)
        {
            TrainMove();
        }

    }
    public override bool Check()
    {
        return true;
    }

    public override void EffectGimmick()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);

        base.EffectGimmick();
    }

    public void Initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void StartMove()
    {
        Vector2 direct = (transform.position - player.transform.position).normalized;
        transform.right = direct;

        direction = (player.transform.position - transform.position).normalized;
        isMove = true;
    }

    private void TrainMove()
    {
        transform.position += (Vector3)direction * arrowSpeed * Time.deltaTime;
    }

}
