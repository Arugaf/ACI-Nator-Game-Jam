using System;

public struct AntiqueWithAura : IEquatable<AntiqueWithAura> {
    public string ItemName;
    public string AuraName;

    public AntiqueWithAura(string itemName, string auraName) {
        ItemName = itemName;
        AuraName = auraName;
    }

    public bool Equals(AntiqueWithAura other) {
        return ItemName == other.ItemName && AuraName == other.AuraName;
    }

    public override bool Equals(object obj) {
        return obj is AntiqueWithAura other && Equals(other);
    }

    public override int GetHashCode() {
        return HashCode.Combine(ItemName, AuraName);
    }
}
