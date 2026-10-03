using TMPro;
using UnityEngine;

namespace UI {
    [RequireComponent(typeof(TMP_Text))]
    public class ItemsCounter : MonoBehaviour {
        [SerializeField] private ItemSequenceObserver observer;

        private TMP_Text _counterText;

        private void Awake() {
            if (_counterText == null) _counterText = GetComponent<TMP_Text>();
        }

        private void OnEnable() {
            observer.OnNumOfAntiquesChanged += UpdateCounter;
            UpdateCounter();
        }

        private void OnDisable() {
            observer.OnNumOfAntiquesChanged -= UpdateCounter;
        }

        private void UpdateCounter() {
            _counterText.text = "Items left to gather: " + observer.GetNumOfAntiquesLeft();
        }
    }
}
