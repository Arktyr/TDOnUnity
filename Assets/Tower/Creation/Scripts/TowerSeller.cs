using System;
using Player_Manager.Scripts;
using UnityEngine;

namespace Creation.Scripts
{
    public class TowerSeller : MonoBehaviour
    {
        [SerializeField] private TowerFactory _towerFactory;
        [SerializeField] private MoneyManager _moneyManager;
        [SerializeField] private float _percentsReturnMoneyFromRefund;
        
        private void BuyTower(float price) => _moneyManager.RemoveMoney(price);

        public void RefundTower(PlatformConstructor platformConstructor)
        {
            _moneyManager.AddMoney(GetPriceTower(platformConstructor.Type) * _percentsReturnMoneyFromRefund / 100);

            Destroy(platformConstructor.BaseTower.gameObject);
            
            platformConstructor.ResetPlatform();
        }

        public bool PurchasingCheck(float price)
        {
            if (_moneyManager.Money >= price)
            {
                BuyTower(price);
                return true;
            }

            return false;
        }

        public float GetPriceTower(TowersTypes.TowerTypes type)
        {
            switch (type)
            {
                case TowersTypes.TowerTypes.BulletTower:
                    return _towerFactory.BulletTowerConfig.PriceBulletTower;
                case TowersTypes.TowerTypes.FreezeTower:
                    return _towerFactory.FreezeTowerConfig.PriceFreezeTower;
                case TowersTypes.TowerTypes.LaserTower:
                    return _towerFactory.LaserTowerConfig.PriceLaserTower;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}