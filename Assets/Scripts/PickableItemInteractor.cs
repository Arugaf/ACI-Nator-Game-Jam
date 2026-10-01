using UnityEngine;
using UnityEngine.InputSystem;

public class PickableItemInteractor : MonoBehaviour {
    [SerializeField] private float pickupDistance = 1.5f;
    [SerializeField] private Transform holdPoint;
    [SerializeField] private InputActionReference interactAction;

    private Camera _mainCamera;
    private PickableItem _hoveredItem;

    private bool _currentlyCarryingItem = false;

    private void Awake() {
        if (_mainCamera == null) _mainCamera = Camera.main;
    }

    private void OnEnable() {
        interactAction.action.performed += OnInteract;
        interactAction.action.Enable();
    }

    private void OnDisable() {
        interactAction.action.performed -= OnInteract;
        interactAction.action.Disable();
    }

    private void Update() {
        UpdateHoveredItem();
    }

    private void UpdateHoveredItem() {
        if (_currentlyCarryingItem) return;

        Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        var collider = Physics2D.OverlapPoint(mouseWorldPosition);
        var newHoveredItem = collider != null ? collider.GetComponent<PickableItem>() : null;
        if (newHoveredItem == _hoveredItem)
            return;

        if (_hoveredItem != null) _hoveredItem.SetHighlighted(false);

        _hoveredItem = newHoveredItem;
        if (newHoveredItem == null) return;

        var canPickup = CanPickup(newHoveredItem);
        newHoveredItem.SetHighlighted(canPickup);
    }

    private void OnInteract(InputAction.CallbackContext context) {
        if (_hoveredItem == null) return;

        if (!CanPickup(_hoveredItem)) return;

        _hoveredItem.Pickup(holdPoint);
        _currentlyCarryingItem = true;
        _hoveredItem.SetHighlighted(false);
        _hoveredItem = null;
    }

    private bool CanPickup(PickableItem item) {
        return Vector2.Distance(
            transform.position,
            item.transform.position
        ) <= pickupDistance;
    }
}