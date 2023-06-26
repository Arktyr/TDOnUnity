using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Animations
{
    public class ScaleUIAnimation : MonoBehaviour
    {
        [SerializeField] private float _scaleDuration;
        [SerializeField] private float _scaleIn;
        [SerializeField] private float _scaleOut;
        [SerializeField] private Ease _ease;

        private bool _isAnimationStart;
        private Sequence _sequence;
        
        public void PlayAnimation(Text text)
        {
            _sequence = DOTween.Sequence();

            _sequence.OnStart(StartAnimation).Append(text.transform.DOScale(_scaleIn, _scaleDuration))
                .Append(text.transform.DOScale(_scaleOut, _scaleDuration)).OnComplete(EndAnimation);
            
            if (_isAnimationStart == false) _sequence.SetEase(_ease).Play();
        }

        private void StartAnimation() => _isAnimationStart = true;

        private void EndAnimation() => _isAnimationStart = false;
    }
}