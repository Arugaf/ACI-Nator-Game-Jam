using UnityEngine;

public class HighlightableItem : MonoBehaviour {
    [SerializeField] private Color originalColor = Color.white;
    [SerializeField] private Color highlightColor = Color.white;

    private SpriteRenderer _spriteRenderer;

    private void Awake() {
        if (_spriteRenderer == null) _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = originalColor;
    }

    public void SetHighlighted(bool highlighted) {
        _spriteRenderer.color = highlighted ? highlightColor : originalColor;
    }
}
