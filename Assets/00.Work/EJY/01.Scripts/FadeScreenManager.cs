using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreenManager : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;
    [SerializeField] private BoolEventChannelSO _fadeScreenChannel;
    [SerializeField] private float _fadeDuration = 0.5f;

    private readonly int _valueHash = Shader.PropertyToID("_Value");

    private void Awake()
    {
        _fadeImage.material = new Material(_fadeImage.material);

        _fadeScreenChannel.OnValueEvent += HandleFadeEvent;
    }

    private void OnDestroy()
    {
        _fadeScreenChannel.OnValueEvent -= HandleFadeEvent;
    }

    private void HandleFadeEvent(bool isFadeIn)
    {
        float fadeValue = isFadeIn ? 3f : 0f;
        float startValue = isFadeIn ? 0f : 3f;

        _fadeImage.material.SetFloat(_valueHash, startValue);
        _fadeImage.material.DOFloat(fadeValue, _valueHash, _fadeDuration);
    }
}
