using UnityEngine;

public class CameraBounds : MonoBehaviour {
    [SerializeField] private Camera targetCamera;

    private EdgeCollider2D _top;
    private EdgeCollider2D _bottom;
    private EdgeCollider2D _left;
    private EdgeCollider2D _right;

    private void Awake() {
        if (targetCamera == null)
            targetCamera = Camera.main;

        CreateColliders();
        UpdateColliders();
    }

    private void LateUpdate() {
        UpdateColliders();
    }

    private void CreateColliders() {
        _top = CreateCollider("Top");
        _bottom = CreateCollider("Bottom");
        _left = CreateCollider("Left");
        _right = CreateCollider("Right");
    }

    private EdgeCollider2D CreateCollider(string name) {
        var obj = new GameObject(name);

        obj.transform.SetParent(transform);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;

        return obj.AddComponent<EdgeCollider2D>();
    }

    private void UpdateColliders() {
        var bottomLeft = targetCamera.ViewportToWorldPoint(
            new Vector3(0f, 0f, 0f)
        );

        var topLeft = targetCamera.ViewportToWorldPoint(
            new Vector3(0f, 1f, 0f)
        );

        var bottomRight = targetCamera.ViewportToWorldPoint(
            new Vector3(1f, 0f, 0f)
        );

        var topRight = targetCamera.ViewportToWorldPoint(
            new Vector3(1f, 1f, 0f)
        );

        Vector2 bl = transform.InverseTransformPoint(bottomLeft);
        Vector2 br = transform.InverseTransformPoint(bottomRight);
        Vector2 tl = transform.InverseTransformPoint(topLeft);
        Vector2 tr = transform.InverseTransformPoint(topRight);

        _bottom.points = new[] {
            bl,
            br
        };

        _top.points = new[] {
            tl,
            tr
        };

        _left.points = new[] {
            bl,
            tl
        };

        _right.points = new[] {
            br,
            tr
        };
    }
}
