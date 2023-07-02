using DG.Tweening;
using Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachine.Scripts
{
    public class MenuState : IState<Bootstrap>, IEnterable, IExitable, ITickable
    {
        public Bootstrap Initializer { get; }

        public MenuState(Bootstrap initializer)
        {
            Initializer = initializer;
        }
        
        public void OnEnter()
        {
            DOTween.KillAll();
            SceneManager.LoadScene("Scenes/Menu");
        }
        
        public void OnExit()
        {
            Debug.Log("Привет");
        }

        public void Tick()
        {
        }
    }
}