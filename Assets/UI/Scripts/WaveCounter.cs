using System.Collections;
using TMPro;
using UnityEngine;
using Wave.Scripts;

namespace UI.Scripts
{
    public class WaveCounter : MonoBehaviour
    {
        [SerializeField] private Wavespawner waveSpawner;
        [SerializeField] private TMP_Text waveCounterText;
        [SerializeField] private TMP_Text delayBeforeNextWaveCounterText;
        
        private void OnEnable()
        {
            waveSpawner.WaveHasChanged += TextInWaveHasChangedCounterUI;
            waveSpawner.StartCountDownToNewWave += Timer;
        }

        private void OnDisable()
        {
            waveSpawner.WaveHasChanged -= TextInWaveHasChangedCounterUI;
            waveSpawner.StartCountDownToNewWave -= Timer;
        }
        
        private void TextInWaveHasChangedCounterUI() => waveCounterText.SetText($"Wave Number: {waveSpawner.CurrentWaveIndex + 1}");

        private void Timer() => StartCoroutine(TimerBeforeNextWave());

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
