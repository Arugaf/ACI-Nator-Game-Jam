using UnityEngine;

public class MainMenu : MonoBehaviour {
    [SerializeField] private GameObject mainMenuPage;
    [SerializeField] private GameObject howToPlayPage;
    [SerializeField] private GameObject controlsPage;
    [SerializeField] private GameObject aboutPage;

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

    public void ToggleAboutPage() {
        aboutPage.SetActive(!aboutPage.activeSelf);
        mainMenuPage.SetActive(!aboutPage.activeSelf);
    }

    public void QuitGame() {
        GameStateManager.Instance.QuitGame();
    }
}
