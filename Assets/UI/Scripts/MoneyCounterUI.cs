using TMPro;
using UI.Animations;
using UnityEngine;

namespace UI.Scripts
{
    public class MoneyCounterUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private MoneyCounterUIAnimation moneyCounterUIAnimation;
        
        public void PlayAnimation(float reward)
        {
            if (moneyCounterUIAnimation.isMoveAnimationStart == false) moneyCounterUIAnimation.PlayAnimation(reward);
        }
        
        public void ChangeTextInMoneyCounterUI(float money) => text.SetText($"{money}");
    }
}
