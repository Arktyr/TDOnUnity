using UnityEngine;

namespace Creation.Scripts
{
    public class InteractionUI : MonoBehaviour
    {
        private bool _laserEnable;
        private bool _freezeEnable;
        private bool _bulletEnable;
        private bool _refundEnable;

        public bool LaserEnable => _laserEnable;
        
        public bool FreezeEnable => _freezeEnable;
        
        public bool BulletEnable => _bulletEnable;
        
        public bool RefundEnable => _refundEnable;
        

        public void EnableRefund()
        {
            if (_refundEnable == false) _refundEnable = true;
            else _refundEnable = false;
        }
        
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
    }
}