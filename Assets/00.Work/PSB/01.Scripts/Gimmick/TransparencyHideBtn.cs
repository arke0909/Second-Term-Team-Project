using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyHideBtn : MonoBehaviour
{
    [SerializeField] private GameObject transparencyBlock;

    public float delay = 7f;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerCollider")
        {
            if (transparencyBlock != null)
            {
                StartCoroutine(HideAndShow());
            }
        }
    }


    private IEnumerator HideAndShow()
    {
        transparencyBlock.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(delay);

        transparencyBlock.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }


}
