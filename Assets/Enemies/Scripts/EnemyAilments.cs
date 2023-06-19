using UnityEngine;

namespace Enemies.Scripts
{
    public class EnemyAilments: MonoBehaviour
    {
        private Freeze _freeze;

        public Freeze Freeze => _freeze;
        
        public void SetFreeze(Freeze freeze)
        {
            _freeze = freeze;
        }
    }
}