using UI.Scripts;
using UnityEngine;

namespace Creation.Scripts
{
    [RequireComponent(typeof(PlatformConstructor))]
    public class PlatformRaycaster : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private PlatformColorController _platformColorController;
        [SerializeField] private AlertUI _alertUI;
        [SerializeField] private InteractionUI _interactionUI;

        private Ray _ray;
        private RaycastHit _hit;
        
        private int _layerMask;

        public RaycastHit Hit => _hit;
        
        private void Start() => _layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");

        private void Update() => RaycastRay();

        private void RaycastRay()
        {
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            _hit = CheckRaycastHit(_ray, _layerMask);
        }

        public PlatformConstructor GetCreatePlatform()
        {
            if (_hit.collider != null && _hit.collider.TryGetComponent(out PlatformConstructor createPlatform))
            {
                if (_interactionUI.RefundEnable) return createPlatform;
                
                if (CheckOnEmptyPlace(createPlatform)) return createPlatform;
                
                return null;
            }
            
            return null;
        }

        private RaycastHit CheckRaycastHit(Ray ray, int layerMask)
        {
            if (Physics.Raycast(ray, out _hit, Mathf.Infinity, ~layerMask))
            {
                if (_hit.collider.TryGetComponent(out PlatformConstructor createPlatformConstructor))
                {
                    _platformColorController.CheckLastMeshRenderer(createPlatformConstructor);
                    return _hit;
                }
                
                _platformColorController.CheckLastMeshRenderer(null);
                return _hit;
            }

            return _hit;
        }

        private bool CheckOnEmptyPlace(PlatformConstructor platformConstructor)
        {
            if (platformConstructor.IsEmpty == false) return true;
            
            _alertUI.FadeUIAnimation.AnimationPlay(_alertUI.SetText("Здесь уже установлена вышка"));
            return false;
        }
    }
}