using UnityEngine;

public class ItemDestroyer : MonoBehaviour {
    public void DestroyItem(PickableItem item, Aura aura) {
        if (item != null) Destroy(item.gameObject);
        if (aura != null) Destroy(aura.gameObject);
    }
}
