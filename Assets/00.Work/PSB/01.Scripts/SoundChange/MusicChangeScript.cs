using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChangeScript : MonoBehaviour
{
    [SerializeField] private Vector2 gizmoSize;

    public AudioClip newMusic;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerCollider"))
        {
            StartCoroutine(ChangeMusic(newMusic));
        }
    }

    /// <summary>
    /// À½¾Ç ¹Ù²Ù´Â³ð
    /// </summary>
    /// <param name="newClip"></param>
    /// <returns></returns>
    private IEnumerator ChangeMusic(AudioClip newClip)
    {
        yield return StartCoroutine(FadeOut(audioSource, 1f));

        audioSource.clip = newClip;
        audioSource.Play();

        yield return StartCoroutine(FadeIn(audioSource, 1f)); 
    }


    /// <summary>
    /// À½¾Ç ¸ØÃß´Â³ð
    /// </summary>
    /// <param name="audioSource"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration);
            yield return null;
        }

        audioSource.volume = 0; 
        audioSource.Stop();
    }

    /// <summary>
    /// À½¾Ç ½ÃÀÛÇÏ´Â³ð
    /// </summary>
    /// <param name="audioSource"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    private IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        audioSource.volume = 0;
        audioSource.Play();

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, 1, t / duration);
            yield return null;
        }

        audioSource.volume = 1;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, gizmoSize);
        Gizmos.color = Color.white;
    }
}
