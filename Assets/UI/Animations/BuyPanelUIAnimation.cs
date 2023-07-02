using DG.Tweening;
using UnityEngine;

namespace UI.Animations
{
    public class BuyPanelUIAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        
        [SerializeField] private Vector3 _moveIn;
        [SerializeField] private float _duration;

        [SerializeField] private Ease _ease;
        
        private Sequence _sequence;
        private bool _isOpen;
        private bool _isAnimate;
        
        public void PlayAnimation()
        {
            if (_isAnimate == false)
            {
                _sequence = DOTween.Sequence();
                
                if (_isOpen == false)
                {
                    _isOpen = true;
                    _sequence
                        .OnStart(StartAnimation)
                        .AppendCallback(Move)
                        .AppendInterval(_duration)
                        .OnComplete(EndAnimation)
                        .Play();
                }
                else
                {
                    _isOpen = false;
                    _sequence
                        .OnStart(StartAnimation)
                        .AppendCallback(Return)
                        .AppendInterval(_duration)
                        .OnComplete(EndAnimation)
                        .Play();
                }
            }
        }

        private void StartAnimation() => _isAnimate = true;

        private void EndAnimation() => _isAnimate = false;

        private void Move()
        {
            _gameObject.transform.DOMove(transform.position - _moveIn, _duration).SetEase(_ease).Play();
        }

        private void Return()
        {
            _gameObject.transform.DOMove(transform.position + _moveIn, _duration).SetEase(_ease).Play();
        }
    }
}