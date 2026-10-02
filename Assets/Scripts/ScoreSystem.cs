using UnityEngine;

public class ScoreSystem : MonoBehaviour {
    public static ScoreSystem Instance { get; private set; }

    [SerializeField] private int baseScore = 100;
    [SerializeField] private float multiplier = 0.5f;

    public int Score { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(float m) {
        var points = baseScore + Mathf.RoundToInt(baseScore * m * multiplier);
        Score += points;
    }

    public void ReduceScore(int points) {
        Score -= points + baseScore;
    }

    public void ResetScore() {
        Score = 0;
    }
}
