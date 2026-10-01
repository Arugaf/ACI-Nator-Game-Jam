using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Interactor))]
public class HighlightableItemInteractor : MonoBehaviour {
    [SerializeReference] private Predicate[] conditions;

    private Interactor _interactor;

    private Camera _mainCamera;

    private HighlightableItem _hoveredItem;

    private void Awake() {
        if (_interactor == null) _interactor = GetComponent<Interactor>();
        if (_mainCamera == null) _mainCamera = Camera.main;
    }

    private void Update() {
        UpdateHoveredItem();
    }

    private void UpdateHoveredItem() {
        Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        var collider = Physics2D.OverlapPoint(mouseWorldPosition);
        var newHoveredItem = collider != null ? collider.GetComponent<HighlightableItem>() : null;
        if (newHoveredItem == _hoveredItem)
            return;

        if (_hoveredItem != null) _hoveredItem.SetHighlighted(false);

        _hoveredItem = newHoveredItem;
        if (newHoveredItem == null) return;

        if (!_interactor.CanInteract(_hoveredItem.transform)) return;

        if (conditions.Any(condition => !condition.Evaluate(newHoveredItem.gameObject))) {
            return;
        }

        newHoveredItem.SetHighlighted(true);
    }
}
