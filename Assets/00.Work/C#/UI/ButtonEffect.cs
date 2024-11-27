using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEffect : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private AudioSource btnSound;
    private void Start()
    {
        btnSound.Stop();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        btnSound.Play();
        transform.DORewind();
        transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.25f).SetAutoKill(false).SetUpdate(true);
    }
}
