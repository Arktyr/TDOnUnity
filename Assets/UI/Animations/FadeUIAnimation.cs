using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Animations
{
    public class FadeUIAnimation : MonoBehaviour
    {
        [SerializeField] private float _fadeInEndValue;
        [SerializeField] private float _fadeOutEndValue;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private Ease _setEase;

        private TMP_Text _text;
        private Sequence _sequence;

        private bool _isAnimationEnd = true;

        public void AnimationPlay(TMP_Text text)
        {
            if (_isAnimationEnd)
            {
                _text = text;
                _sequence = DOTween.Sequence();
                _sequence.OnStart(StartAnimation).AppendCallback(FadeIn).AppendInterval(_fadeDuration).AppendCallback(FadeOut)
                    .AppendInterval(_fadeDuration).OnComplete(EndAnimation).Play();
            }
        }

        private void FadeIn() => _text.DOFade(_fadeInEndValue, _fadeDuration).SetEase(_setEase).Play();

        private void FadeOut() => _text.DOFade(_fadeOutEndValue, _fadeDuration).SetEase(_setEase).Play();

        private void StartAnimation() => _isAnimationEnd = false;

        private void EndAnimation() => _isAnimationEnd = true;
    }
}