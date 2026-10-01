using UnityEngine;

public class ItemDestroyer : MonoBehaviour {
    public void DestroyItem(PickableItem item) {
        if (item == null) return;

        Destroy(item.gameObject);
    }
}
