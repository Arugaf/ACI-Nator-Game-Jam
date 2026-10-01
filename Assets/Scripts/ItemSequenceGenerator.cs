using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSequenceGenerator : MonoBehaviour {
    public int antiquesSlotsCount = 2;
    public int aurasSlotsCount = 2;

    [SerializeField] private PickableItem[] antiques;
    [SerializeField] private Aura[] auras;

    public HashSet<AntiqueWithAura> Antiques { get; } = new();

    private void Awake() {
        if (antiques.Length < antiquesSlotsCount) {
            throw new Exception("Not enough antiques");
        }

        if (auras.Length < aurasSlotsCount) {
            throw new Exception("Not enough auras");
        }
    }

    public void GenerateSequence() {
        Antiques.Clear();

        var idsAntiques = new List<int>();
        var idsAuras = new List<int>();

        for (var i = 0; i < antiquesSlotsCount; i++) {
            var idAntique = Random.Range(0, antiques.Length);
            while (idsAntiques.Contains(idAntique)) {
                idAntique = Random.Range(0, antiques.Length);
            }

            idsAntiques.Add(idAntique);
            idsAuras.Add(Random.Range(0, auras.Length));
        }

        Debug.Log("New Round: ");
        for (var i = 0; i < idsAntiques.Count; i++) {
            Antiques.Add(new AntiqueWithAura(antiques[idsAntiques[i]].itemName, auras[idsAuras[i]].auraName));
            Debug.Log("Item: " + antiques[idsAntiques[i]].itemName + " aura: " + auras[idsAuras[i]].auraName);
        }
    }
}
