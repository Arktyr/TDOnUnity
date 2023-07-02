using Implementations.PowerUpTowers.RateOfFireUpTower.Scripts;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu ( fileName = "RateOfFireUpConfig", menuName = "Configs/RateOfFireUpTower")]
    public class RateOfFireUpTowerConfig : ScriptableObject
    {
        [SerializeField] private RateOfFireUpTower _percentsRateOfFireUpTower;
        [SerializeField] private float _upRateOfFire;
        [SerializeField] private float _price;

        public RateOfFireUpTower PercentsRateOfFireUpTower => _percentsRateOfFireUpTower;

        public float UpRateOfFire => _upRateOfFire;

        public float Price => _price;
    }
}