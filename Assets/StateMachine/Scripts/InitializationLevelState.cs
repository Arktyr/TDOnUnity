using Interfaces;

namespace StateMachine.Scripts
{
    public class InitializationLevelState : IState<Bootstrap>, IEnterable, IExitable
    {
        public Bootstrap Initializer { get; }
        
        public InitializationLevelState(Bootstrap initializer)
        {
            Initializer = initializer;
        }
        
        public void OnEnter()
        {
           
        }

        public void OnExit()
        {
            throw new System.NotImplementedException();
        }
    }
}