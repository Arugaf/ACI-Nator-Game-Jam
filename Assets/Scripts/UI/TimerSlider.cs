using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    [RequireComponent(typeof(Slider))]
    public class TimerSlider : MonoBehaviour {
        [SerializeField] private GameTimer gameTimer;

        private Slider _slider;

        private void Awake() {
            if (_slider == null) _slider = GetComponent<Slider>();
            gameTimer.TimerUpdated += OnTimerUpdated;
        }

        private void Start() {
            _slider.minValue = 0f;
            _slider.maxValue = 1f;
            _slider.value = 1f;
        }

        private void OnDestroy() {
            gameTimer.TimerUpdated -= OnTimerUpdated;
        }

        private void OnTimerUpdated(float timeLeft) {
            var normalizedTime = timeLeft / gameTimer.Duration;
            _slider.value = normalizedTime;
        }
    }
}
