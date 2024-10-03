using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WindShowBtn : MonoBehaviour
{
    [SerializeField] private GameObject windBlock;
    [SerializeField] private GameObject windHideBtn;
    [SerializeField] private GameObject windShowBtn;
    [SerializeField] private Tilemap specialTile;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerCollider")
        {
            if (windBlock != null)
            {
                windBlock.SetActive(true);
                windHideBtn.SetActive(true);
                gameObject.SetActive(false);
                specialTile.gameObject.layer = 7;
            }
        }
    }

}
