using System.Collections.Generic;
using PlayerEffects;
using UnityEngine;

[RequireComponent(typeof(GameTimer))]
public class ItemSequenceObserver : MonoBehaviour {
    [SerializeField] private ItemSequenceGenerator generator;

    [SerializeField] private int maxAttempts = 3;
    [SerializeField] private Knockback knockbackSource;

    public HashSet<AntiqueWithAura> Antiques { get; } = new();

    private GameTimer _gameTimer;

    private int _currentNumOfAttempts;

    private void Awake() {
        if (_gameTimer == null) _gameTimer = GetComponent<GameTimer>();
        _gameTimer.TimerFinished += OnTimerFinished;
    }

    private void OnDestroy() {
        _gameTimer.TimerFinished -= OnTimerFinished;
    }

    private void Start() {
        generator.GenerateSequence();
        _gameTimer.StartTimer();
        ScoreSystem.Instance.ResetScore();
    }

    public void InsertItem(Transform interactor, PickableItem item, Aura aura) {
        if (!item.CompareTag("Antique") || Antiques.Contains(new AntiqueWithAura(item.itemName, aura.auraName)) ||
            !generator.Antiques.Contains(new AntiqueWithAura(item.itemName, aura.auraName)) ||
            !aura.CompareTag("Aura")) {
            if (!generator.ContainsAura(aura)) {
                var effectController = interactor.GetComponent<EffectController>();

                if (effectController != null) {
                    var trueAura = generator.GetRandomAura();
                    foreach (var effect in trueAura.Effects) {
                        Debug.Log("New effect " + effect.GetType().Name);
                        effectController.AddEffect(effect, gameObject);
                    }
                }
            }

            Debug.Log("Inappropriate item");

            ++_currentNumOfAttempts;
            if (_currentNumOfAttempts >= maxAttempts && knockbackSource != null) {
                knockbackSource.Push(interactor.gameObject);
                _currentNumOfAttempts = 0;
            }

            Destroy(item.gameObject);
            Destroy(aura.gameObject);
            return;
        }

        Antiques.Add(new AntiqueWithAura(item.itemName, aura.auraName));
        Debug.Log("Item: " + item.itemName + " added");
        item.gameObject.SetActive(false);
        aura.gameObject.SetActive(false);

        CheckForNewRound();
    }

    private bool IsSequenceComplete() {
        return generator != null && Antiques.SetEquals(generator.Antiques);
    }

    private void CheckForNewRound() {
        if (!IsSequenceComplete()) return;

        ScoreSystem.Instance.AddScore(_gameTimer.Duration - _gameTimer.TimeLeft);
        Debug.Log("Current score: " + ScoreSystem.Instance.Score);

        StartNewRound();
    }

    private void StartNewRound() {
        _currentNumOfAttempts = 0;

        Debug.Log("Round Complete!");
        generator.GenerateSequence();
        Antiques.Clear();

        _gameTimer.StartTimer();
    }

    private void OnTimerFinished() {
        ScoreSystem.Instance.ReduceScore(0);
        Debug.Log("Current score: " + ScoreSystem.Instance.Score);

        StartNewRound();
    }
}
