using UnityEngine;

namespace Creation.Scripts
{
    public class PhantomTower : MonoBehaviour
    {
        [SerializeField] private PlatformRaycaster _platformRaycaster;
        [SerializeField] private InteractionUI _interactionUI;

        [Header("Select Phantom Towers")]
        [SerializeField] private GameObject _bulletTower;
        [SerializeField] private GameObject _freezeTower;
        [SerializeField] private GameObject _laserTower;
        [SerializeField] private GameObject _aoeTower;
        [SerializeField] private GameObject _damageUpTower;
        [SerializeField] private GameObject _rateOfFireUpTower;

        private bool _interactionEnable;

        private void Start() => PreparePhantomTower();

        private void Update() => SetTransformPhantomTower(CheckInteractionUI());

        private void PreparePhantomTower()
        {
            Transform parent = transform.parent;

            _bulletTower = CreatePhantomTower(_bulletTower, parent);

            _freezeTower = CreatePhantomTower(_freezeTower, parent);

            _laserTower = CreatePhantomTower(_laserTower, parent);
            
            _aoeTower = CreatePhantomTower(_aoeTower, parent);
            
            _damageUpTower = CreatePhantomTower(_damageUpTower, parent);
            
            _rateOfFireUpTower = CreatePhantomTower(_rateOfFireUpTower, parent);
        }

        private GameObject CreatePhantomTower(GameObject towerCreate, Transform parent)
        {
            GameObject tower = Instantiate(towerCreate, parent);
            tower.gameObject.SetActive(false);
            return tower;
        }
        
        private GameObject CheckInteractionUI()
        {
            if (_interactionUI.BulletEnable)
            {
                SetStatePhantomTower(_bulletTower, true);
                SetInteraction(true);
                return _bulletTower;
            }
            
            if (_interactionUI.FreezeEnable)
            {
                SetStatePhantomTower(_freezeTower, true);
                SetInteraction(true);
                return _freezeTower;
            }
            
            if (_interactionUI.LaserEnable)
            {
                SetStatePhantomTower(_laserTower, true);
                SetInteraction(true);
                return _laserTower;
            }
            
            if (_interactionUI.AOEEnable)
            {
                SetStatePhantomTower(_aoeTower, true);
                SetInteraction(true);
                return _aoeTower;
            }
            
            if (_interactionUI.DamageUpEnable)
            {
                SetStatePhantomTower(_damageUpTower, true);
                SetInteraction(true);
                return _damageUpTower;
            }
            
            if (_interactionUI.RateOfFireUpEnable)
            {
                SetStatePhantomTower(_rateOfFireUpTower, true);
                SetInteraction(true);
                return _rateOfFireUpTower;
            }
            
            SetInteraction(false);
            
            if (_interactionEnable == false) ResetPhantomTowers();

            return null;
        }

        private void SetInteraction(bool state) => _interactionEnable = state;
        
        private void ResetPhantomTowers()
        {
            if (_bulletTower.gameObject.activeSelf) SetStatePhantomTower(_bulletTower, false);
            
            if (_freezeTower.gameObject.activeSelf) SetStatePhantomTower(_freezeTower, false);
                
            if (_laserTower.gameObject.activeSelf)  SetStatePhantomTower(_laserTower, false);
            
            if (_aoeTower.gameObject.activeSelf)  SetStatePhantomTower(_aoeTower, false);
            
            if (_damageUpTower.gameObject.activeSelf)  SetStatePhantomTower(_damageUpTower, false);
            
            if (_rateOfFireUpTower.gameObject.activeSelf)  SetStatePhantomTower(_rateOfFireUpTower, false);
        }
        
        private void SetStatePhantomTower(GameObject baseTower, bool state) => baseTower.gameObject.SetActive(state);

        private void SetTransformPhantomTower(GameObject baseTower)
        {
            if (baseTower == null) return;

            baseTower.transform.position = _platformRaycaster.Hit.point;
        }
    }
}