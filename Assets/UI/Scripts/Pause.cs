using UnityEngine;

namespace UI.Scripts
{
    public class Pause : MonoBehaviour
    {
        public void StopGame()
        {
            Time.timeScale = 0;
        }

        public void ContinueGame()
        {
            Time.timeScale = 1f;
        }
    }
}
