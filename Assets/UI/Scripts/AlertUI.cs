using System.Net.Mime;
using UI.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Scripts
{
    [RequireComponent(typeof(MediaTypeNames.Text))]
    public class AlertUI : MonoBehaviour
    {
        [SerializeField] private FadeUIAnimation _fadeUIAnimation;
        
        private Text _text;

        public FadeUIAnimation FadeUIAnimation => _fadeUIAnimation;
        
        private void Start() => _text = GetComponent<Text>();

        public Text SetText(string text)
        {
            _text.text = text;
            return _text;
        }
    }
}
