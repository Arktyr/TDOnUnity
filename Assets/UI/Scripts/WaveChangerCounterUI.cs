using System.Collections;
using UI.Animations;
using UnityEngine;
using UnityEngine.UI;
using Wave.Scripts;

namespace UI.Scripts
{
    public class WaveChangerCounterUI : MonoBehaviour
    {
        [SerializeField] private WaveSpawner _waveSpawner;
        [SerializeField] private WaveCounterUIAnimation _waveCounterUIAnimation;
        
        [SerializeField] private Text _waveCounterText;

        private void Start() => _waveCounterUIAnimation.PlayAnimation(_waveCounterText);

        private void OnEnable() => _waveSpawner.WaveHasChanged += TextInWaveHasChangedCounterUI;

        private void OnDisable() => _waveSpawner.WaveHasChanged -= TextInWaveHasChangedCounterUI;

        private void TextInWaveHasChangedCounterUI() =>
            _waveCounterText.text = $"Wave Number: {_waveSpawner.CurrentWaveIndex + 1}";
    }
}
