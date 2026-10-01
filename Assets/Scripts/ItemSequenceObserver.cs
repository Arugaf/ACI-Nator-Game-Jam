using System.Collections.Generic;
using UnityEngine;

public class ItemSequenceObserver : MonoBehaviour {
    [SerializeField] private ItemSequenceGenerator generator;

    public HashSet<AntiqueWithAura> Antiques { get; } = new();

    public void Start() {
        generator.GenerateSequence();
    }

    public void InsertItem(PickableItem item, Aura aura) {
        if (!item.CompareTag("Antique") || Antiques.Contains(new AntiqueWithAura(item.itemName, aura.auraName)) ||
            !generator.Antiques.Contains(new AntiqueWithAura(item.itemName, aura.auraName)) ||
            !aura.CompareTag("Aura")) {
            Debug.Log("Inappropriate item");
            Destroy(item.gameObject);
            Destroy(aura.gameObject);
            return;
        }

        Antiques.Add(new AntiqueWithAura(item.itemName, aura.auraName));
        Debug.Log("Item: " + item.itemName + " added");
        item.gameObject.SetActive(false);
        aura.gameObject.SetActive(true);

        CheckForNewRound();
    }

    private bool IsSequenceComplete() {
        return generator != null && Antiques.SetEquals(generator.Antiques);
    }

    private void CheckForNewRound() {
        if (!IsSequenceComplete()) return;

        Debug.Log("Round Complete!");
        generator.GenerateSequence();
        Antiques.Clear();
    }
}
