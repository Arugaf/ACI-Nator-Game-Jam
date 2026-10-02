using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(Interactor))]
public class AuraInteractor : MonoBehaviour {
    public bool currentlyWithAura;

    [SerializeField] private PickableItemInteractor pickableItemInteractor;
    [SerializeField] private InputActionReference interactAction;

    private Interactor _interactor;

    private Camera _mainCamera;

    private Aura _currentAura;
    private AuraLight _auraLight;

    public Aura TakeCurrentAura() {
        var aura = _currentAura;
        _currentAura = null;
        currentlyWithAura = false;

        _auraLight?.ResetLight();

        return aura;
    }

    private void Awake() {
        if (_interactor == null) _interactor = GetComponent<Interactor>();
        if (_mainCamera == null) _mainCamera = Camera.main;
        if (_auraLight == null) _auraLight = GetComponent<AuraLight>();
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
        var hoveredAura = collider != null ? collider.GetComponent<Aura>() : null;

        if (hoveredAura == null) return;

        if (!_interactor.CanInteract(hoveredAura.transform)) return;

        if (currentlyWithAura || !pickableItemInteractor.currentlyCarryingItem) return;

        _currentAura = hoveredAura.Pickup(transform);
        currentlyWithAura = true;
        _auraLight?.SetAura(_currentAura);
    }
}
