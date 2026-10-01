using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSequenceObserver : MonoBehaviour {
    [SerializeField] private ItemSequenceGenerator generator;

    private HashSet<string> _antiques = new();

    public void Start() {
        generator.GenerateSequence();
    }

    public void InsertItem(PickableItem item) {
        if (!item.CompareTag("Antique") || _antiques.Contains(item.itemName) ||
            !generator.Antiques.Contains(item.itemName)) {
            Debug.Log("Inappropriate item");
            Destroy(item.gameObject);
            return;
        }

        _antiques.Add(item.itemName);
        Debug.Log("Item: " + item.itemName + " added");
        item.gameObject.SetActive(false);

        CheckForNewRound();
    }

    private bool IsSequenceComplete() {
        return generator != null && _antiques.SetEquals(generator.Antiques);
    }

    private void CheckForNewRound() {
        if (!IsSequenceComplete()) return;

        Debug.Log("Round Complete!");
        generator.GenerateSequence();
        _antiques.Clear();
    }
}