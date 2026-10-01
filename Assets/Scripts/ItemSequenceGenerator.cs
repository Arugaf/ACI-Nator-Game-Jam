using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSequenceGenerator : MonoBehaviour {
    public int antiquesSlotsCount = 2;

    [SerializeField] private PickableItem[] antiques;

    public HashSet<string> Antiques { get; } = new();

    private void Awake() {
        if (antiques.Length < antiquesSlotsCount) {
            throw new Exception("Not enough antiques");
        }
    }

    public void GenerateSequence() {
        Antiques.Clear();

        var ids = new List<int>();

        for (var i = 0; i < antiquesSlotsCount; i++) {
            var id = Random.Range(0, antiques.Length);
            while (ids.Contains(id)) {
                id = Random.Range(0, antiques.Length);
            }

            ids.Add(id);
        }

        Debug.Log("New Round: ");
        foreach (var currentId in ids) {
            Antiques.Add(antiques[currentId].itemName);
            Debug.Log("Item: " + antiques[currentId].itemName);
        }
    }
}
