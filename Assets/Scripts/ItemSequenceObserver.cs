using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSequenceObserver : MonoBehaviour {
    [SerializeField] private ItemSequenceGenerator generator;

    public HashSet<string> Antiques { get; } = new();

    public void Start() {
        generator.GenerateSequence();
    }

    public void InsertItem(PickableItem item) {
        if (!item.CompareTag("Antique") || Antiques.Contains(item.itemName) ||
            !generator.Antiques.Contains(item.itemName)) {
            Debug.Log("Inappropriate item");
            Destroy(item.gameObject);
            return;
        }

        Antiques.Add(item.itemName);
        Debug.Log("Item: " + item.itemName + " added");
        item.gameObject.SetActive(false);

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
