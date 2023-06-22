using UI.Scripts;
using UnityEngine;

namespace Creation.Scripts
{
    [RequireComponent(typeof(MeshRenderer))]
    public class PlatformRaycaster : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private PlatformColorController _platformColorController;
        [SerializeField] private Alert _alert;
      
        private Ray _ray;
        private RaycastHit _hit;
        
        private int _layerMask;
        
        private void Start() => _layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");

        public PlatformConstructor GetCreatePlatform()
        {
            _ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            _hit = CheckRaycastHit(_ray, _layerMask);
            
            if (_hit.collider != null && _hit.collider.TryGetComponent(out PlatformConstructor createPlatform))
            {
                if (CheckOnEmptyPlace(createPlatform)) return createPlatform;
                
                return null;
            }
            
            return null;
        }

        private RaycastHit CheckRaycastHit(Ray ray, int layerMask)
        {
            if (Physics.Raycast(ray, out _hit, Mathf.Infinity, ~layerMask))
            {
                MeshRenderer createPlatformMesh = _hit.collider.GetComponent<MeshRenderer>();
                
                _platformColorController.CheckLastMeshRenderer(createPlatformMesh);
                return _hit;
            }
            
            _platformColorController.CheckLastMeshRenderer(null);
            return _hit;
        }

        private bool CheckOnEmptyPlace(PlatformConstructor platformConstructor)
        {
            if (platformConstructor.IsEmpty == false) return true;

            MeshRenderer createPlatformMesh = platformConstructor.GetComponent<MeshRenderer>();
            
            _platformColorController.ChangePlatformColor(createPlatformMesh, Color.red);
            _alert.AnimationPlay("Здесь уже установлена вышка");
            return false;
        }
    }
}