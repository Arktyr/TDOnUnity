using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI.Scripts
{
    [RequireComponent(typeof(TMP_Text))]
    public class Alert : MonoBehaviour
    {
        public bool isAnimationEnd;
        private TMP_Text _text;
        private Sequence sequence;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            isAnimationEnd = true;
        }

        public void AnimationPlay(string alertText)
        {
            if (isAnimationEnd)
            {
                sequence = DOTween.Sequence();
                _text.SetText(alertText);
                sequence.OnStart(StartAnimation).AppendCallback(FadeIn).AppendInterval(2).AppendCallback(FadeOut).AppendInterval(2).OnComplete(EndAnimation).Play();
            }
        }

        private void FadeIn() => _text.DOFade(1, 2).SetEase(Ease.InQuart).Play();

        private void FadeOut() => _text.DOFade(0, 2).SetEase(Ease.InQuart).Play();
        
        private void StartAnimation() => isAnimationEnd = false;
        
        private void EndAnimation() => isAnimationEnd = true;
    }
}
