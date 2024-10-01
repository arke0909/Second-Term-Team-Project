using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WindHideBtn : MonoBehaviour
{
    [SerializeField] private GameObject windBlock;
    [SerializeField] private GameObject windShowBtn;
    [SerializeField] private Tilemap specialTile;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (windBlock != null)
        {
            windBlock.SetActive(false);
            windShowBtn.SetActive(true);
            gameObject.SetActive(false);
            specialTile.gameObject.layer = 6;
        }
    }

}
