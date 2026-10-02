using UnityEngine;

public class FinalSceneMenu : MonoBehaviour {
    public void BackToMainMenu() {
        GameStateManager.Instance.BackToMenu();
    }

    public void QuitGame() {
        GameStateManager.Instance.QuitGame();
    }
}