using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

namespace PlayerEffects.Debuffs {
    public class RandomLightFlicker : StatusEffect {
        [SerializeField] private Light2D sceneLight;
        [SerializeField] private Canvas[] canvases;
        [SerializeField] private float minInterval = 0.1f;
        [SerializeField] private float maxInterval = 0.5f;

        private Camera _camera;
        private Color _cameraOriginalColor;

        private void Awake() {
            _originalIntensity = sceneLight.intensity;
            _camera = Camera.main;
            _cameraOriginalColor = _camera.backgroundColor;
        }

        public override void Apply(EffectContext context) {
            throw new System.NotImplementedException();
        }

        public override void OnStart(EffectContext context) {
            StartCoroutine(Flicker());
        }

        public override void OnUpdate(EffectContext context, float deltaTime) { }

        public override void OnEnd(EffectContext context) { }

        private float _originalIntensity;

        private IEnumerator Flicker() {
            var elapsed = 0f;

            while (elapsed < Duration) {
                var lightEnabled = Random.value > 0.5f;

                sceneLight.intensity = lightEnabled
                    ? _originalIntensity
                    : 0f;

                _camera.backgroundColor = lightEnabled
                    ? _cameraOriginalColor
                    : Color.black;

                foreach (var canvas in canvases) {
                    canvas.enabled = lightEnabled;
                }

                var interval = Random.Range(minInterval, maxInterval);

                yield return new WaitForSeconds(interval);

                elapsed += interval;
            }

            sceneLight.intensity = _originalIntensity;
            foreach (var canvas in canvases) {
                canvas.enabled = true;
            }
            _camera.backgroundColor = _cameraOriginalColor;
        }
    }
}
