using System;
using System.Collections;
using UnityEngine;

public class GameTimer : MonoBehaviour {
    [SerializeField] private float duration = 60f;

    public event Action<float> TimerUpdated;
    public event Action TimerFinished;

    public float TimeLeft { get; private set; }
    public float Duration => duration;

    private Coroutine _timerCoroutine;

    public void StartTimer() {
        StopTimer();

        TimeLeft = duration;
        TimerUpdated?.Invoke(TimeLeft);

        _timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    public void StopTimer() {
        if (_timerCoroutine == null) return;

        StopCoroutine(_timerCoroutine);
        _timerCoroutine = null;
    }

    private IEnumerator TimerCoroutine() {
        while (TimeLeft > 0f) {
            yield return null;

            TimeLeft -= Time.deltaTime;
            if (TimeLeft < 0f) TimeLeft = 0f;

            TimerUpdated?.Invoke(TimeLeft);
        }

        _timerCoroutine = null;
        TimerFinished?.Invoke();
    }
}