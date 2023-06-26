using UI.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Scripts
{
    public class MoneyCounterUI : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private MoneyCounterUIAnimation moneyCounterUIAnimation;
        
        public void PlayAnimation(float reward)
        {
            if (moneyCounterUIAnimation.isMoveAnimationStart == false) moneyCounterUIAnimation.PlayAnimation(reward);
        }
        
        public void ChangeTextInMoneyCounterUI(float money) => text.text = $"{money}";
    }
}
