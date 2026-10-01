using UnityEngine;

public class CameraBorderBoxColliderResizer : MonoBehaviour {
    private Camera _camera;
    private BoxCollider2D _boxCollider;

    private void Start() {
        _camera = Camera.main;
        _boxCollider = GetComponent<BoxCollider2D>();
        UpdateColliderSize();
    }

    private void UpdateColliderSize() {
        var newHeight = _camera.orthographicSize * 2f;
        var newWidth = newHeight * _camera.aspect;

        _boxCollider.size = new Vector2(
            newWidth,
            newHeight);
    }
}