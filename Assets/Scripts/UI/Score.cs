using TMPro;
using UnityEngine;

namespace UI {
    [RequireComponent(typeof(TMP_Text))]
    public class Score : MonoBehaviour {
        private TMP_Text _scoreText;

        private void Awake() {
            if (_scoreText == null) _scoreText = GetComponent<TMP_Text>();
        }

        private void Start() {
            _scoreText.SetText(ScoreSystem.Instance.Score.ToString());
        }
    }
}
