using UnityEngine;

namespace Wave
{
    [System.Serializable]
    public class Wave
    {
        [SerializeField] private WaveSettings[] settings;
        [SerializeField] private float delayBeforeNextWave;
        public WaveSettings[] Settings => settings;
        public float DelayBeforeNextWave => delayBeforeNextWave;
    }
}