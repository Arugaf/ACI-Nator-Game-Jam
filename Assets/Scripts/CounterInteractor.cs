using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Interactor))]
[RequireComponent(typeof(PickableItemInteractor))]
public class CounterInteractor : MonoBehaviour {
    [SerializeField] private InputActionReference interactAction;

    private Interactor _interactor;
    private PickableItemInteractor _pickableItemInteractor;

    private Camera _mainCamera;

    private void Awake() {
        if (_interactor == null) _interactor = GetComponent<Interactor>();
        if (_pickableItemInteractor == null) _pickableItemInteractor = GetComponent<PickableItemInteractor>();
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
        var counter = collider != null ? collider.GetComponent<Counter>() : null;

        if (counter == null) return;

        if (!_interactor.CanInteract(counter.transform)) return;

        counter.AcceptItem(_pickableItemInteractor.TakeCurrentItem());
    }
}
