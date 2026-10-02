using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {
    public static GameStateManager Instance { get; private set; }

    public GameState CurrentState { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        CurrentState = GetCurrentStateByScene(SceneManager.GetActiveScene());
    }

    public void StartGame() {
        CurrentState = GameState.Playing;
        SceneManager.LoadScene("MainScene");
    }

    public void PauseGame() {
        if (CurrentState != GameState.Playing)
            return;

        CurrentState = GameState.Paused;
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        if (CurrentState != GameState.Paused)
            return;

        CurrentState = GameState.Playing;
        Time.timeScale = 1f;
    }

    public void GameOver() {
        CurrentState = GameState.GameOver;
        Time.timeScale = 1f;

        SceneManager.LoadScene("FinalScene");
    }

    public void BackToMenu() {
        CurrentState = GameState.Menu;
        Time.timeScale = 1f;

        SceneManager.LoadScene("InitialScene");
    }

    public void QuitGame() {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public GameState GetCurrentStateByScene(Scene scene) {
        return scene.name switch {
            "MainScene" => GameState.Playing,
            "FinalScene" => GameState.GameOver,
            "InitialScene" => GameState.Menu,
            _ => GameState.Playing
        };
    }
}

public enum GameState {
    Menu,
    Playing,
    Paused,
    GameOver
}
