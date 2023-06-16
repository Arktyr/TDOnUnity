using System.Collections;
using System.Net.Mime;
using TMPro;
using UnityEngine;

namespace UI.Scripts
{
    public class Alert : MonoBehaviour
    {
        [HideInInspector] public string alertText;
        [HideInInspector] public Animator Animation;
        private bool _isPlay;
        private TMP_Text _text;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            Animation = GetComponent<Animator>();
        }

        public IEnumerator AnimationPlay(string alertText)
        {
            if (_isPlay == false)
            {
                _isPlay = true;
                _text.SetText(alertText);
                Animation.Play("AlerAboutNotEnoughMoney");
                yield return new WaitForSeconds(2);
                Animation.Play("New State");
                _isPlay = false;
            }
        }
    }
}
