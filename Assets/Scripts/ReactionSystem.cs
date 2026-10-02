using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionSystem : MonoBehaviour {
    public enum Category {
        Wide,
        Long,
        Round,
        Triangle
    }

    [System.Serializable]
    public class CategoryReaction {
        public Category category;
        public Sprite negativeReaction;
    }

    [SerializeField] private CategoryReaction[] categories;

    [SerializeField] private Sprite positiveReaction;
    [SerializeField] private Sprite veryNegativeReaction;

    [SerializeField] private SpriteRenderer reactionRenderer;
    [SerializeField] private float reactionDuration = 3f;

    private Sprite _defaultSprite;
    private Coroutine _reactionCoroutine;

    private void Awake() {
        _defaultSprite = reactionRenderer.sprite;
    }

    public void React(Category requiredCategory, List<Category> itemCategories) {
        var reaction = veryNegativeReaction;

        if (itemCategories.Contains(requiredCategory)) {
            foreach (var category in categories) {
                if (category.category == requiredCategory) {
                    reaction = category.negativeReaction;
                }
            }
        }

        if (_reactionCoroutine != null) {
            StopCoroutine(_reactionCoroutine);
        }

        _reactionCoroutine = StartCoroutine(ShowReaction(reaction));
    }

    public void ReactPositive() {
        if (_reactionCoroutine != null) {
            StopCoroutine(_reactionCoroutine);
        }

        _reactionCoroutine = StartCoroutine(ShowReaction(positiveReaction));
    }

    private IEnumerator ShowReaction(Sprite reaction) {
        reactionRenderer.sprite = reaction;

        yield return new WaitForSeconds(reactionDuration);

        reactionRenderer.sprite = _defaultSprite;
        _reactionCoroutine = null;
    }
}