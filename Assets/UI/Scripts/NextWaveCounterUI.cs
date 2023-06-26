using System.Collections;
using UI.Animations;
using UnityEngine;
using UnityEngine.UI;
using Wave.Scripts;

namespace UI.Scripts
{
    public class NextWaveCounterUI : MonoBehaviour
    {
        [SerializeField] private WaveSpawner _waveSpawner;

        [SerializeField] private Text _NextWaveCounterText;
        [SerializeField] private FadeUIAnimation _fadeUIAnimation;

        private const float _delayOneSecond = 1;

        private void Start()
        {
            _waveSpawner.StartCountDownToNewWave += TimerBeforeNextWave;
            _NextWaveCounterText.gameObject.SetActive(false);
        }
        
        private void OnDestroy() => _waveSpawner.StartCountDownToNewWave -= TimerBeforeNextWave;

        private void ChangeCounterTextUI(string text) =>
            _NextWaveCounterText.text = text;

        private void TimerBeforeNextWave()
        {
            _NextWaveCounterText.gameObject.SetActive(true);
            StartCoroutine(CounterBeforeNextWave());
        } 

        private IEnumerator CounterBeforeNextWave()
        {
            _fadeUIAnimation.AnimationPlay(_NextWaveCounterText);
            for (int i = 0; i < _waveSpawner.CurrentDelayBeforeNextWave; i++)
            {
                yield return new WaitForSeconds(_delayOneSecond);
                ChangeCounterTextUI($"Next wave: {_waveSpawner.CurrentDelayBeforeNextWave - i - 1}");
            }
            yield return new WaitForSeconds(_delayOneSecond);
            
            _NextWaveCounterText.gameObject.SetActive(false);
        }
    }
}