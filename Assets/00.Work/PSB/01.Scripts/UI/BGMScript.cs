using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    private static BGMScript instance;

    [SerializeField] private AudioSource bgmSource;

    void Awake()
    {
        // ½Ì±ÛÅæ ÆÐÅÏ ±¸Çö
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        PlayBGM(); 
    }

    public void PlayBGM()
    {
        if (!bgmSource.isPlaying)
        {
            bgmSource.Play(); 
        }
    }

    public void StopBGM()
    {
        if (bgmSource.isPlaying)
        {
            bgmSource.Stop(); 
        }
    }
}
