using UnityEngine;

namespace Creation
{
    public class SetTowerType : MonoBehaviour
    {
        private TowersTypes.TowerTypes _type;
        public TowersTypes.TowerTypes Type => _type;
        private bool _laserEnable;
        private bool _freezeEnable;
        private bool _bulletEnable;
        
        
        public void CheckLaserEnableInUI(bool enable)
        {
            if (enable) _laserEnable = false;
            if (enable == false) _laserEnable = true;
        }
        
        public void CheckFreezeEnableInUI(bool enable)
        {
            if (enable) _freezeEnable = false;
            if (enable == false) _freezeEnable = true;
        }
        
        public void CheckBulletEnableInUI(bool enable)
        {
            if (enable) _bulletEnable = false;
            if (enable == false) _bulletEnable = true;
        }
        
        public void ChooseTypeTower()
        {
            _type = 0;
            if (_laserEnable) ChooseTypeLaserTower();
            if (_bulletEnable) ChooseTypeBulletTower();
            if (_freezeEnable) ChooseTypeFreezeTower();
        }
        
        private void ChooseTypeLaserTower()
        {
            _type = TowersTypes.TowerTypes.LaserTower;
        }
        
        private void ChooseTypeFreezeTower()
        {
            _type = TowersTypes.TowerTypes.FreezeTower;
        }
        
        private void ChooseTypeBulletTower()
        {
            _type = TowersTypes.TowerTypes.BulletTower;
        }
    }
}