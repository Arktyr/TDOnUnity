using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Scripts
{
    public class SceneSwitcher : MonoBehaviour
    {
        public void SwitchToMenu()
        {
            Time.timeScale = 1f;
            DOTween.KillAll();
            SceneManager.LoadScene("Scenes/Menu");
        }

        public void SwitchToLevel()
        {
            Time.timeScale = 1f;
            DOTween.KillAll();
            SceneManager.LoadScene("Scenes/MainLevel");
        }

        public void SwitchToSettings()
        {
            DOTween.KillAll();
            SceneManager.LoadScene("Scenes/Settings");
        }
    }
}
