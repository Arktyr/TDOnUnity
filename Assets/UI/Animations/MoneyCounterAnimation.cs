using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI.Animations
{
    public class MoneyCounterAnimation : MonoBehaviour
    {
        [SerializeField] public TMP_Text animatedText;
        [SerializeField] private TMP_Text moneyCounter;
        public bool isMoveAnimationStart;
        private Vector3 _startPosition;
        private Sequence _sequence;
        public float reward;

        private void Start()
        {
            _startPosition = animatedText.transform.position;
        }

        public void PlayAnimation(float Reward)
        {
            reward += Reward;
            SetText();
            _sequence = DOTween.Sequence();
            _sequence.OnStart(StartMoveAnimation).AppendCallback(Fade)
                .AppendCallback(MoveAnimatedText).AppendInterval(1f).AppendCallback(OutFade)
                .AppendCallback(EndMoveAnimation).AppendCallback(ScaleMoneyCounterIn).AppendInterval(0.4f)
                .AppendCallback(ScaleMoneyCounterOut).Play();
        }

        private void EndMoveAnimation()
        {
            isMoveAnimationStart = false;
            animatedText.gameObject.SetActive(false);
            reward = 0;
        }

        private void StartMoveAnimation()
        { 
            animatedText.gameObject.SetActive(true);
            isMoveAnimationStart = true;
        }

        private void MoveAnimatedText() => animatedText.transform.DOMove(moneyCounter.transform.position, 1f).SetEase(Ease.InQuart).Play();
        
        private void ScaleMoneyCounterIn() => moneyCounter.transform.DOScale(1.2f, 0.5f).SetEase(Ease.InQuart).Play();
        
        private void ScaleMoneyCounterOut() => moneyCounter.transform.DOScale(1, 0.5f).SetEase(Ease.InQuart).Play();

        private void Fade() => animatedText.DOFade(0, 1f).SetEase(Ease.InQuart).Play();
        
        private void OutFade() => animatedText.DOFade(1, 0f).SetEase(Ease.InQuart).Play();

        public void SetText()
        {
            animatedText.SetText($"{reward}");
        }
    }
}