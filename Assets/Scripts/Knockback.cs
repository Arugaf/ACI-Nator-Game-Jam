using UnityEngine;

public class Knockback : MonoBehaviour {
    [SerializeField] private float force = 10f;

    public void Push(GameObject target) {
        if (target == null) return;

        var rb = target.GetComponent<Rigidbody2D>();

        if (rb == null) return;

        Vector2 direction = target.transform.position - transform.position;

        if (!(direction.sqrMagnitude > 0f)) return;

        direction.Normalize();
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }
}