using Implementations.BaseTower;
using Implementations.Freeze_Tower.Scripts;
using Implementations.Laser_Tower.Scripts;
using UnityEngine;

namespace Creation.Scripts
{
    public class PlatformConstructor : MonoBehaviour
    {
        private TowersTypes.TowerTypes _type;
        private BaseTower _baseTower;
        private FreezeTower _freezeTower;
        private LaserTower _laserTower;
        
        private bool _isEmpty;

        public BaseTower BaseTower => _baseTower;
        
        public TowersTypes.TowerTypes Type => _type;

        public bool IsEmpty => _isEmpty;

        public void SetTowerType(TowersTypes.TowerTypes type) => _type = type;

        public void SetPlace(bool place) => _isEmpty = place;
        
        public void SetBaseTower(BaseTower baseTower) => _baseTower = baseTower;
        
        public void ResetPlatform()
        {
            _type = 0;
            _baseTower = null;
            _isEmpty = false;
        }
    }
}
