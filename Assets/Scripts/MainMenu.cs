using UnityEngine;

public class MainMenu : MonoBehaviour {
    [SerializeField] private GameObject mainMenuPage;
    [SerializeField] private GameObject howToPlayPage;
    
    public void PlayGame() {
        GameStateManager.Instance.StartGame();
    }

    public void ToggleHowToPlayPage() {
        howToPlayPage.SetActive(!howToPlayPage.activeSelf);
        mainMenuPage.SetActive(!howToPlayPage.activeSelf);
    }

    public void ToggleAboutPage() { }

    public void QuitGame() {
        GameStateManager.Instance.QuitGame();
    }
}
