using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(Interactor))]
public class PickableItemInteractor : MonoBehaviour {
    public bool currentlyCarryingItem;

    [SerializeField] private Transform holdPoint;
    [SerializeField] private InputActionReference interactAction;

    private Interactor _interactor;

    private Camera _mainCamera;

    private PickableItem _currentItem;

    public PickableItem TakeCurrentItem() {
        var item = _currentItem;
        _currentItem = null;
        currentlyCarryingItem = false;
        return item;
    }

    public PickableItem PeekItem() {
        return _currentItem;
    }

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

    private void OnInteract(InputAction.CallbackContext context) {
        Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        var collider = Physics2D.OverlapPoint(mouseWorldPosition);
        var hoveredItem = collider != null ? collider.GetComponent<PickableItem>() : null;

        if (hoveredItem == null) return;

        if (!_interactor.CanInteract(hoveredItem.transform)) return;

        _currentItem = hoveredItem.Pickup(transform, holdPoint);
        currentlyCarryingItem = true;
    }
}
