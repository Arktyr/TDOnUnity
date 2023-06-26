using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Animations
{
    public class PausePanelUIAnimation : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        [SerializeField] private Vector3 _scaleIn;
        
        [SerializeField] private Vector3 _scaleOut;
        [SerializeField] private float _scaleDuration;

        [SerializeField] private Ease _ease;
        
        private Transform _normalScale;

        private void OnEnable()
        {
            _image.transform.DOScale(0, 0);
        }

        public void PlayAnimationIn() => 
            _image.transform
                .DOScale(_scaleIn, _scaleDuration).
                SetEase(_ease).SetUpdate(UpdateType.Normal, true)
                .Play();

        public void PlayAnimationOut() => 
            _image.transform.DOScale(_scaleOut, _scaleDuration).SetEase(_ease).Play();
    }
}