using UnityEngine;

namespace Implementations.BaseTowerLogic
{
    public abstract class BaseTower : MonoBehaviour
    {
        protected float _price;
        
        public float Price => _price;
    }
}