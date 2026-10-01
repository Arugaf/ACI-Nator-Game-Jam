using UnityEngine;

public class PickableItem : MonoBehaviour {
    public Color originalColor;

    [SerializeField] private Color highlightColor = Color.white;

    private SpriteRenderer _spriteRenderer;

    private void Awake() {
        if (_spriteRenderer == null) _spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = _spriteRenderer.color;
    }

    public void SetHighlighted(bool highlighted) {
        _spriteRenderer.color = highlighted ? highlightColor : originalColor;
    }

    public void Pickup(Transform interactor) {
        var newItem = Instantiate(gameObject, interactor, true);
        newItem.transform.localPosition = Vector3.zero;
        newItem.transform.localRotation = Quaternion.identity;

        var pickableItemComponent = newItem.GetComponent<PickableItem>();
        pickableItemComponent.originalColor = originalColor;
        newItem.GetComponent<PickableItem>().SetHighlighted(false);

        newItem.GetComponent<Collider2D>().enabled = false;

        SetHighlighted(false);
    }
}
