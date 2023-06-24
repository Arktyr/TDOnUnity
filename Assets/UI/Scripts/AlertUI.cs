using DG.Tweening;
using TMPro;
using UI.Animations;
using UnityEngine;

namespace UI.Scripts
{
    [RequireComponent(typeof(TMP_Text))]
    public class AlertUI : MonoBehaviour
    {
        [SerializeField] private FadeUIAnimation _fadeUIAnimation;
        
        private TMP_Text _text;

        public FadeUIAnimation FadeUIAnimation => _fadeUIAnimation;
        
        private void Start() => _text = GetComponent<TMP_Text>();

        public TMP_Text SetText(string text)
        {
            _text.SetText(text);
            return _text;
        }
    }
}
