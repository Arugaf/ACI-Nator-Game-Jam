namespace PlayerEffects.Debuffs {
    public class Disappearance : StatusEffect {
        public override void Apply(EffectContext context) {
            throw new System.NotImplementedException();
        }

        public override void OnStart(EffectContext context) { }

        public override void OnUpdate(EffectContext context, float deltaTime) { }

        public override void OnEnd(EffectContext context) {
            Destroy(context.Target.GetComponent<PickableItemInteractor>()?.TakeCurrentItem()?.gameObject);
        }
    }
}