using UnityEngine;

namespace Enemies.Scripts
{
    public class Freeze : MonoBehaviour
    {
        private float _freezeStacks;
        private int _inRadius;

        public float FreezeStacks => _freezeStacks;

        public int InRadius => _inRadius;

        public void AddFreezeStack() => _freezeStacks++;

        public void SetZeroFreezeStack() => _freezeStacks = 0;
        
        public void AddInRadius() => _inRadius++;
        
        public void RemoveInRadius() => _inRadius--;
    }
}