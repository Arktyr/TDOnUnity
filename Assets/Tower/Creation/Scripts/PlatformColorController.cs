using UnityEngine;

namespace Creation.Scripts
{
    [RequireComponent(typeof(MeshRenderer))]
    public class PlatformColorController : MonoBehaviour
    {
        private MeshRenderer _lastMeshRenderer;

        public void CheckLastMeshRenderer(PlatformConstructor createPlatformConstructor)
        {
            if (_lastMeshRenderer != null) ChangePlatformColor(_lastMeshRenderer, Color.white);
            
            if (createPlatformConstructor == null) return;
            
            if (createPlatformConstructor.TryGetComponent(out MeshRenderer createPlatformMeshRenderer))
            {
                SetLastMeshRenderer(createPlatformMeshRenderer);

                if (createPlatformConstructor.IsEmpty)
                {
                    ChangePlatformColor(createPlatformMeshRenderer, Color.red);
                    return;
                }
                
                ChangePlatformColor(createPlatformMeshRenderer, Color.green);
            }
        }
        
        public void ChangePlatformColor(MeshRenderer platform, Color color) => platform.material.color = color;

        private void SetLastMeshRenderer(MeshRenderer createPlatformMeshRenderer) =>
            _lastMeshRenderer = createPlatformMeshRenderer;
    }
}