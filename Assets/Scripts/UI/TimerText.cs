using TMPro;
using UnityEngine;

namespace UI {
    [RequireComponent(typeof(TMP_Text))]
    public class TimerText : MonoBehaviour {
        [SerializeField] private GameTimer gameTimer;

        private TMP_Text _timerText;

        private void Awake() {
            if (_timerText == null) _timerText = GetComponent<TMP_Text>();
            gameTimer.TimerUpdated += OnTimerUpdated;
        }

        private void OnDestroy() {
            gameTimer.TimerUpdated -= OnTimerUpdated;
        }

        private void OnTimerUpdated(float timeLeft) {
            var seconds = Mathf.CeilToInt(timeLeft);
            var minutes = seconds / 60;

            seconds %= 60;

            _timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }
}
