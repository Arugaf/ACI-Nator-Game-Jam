using UnityEngine;

public class MainMenu : MonoBehaviour {
    [SerializeField] private GameObject mainMenuPage;
    [SerializeField] private GameObject howToPlayPage;
    [SerializeField] private GameObject controlsPage;

    public void PlayGame() {
        GameStateManager.Instance.StartGame();
    }

    public void ToggleHowToPlayPage() {
        howToPlayPage.SetActive(!howToPlayPage.activeSelf);
        mainMenuPage.SetActive(!howToPlayPage.activeSelf);
    }

    public void ToggleControlsPage() {
        controlsPage.SetActive(!controlsPage.activeSelf);
        mainMenuPage.SetActive(!controlsPage.activeSelf);
    }

    public void ToggleAboutPage() { }

    public void QuitGame() {
        GameStateManager.Instance.QuitGame();
    }
}
