using UnityEngine;

public class MainMenu : MonoBehaviour {
    public void PlayGame() {
        GameStateManager.Instance.StartGame();
    }

    public void ToggleAboutPage() { }

    public void QuitGame() {
        GameStateManager.Instance.QuitGame();
    }
}