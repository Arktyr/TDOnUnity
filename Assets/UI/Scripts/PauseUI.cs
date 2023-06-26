using UI.Animations;
using UnityEngine;

namespace UI.Scripts
{
    public class PauseUI : MonoBehaviour
    {
        [SerializeField] private PausePanelUIAnimation _pausePanelUIAnimation;

        public void StopGame()
        {
            _pausePanelUIAnimation.PlayAnimationIn();
            Time.timeScale = 0;
        }

        public void ContinueGame()
        {
            _pausePanelUIAnimation.PlayAnimationOut();
            Time.timeScale = 1f;
        }
    }
}
