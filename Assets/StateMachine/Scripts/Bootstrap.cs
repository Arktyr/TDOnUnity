using Enemies.Scripts;
using Implementations.Bullet_Tower.Bullet.Scripts;
using Object_Pools.Scripts;
using UnityEngine;

namespace StateMachine.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private BulletPool _bulletPool;

        private StateMachine<Bootstrap> _stateMachine;

        public EnemyPool EnemyPool => _enemyPool;

        public BulletPool BulletPool => _bulletPool;

        public StateMachine<Bootstrap> StateMachine => _stateMachine;
        
        private void Start()
        {
            _stateMachine = new StateMachine<Bootstrap>(new MenuState(this),
                new GameState(this));
        }

        public void SwitchStateGameState()
        {
            StateMachine.SwitchState<GameState>();
        }

        public void SwitchStateMenuState()
        {
            StateMachine.SwitchState<MenuState>();
        }
    }
}