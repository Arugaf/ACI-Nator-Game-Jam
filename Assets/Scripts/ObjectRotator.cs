using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectRotation : MonoBehaviour {
    private Camera _mainCamera;

    private void Awake() {
        _mainCamera = Camera.main;
    }

    private void Update() {
        if (Mouse.current == null) return;

        var mouseScreenPosition = Mouse.current.position.ReadValue();
        var mouseWorldPosition =
            _mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        Vector2 direction = mouseWorldPosition - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
