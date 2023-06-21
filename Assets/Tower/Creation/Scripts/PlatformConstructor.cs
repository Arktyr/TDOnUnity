using UnityEngine;

namespace Creation.Scripts
{
    public class PlatformConstructor : MonoBehaviour
    {
        private TowersTypes.TowerTypes _type;
        private bool _isEmpty;

        public bool IsEmpty => _isEmpty;

        public void SetTowerType(TowersTypes.TowerTypes type) => _type = type;

        public void TakePlace() => _isEmpty = true;
    }
}
