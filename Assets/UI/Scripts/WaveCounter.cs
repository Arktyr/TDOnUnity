using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Wave;

namespace UI.Scripts
{
    public class WaveCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text waveCounterText;
        [SerializeField] private TMP_Text delayBeforeNextWaveCounterText;
        [SerializeField] private WaveSpawner waveSpawner;
        public Action ChangeWaveCounter;
        public Action NextWave;
        
        private void OnEnable()
        {
            ChangeWaveCounter += ChangeTextInWaveCounterUI;
            NextWave += Timer;
        }

        private void OnDisable()
        {
            ChangeWaveCounter -= ChangeTextInWaveCounterUI;
            NextWave -= Timer;
        }
        
        private void ChangeTextInWaveCounterUI()
        {
            waveCounterText.SetText($"Wave Number: {waveSpawner.CurrentWaveIndex + 1}");
        }

        private void Timer()
        {
            StartCoroutine(TimerBeforeNextWave());
        }

        private IEnumerator TimerBeforeNextWave()
        {
            for (int i = 0; i < waveSpawner.CurrentDelayBeforeNextWave; i++)
            {
                yield return new WaitForSeconds(1);
                delayBeforeNextWaveCounterText.SetText($"Next wave: {waveSpawner.CurrentDelayBeforeNextWave - i - 1}");
            }
            yield return new WaitForSeconds(1);
            delayBeforeNextWaveCounterText.SetText($"");
        }
    }
}
