using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour {
    [Header("Movement")] [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float acceleration = 20f;
    [SerializeField] private float deceleration = 25f;

    [Header("Input")] [SerializeField] private InputActionReference moveAction;

    private Rigidbody2D _rigidBody;
    private Vector2 _moveInput;

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        moveAction.action.Enable();
    }

    private void OnDisable() {
        moveAction.action.Disable();
    }

    private void Update() {
        _moveInput = moveAction.action.ReadValue<Vector2>();
        _moveInput = Vector2.ClampMagnitude(_moveInput, 1f);
    }

    private void FixedUpdate() {
        var targetVelocity = _moveInput * moveSpeed;
        var currentAcceleration = _moveInput.sqrMagnitude > 0.01f ? acceleration : deceleration;
        _rigidBody.linearVelocity =
            Vector2.MoveTowards(_rigidBody.linearVelocity, targetVelocity, currentAcceleration * Time.fixedDeltaTime);
    }
}
