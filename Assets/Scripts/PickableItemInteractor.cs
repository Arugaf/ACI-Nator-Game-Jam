using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Interactor))]
public class PickableItemInteractor : MonoBehaviour {
    [SerializeField] private Transform holdPoint;
    [SerializeField] private InputActionReference interactAction;

    private Interactor _interactor;

    private Camera _mainCamera;

    private PickableItem _hoveredItem;

    public bool CurrentlyCarryingItem { get; private set; }

    private void Awake() {
        if (_interactor == null) _interactor = GetComponent<Interactor>();
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
        SearchPickableItem();
    }

    private void SearchPickableItem() {
        if (CurrentlyCarryingItem) return;

        Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        var collider = Physics2D.OverlapPoint(mouseWorldPosition);
        var newHoveredItem = collider != null ? collider.GetComponent<PickableItem>() : null;

        if (newHoveredItem != null && newHoveredItem == _hoveredItem)
            return;

        _hoveredItem = newHoveredItem;
    }

    private void OnInteract(InputAction.CallbackContext context) {
        if (_hoveredItem == null) return;

        if (!_interactor.CanInteract(_hoveredItem.transform)) return;

        _hoveredItem.Pickup(holdPoint);
        CurrentlyCarryingItem = true;
        _hoveredItem = null;
    }
}