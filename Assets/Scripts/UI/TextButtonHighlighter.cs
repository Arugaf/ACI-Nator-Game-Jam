using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI {
    public class TextButtonHighlighter : MonoBehaviour,
        IPointerEnterHandler,
        IPointerExitHandler {
        [SerializeField] private Color highLightColor = Color.softYellow;

        [SerializeField] private TMP_Text text;

        private Color _originalColor;

        private void OnEnable() {
            _originalColor = text.color;
        }

        private void OnDisable() {
            text.color = _originalColor;
        }

        public void OnPointerEnter(PointerEventData eventData) {
            _originalColor = text.color;
            text.color = highLightColor;
        }

        public void OnPointerExit(PointerEventData eventData) {
            text.color = _originalColor;
        }
    }
}
