using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WindHideBtn : MonoBehaviour
{
    [SerializeField] private GameObject windBlock;
    [SerializeField] private Tilemap specialTile;

    public float delay = 7f;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerCollider")
        {
            if (windBlock != null)
            {
                StartCoroutine(IsTrigged());
            }
        }
    }

    private IEnumerator IsTrigged()
    {
        windBlock.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        specialTile.gameObject.layer = 6;

        yield return new WaitForSeconds(delay);

        windBlock.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        specialTile.gameObject.layer = 7;
    }

}
