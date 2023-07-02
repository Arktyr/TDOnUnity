using UnityEngine;

namespace Creation.Scripts
{
    public class InteractionUI : MonoBehaviour
    {
        private bool _laserEnable;
        private bool _freezeEnable;
        private bool _bulletEnable;
        private bool _aoeEnable;
        private bool _damageUpEnable;
        private bool _rateOfFireUpEnable;
        private bool _refundEnable;

        public bool LaserEnable => _laserEnable;
        
        public bool FreezeEnable => _freezeEnable;
        
        public bool BulletEnable => _bulletEnable;

        public bool AOEEnable => _aoeEnable;

        public bool DamageUpEnable => _damageUpEnable;

        public bool RateOfFireUpEnable => _rateOfFireUpEnable;
        
        public bool RefundEnable => _refundEnable;
        

        public void EnableRefund()
        {
            if (_refundEnable)
            {
                _refundEnable = false;
                return;
            }
            _refundEnable = true;
        }
        
        public void CheckLaserEnableInUI(bool enable)
        {
            if (_laserEnable)
            {
                _laserEnable = false;
                return;
            }
            
            if (CheckOnActive() == false) _laserEnable = enable;
        }
        
        public void CheckBulletEnableInUI(bool enable)
        {
            if (_bulletEnable)
            {
                _bulletEnable = false;
                return;
            }
            
            if (CheckOnActive() == false) _bulletEnable = enable;
        }
        
        public void CheckFreezeEnableInUI(bool enable)
        {
            if (_freezeEnable)
            {
                _freezeEnable = false;
                return;
            }
            
            if (CheckOnActive() == false) _freezeEnable = enable;
        }
        
        public void CheckAOEEnableInUI(bool enable)
        {
            if (_aoeEnable)
            {
                _aoeEnable = false;
                return;
            }
            
            if (CheckOnActive() == false) _aoeEnable = enable;
        }
        
        public void CheckDamageUPEnableInUI(bool enable)
        {
            if (_damageUpEnable)
            {
                _damageUpEnable = false;
                return;
            }
            
            if (CheckOnActive() == false) _damageUpEnable = enable;
        }
        
        public void CheckRateOfFireEnableInUI(bool enable)
        {
            if (_rateOfFireUpEnable)
            {
                _rateOfFireUpEnable = false;
                return;
            }
            if (CheckOnActive() == false) _rateOfFireUpEnable = enable;
        }

        private bool CheckOnActive()
        {
            if (_rateOfFireUpEnable) return true;
            
            if (_bulletEnable) return true;
            
            if (_damageUpEnable) return true;
            
            if (_laserEnable) return true;
            
            if (_freezeEnable) return true;
            
            if (_aoeEnable) return true;
            
            return false;
        }
    }
}