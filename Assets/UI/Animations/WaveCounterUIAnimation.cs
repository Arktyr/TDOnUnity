using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Animations
{
    public class WaveCounterUIAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;
        [SerializeField] private Color[] _colors;
        
        private Sequence _sequence;
        
        public void PlayAnimation(Text text)
        {
            _sequence = DOTween.Sequence();

            if (_colors.Length == 0 ) Debug.LogError("You set zero colors");
            
            text.color = _colors[0];
            
            foreach (var color in _colors)
                _sequence.Append(text.DOColor(color, _duration)).SetEase(_ease);

            _sequence.SetLoops(-1, LoopType.Yoyo).SetEase(_ease).Play();
        }
    }
}