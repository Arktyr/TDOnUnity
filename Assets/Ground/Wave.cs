using UnityEngine;

namespace Ground
{
    [System.Serializable]
    public class Wave
    {
        [SerializeField] private WaveSettings[] settings;
        public WaveSettings[] Settings => settings;
    }
}