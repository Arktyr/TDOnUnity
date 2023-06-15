using System;
using Ground;
using TMPro;
using UnityEngine;

namespace UI.Scripts
{
    public class WaveCounter : MonoBehaviour
    {
        private TMP_Text _text;
        [SerializeField] private Wavespawner waveSpawner;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
           ChangeTextInWaveCounterUI();
        }

        private void ChangeTextInWaveCounterUI()
        {
            _text.SetText($"Wave Number: {waveSpawner.CurrentWaveIndex + 1}");
        }
    }
}
