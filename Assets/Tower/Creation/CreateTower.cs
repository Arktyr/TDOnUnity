using System.Collections;
using Implementations.Bullet.Bullet;
using UI.Scripts;
using UnityEngine;

namespace Creation
{
    public class CreateTower : MonoBehaviour
    {
        [SerializeField] private SetTowerType setTowerType;
        [SerializeField] private TowerFactory towerFactory;
        [SerializeField] private Alert alert;
        [SerializeField] private MoneyService _moneyService;
        [SerializeField] private BulletFactory bulletFactory;

        private bool _isCreatePool;
        private CreatePlatform _createPlatform;
        private TowersTypes.TowerTypes _type;
        private bool _delayCreation;
        
        [SerializeField] private Camera mainCamera;
        private Ray _ray;
        private RaycastHit _hit;
        private int _layerMask;

        private MeshRenderer _lastMeshRenderer;
        private MeshRenderer _platformMeshRenderer;


        private void Update()
        {
            if (_delayCreation == false)
            {
                GetPositionUserClick();
            }
        }

        private void GetPositionUserClick()
        {
            _ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            _layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");
            if (Input.GetMouseButton(0) && _delayCreation == false)
            {
                if (CheckForConstruct(_ray, _layerMask) == true)
                {
                    BuildTower(setTowerType.Type, createPlatform);
                }
            }
        }
        
        private bool CheckForConstruct(Ray ray, int layerMask)
        {
            if (CheckCollisionHit(ray, layerMask).collider == null) 
                return false;

            bool isTowerCreationPlatform = CheckCollisionHit(ray, layerMask).collider.TryGetComponent(out CreatePlatform createPlatform);
            
            if (isTowerCreationPlatform && _delayCreation == false && Input.GetMouseButton(0))
            {
                _delayCreation = true;
                setTowerType.ChooseTypeTower();
                
                if (createPlatform.isEmpty)
                {
                    ChangePlatformColor(_lastMeshRenderer, Color.red);
                    if (alert.isAnimationEnd) alert.AnimationPlay("Здесь уже установлена вышка");
                }
                
                if (setTowerType.Type != 0 && createPlatform.isEmpty == false)
                {
                }
                StartCoroutine(DelayBeforeNextConstruction());
            }
        }

        private RaycastHit CheckCollisionHit(Ray ray, int layerMask, out CreatePlatform createPlatform)
        {
            if (Physics.Raycast(ray, out _hit, Mathf.Infinity, ~layerMask) && Input.GetMouseButton(0))
            {
                if (_hit.collider.TryGetComponent(out createPlatform))
                {
                    PaintPlatform(createPlatform);
                    return _hit;
                }
            }
            if (_lastMeshRenderer != null)
            {
                ChangePlatformColor(_lastMeshRenderer, Color.white);
            }
            return _hit;
        }

        private void PaintPlatform(CreatePlatform createPlatform)
        {

            _platformMeshRenderer = createPlatform.GetComponent<MeshRenderer>();
            if (_lastMeshRenderer != null)
            {
                ChangePlatformColor(_lastMeshRenderer, Color.white);
            }
            _lastMeshRenderer = _platformMeshRenderer;
            ChangePlatformColor(_platformMeshRenderer,Color.green);
            
        }
        
        private void ChangePlatformColor(MeshRenderer platform, Color color)
        {
            platform.material.color = color;
        }
        
        private IEnumerator DelayBeforeNextConstruction()
        {
            yield return new WaitForSeconds(1);
            _delayCreation = false;
        }
        
        private void BuildTower(TowersTypes.TowerTypes type, CreatePlatform createPlatform)
        {
            if (moneyCounter.Money >= towerFactory.GetPriceTower(type))
            {
                TakePlace(type, createPlatform);
                moneyCounter.BuyTower(towerFactory.GetPriceTower(type));
                Vector3 position = createPlatform.transform.position;
                towerFactory.Create(type, new Vector3(position.x, position.y + 5, position.z), bulletFactory);
            }
            else
            {
                if (alert.isAnimationEnd) alert.AnimationPlay("У вас недостаточно монет для покупки");
            }
        }

        private void TakePlace(TowersTypes.TowerTypes type, CreatePlatform createPlatform)
        {
            createPlatform.isEmpty = true;
            createPlatform.type = type;
        }
    }
}
