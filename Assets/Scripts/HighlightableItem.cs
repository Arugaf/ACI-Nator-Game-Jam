using UnityEngine;

public class HighlightableItem : MonoBehaviour {
    [SerializeField] private Color originalColor = Color.white;
    [SerializeField] private Color highlightColor = Color.white;

    private SpriteRenderer _spriteRenderer;
    
    private bool _highlighted;

    private void Awake() {
        if (_spriteRenderer == null) _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = originalColor;
    }

    public void SetHighlighted(bool highlighted) {
        _highlighted = highlighted;
        _spriteRenderer.color = highlighted ? highlightColor : originalColor;
    }
    
    public bool IsHighlighted() {
        return _highlighted;
    }
}
