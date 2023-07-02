using DG.Tweening;
using Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachine.Scripts
{
    public class GameState : IState<Bootstrap>, IEnterable, IExitable
    {
        public GameState(Bootstrap initializer)
        {
            Initializer = initializer;
        }

        public Bootstrap Initializer { get; }
        public void OnEnter()
        {
            Time.timeScale = 1f;
            DOTween.KillAll();
            SceneManager.LoadScene("Scenes/MainLevel");
        }

        public void OnExit()
        {
            throw new System.NotImplementedException();
        }
    }
}