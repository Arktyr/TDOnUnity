using TMPro;
using UI.Animations;
using UnityEngine;

namespace UI.Scripts
{
    public class MoneyCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private MoneyCounterAnimation moneyCounterAnimation;
        
        public void PlayAnimation(float reward)
        {
            if (moneyCounterAnimation.isMoveAnimationStart == false) moneyCounterAnimation.PlayAnimation(reward);
        }
        
        public void ChangeTextInMoneyCounterUI(float money) => text.SetText($"{money}");
    }
}
