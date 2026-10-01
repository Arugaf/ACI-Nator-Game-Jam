using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace PlayerEffects.Buffs {
    public class AutoFit : StatusEffect {
        [SerializeField] private ItemSequenceObserver observer;
        [SerializeField] private ItemSequenceGenerator generator;

        private bool _initialized;

        public override void Apply(EffectContext context) {
            throw new NotImplementedException();
        }

        public override void OnStart(EffectContext context) {
            _initialized = false;
        }

        public override void OnUpdate(EffectContext context, float deltaTime) {
            if (_initialized) return;

            if (observer == null) throw new Exception("Need observer");
            if (generator == null) throw new Exception("Need generator");

            var pickableItem = context.Target.GetComponent<PickableItemInteractor>()?.PeekItem()
                ?.GetComponent<PickableItem>();
            if (pickableItem == null) throw new Exception("Need PickableItem");

            if (generator.Antiques.Any(antique =>
                    generator.Antiques.Contains(new AntiqueWithAura(pickableItem.itemName, antique.AuraName)))) {
                _initialized = true;
                return;
            }

            var antiques = generator.Antiques.ToArray();
            foreach (var antique in antiques) {
                if (observer.Antiques.Contains(antique)) continue;
                pickableItem.itemName = antique.ItemName;
            }

            Debug.Log("AutoFit " + pickableItem.itemName);
            _initialized = true;
        }

        public override void OnEnd(EffectContext context) { }
    }
}
