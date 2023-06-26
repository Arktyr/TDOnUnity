using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Animations
{
    public class MoneyCounterUIAnimation : MonoBehaviour
    {
        [SerializeField] private Text _moneyCounter;
        public bool isMoveAnimationStart;
        private Vector3 _startPosition;
        private Sequence _sequence;
        public float reward;
        
        public void PlayAnimation(float Reward)
        {
            //reward += Reward;
            //SetText();
            //animatedText.transform.position = _startPosition;
            _sequence = DOTween.Sequence();
            _sequence.OnStart(StartMoveAnimation)
                .AppendCallback(ScaleMoneyCounterIn)
                .AppendInterval(0.4f)
                .AppendCallback(ScaleMoneyCounterOut)
                .OnComplete(EndMoveAnimation)
                .Play();
               // .AppendCallback(MoveAnimatedText).AppendInterval(1f).AppendCallback(OutFade)
               // .AppendCallback(ScaleMoneyCounterIn).AppendInterval(0.4f)
        }

        private void EndMoveAnimation()
        {
            isMoveAnimationStart = false;
            //animatedText.gameObject.SetActive(false);
            reward = 0;
        }

        private void StartMoveAnimation()
        { 
            //animatedText.gameObject.SetActive(true);
            isMoveAnimationStart = true;
        }
        
        
        private void ScaleMoneyCounterIn() => _moneyCounter.transform.DOScale(1.2f, 0.5f).SetEase(Ease.InQuart).Play();
        
        private void ScaleMoneyCounterOut() => _moneyCounter.transform.DOScale(1, 0.5f).SetEase(Ease.InQuart).Play();
    }
}