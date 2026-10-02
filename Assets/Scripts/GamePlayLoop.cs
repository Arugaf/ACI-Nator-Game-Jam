using UnityEngine;

public class GamePlayLoop : MonoBehaviour {
    [SerializeField] private GameTimer gameTimer;

    private void Awake() {
        gameTimer.TimerFinished += OnTimerFinished;
    }

    private void OnDestroy() {
        gameTimer.TimerFinished -= OnTimerFinished;
    }

    private void Start() {
        gameTimer.StartTimer();
    }

    private void OnTimerFinished() {
        GameStateManager.Instance.GameOver();
    }
}