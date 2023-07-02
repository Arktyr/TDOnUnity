using System;
using System.Collections;
using Creation.Scripts;
using DG.Tweening;
using UI.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Animations
{
    public class ButtonUIAnimation : MonoBehaviour
    {
        [SerializeField] private UIRaycast _uiRaycast;
        
        [SerializeField] private float _scaleMultiplicator;
        [SerializeField] private float _scaleDuration;

        [SerializeField] private float _shakeStrength;
        [SerializeField] private int _shakeVibrato;
        [SerializeField] private float _shakeDuration;
        
        [SerializeField] private Ease _ease;

        private Button _button;
        private Vector3 _startScale;
        private Quaternion _startRotate;
        
        private bool _isScale;
        private bool _isShake;

        private void Update()
        {
            if (_uiRaycast.Hit.collider == null) return;

            if (_uiRaycast.Hit.collider.TryGetComponent(out Button button))
            {
                if (_button == null && _isScale == false)
                {
                    PlayAnimation(button);
                }
            }
            else
            {
                if (_button != null)
                {
                    StartCoroutine(ReturnScale(_button));
                }
            }
        }

        private void PlayAnimation(Button button)
        {
            _button = button;
            Transform buttonTransform = button.transform;
            _startScale = buttonTransform.localScale;
            _startRotate = buttonTransform.rotation;
            
            Scale();
        }

        private IEnumerator ReturnScale(Button button)
        {
            if (_isScale == false)
            {
                _isScale = true;
                button.transform
                    .DOScale(_startScale, _scaleDuration)
                    .SetEase(_ease)
                    .SetUpdate(UpdateType.Normal, true)
                    .Play();
                yield return new WaitForSeconds(_scaleDuration);
                
                _button = null;
                
                _isScale = false;
            }
        }

        private void Scale()
        {
            _button.transform
                .DOScale(_startScale * _scaleMultiplicator, _scaleDuration)
                .SetUpdate(UpdateType.Normal, true)
                .SetEase(_ease)
                .Play();
        }
    }
}