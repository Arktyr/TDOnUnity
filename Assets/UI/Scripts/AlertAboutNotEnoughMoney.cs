using System.Collections;
using UnityEngine;

namespace UI.Scripts
{
    public class AlertAboutNotEnoughMoney : MonoBehaviour
    {
        public Animator Animation;
        private bool _isPlay;

        private void Start()
        {
            Animation = GetComponent<Animator>();
        }

        public IEnumerator AnimationPlay()
        {
            if (_isPlay == false)
            {
                _isPlay = true;
                Animation.Play("AlerAboutNotEnoughMoney");
                yield return new WaitForSeconds(2);
                Animation.Play("New State");
                _isPlay = false;
            }
        }
    }
}
