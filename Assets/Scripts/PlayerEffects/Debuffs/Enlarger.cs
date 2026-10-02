using System.Collections;
using UnityEngine;

namespace PlayerEffects.Debuffs {
    public class Enlarger : StatusEffect {
        [SerializeField] private float scalingProcessDuration = 0.25f;
        [SerializeField] private float scaleMultiplier = 2f;

        private Vector3 _originalScale;
        private Coroutine _scaleCoroutine;

        private Transform _target;

        public override void Apply(EffectContext context) {
            throw new System.NotImplementedException();
        }

        public override void OnStart(EffectContext context) {
            Debug.Log("hi");
            _target = context.Target.transform;
            Debug.Log(_target);
            _originalScale = _target.localScale;
            StartScale(_originalScale * scaleMultiplier);
        }

        public override void OnUpdate(EffectContext context, float deltaTime) { }

        public override void OnEnd(EffectContext context) {
            StartScale(_originalScale);
        }
        
        private void StartScale(Vector3 targetScale)
        {
            if (_scaleCoroutine != null)
            {
                StopCoroutine(_scaleCoroutine);
            }

            _scaleCoroutine = StartCoroutine(Scale(targetScale));
        }

        private IEnumerator Scale(Vector3 targetScale)
        {
            var startScale = _target.localScale;
            var elapsed = 0f;

            while (elapsed < scalingProcessDuration)
            {
                elapsed += Time.deltaTime;

                var progress = Mathf.Clamp01(elapsed / scalingProcessDuration);

                _target.localScale = Vector3.Lerp(
                    startScale,
                    targetScale,
                    progress
                );

                yield return null;
            }

            _target.localScale = targetScale;
            _scaleCoroutine = null;
        }
    }
}
