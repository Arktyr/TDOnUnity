using System;
using UnityEngine;

namespace Creation
{
    public class TowerShop : MonoBehaviour
    {
        public void BuyTower(float price)
        {
            _money -= price;
            ChangeTextInMoneyCounterUI();
        }
        
        public float GetPriceTower(TowersTypes.TowerTypes type)
        {
            switch (type)
            {
                case TowersTypes.TowerTypes.BulletTower:
                    return bulletTowerConfig.PriceBulletTower;
                case TowersTypes.TowerTypes.FreezeTower:
                    return freezeTowerConfig.PriceFreezeTower;
                case TowersTypes.TowerTypes.LaserTower:
                    return laserTowerConfig.PriceLaserTower;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}