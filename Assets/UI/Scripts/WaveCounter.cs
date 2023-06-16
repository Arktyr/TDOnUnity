using System;
using Ground;
using TMPro;
using UnityEngine;

namespace UI.Scripts
{
    public class WaveCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Wavespawner waveSpawner;
        public Action CurrentWaveCounter;
        
        private void OnEnable()
        {
            CurrentWaveCounter += ChangeTextInWaveCounterUI;
        }

        private void OnDisable()
        {
            CurrentWaveCounter -= ChangeTextInWaveCounterUI;
        }
        
        private void ChangeTextInWaveCounterUI()
        {
            text.SetText($"Wave Number: {waveSpawner.CurrentWaveIndex + 1}");
        }
    }
}
