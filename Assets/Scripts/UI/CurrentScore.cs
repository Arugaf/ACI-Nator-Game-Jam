using System;
using TMPro;
using UnityEngine;

namespace UI {
    [RequireComponent(typeof(TMP_Text))]
    public class CurrentScore : MonoBehaviour {
        private TMP_Text _scoreText;

        private void Awake() {
            if (_scoreText == null) _scoreText = GetComponent<TMP_Text>();
        }

        private void Start() {
            ScoreSystem.Instance.OnScoreChanged += UpdateScore;
            UpdateScore(ScoreSystem.Instance.Score);
        }

        private void OnDisable() {
            if (ScoreSystem.Instance == null) return;

            ScoreSystem.Instance.OnScoreChanged -= UpdateScore;
        }

        private void UpdateScore(int score) {
            _scoreText.text = "Current score: " + score.ToString();
        }
    }
}
