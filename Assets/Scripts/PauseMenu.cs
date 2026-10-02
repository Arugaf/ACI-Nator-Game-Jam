using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour {
    [SerializeField] private GameObject pausePanel;

    [SerializeField] private InputActionReference toggleMenuAction;

    private void OnEnable() {
        toggleMenuAction.action.performed += TogglePause;
        toggleMenuAction.action.Enable();
    }

    private void OnDisable() {
        toggleMenuAction.action.performed -= TogglePause;
        toggleMenuAction.action.Disable();
    }

    private void Start() {
        pausePanel.SetActive(false);
    }

    private void TogglePause(InputAction.CallbackContext context) {
        switch (GameStateManager.Instance.CurrentState) {
            case GameState.Playing:
                Open();
                break;
            case GameState.Paused:
                Close();
                break;
            case GameState.Menu:
            case GameState.GameOver:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Open() {
        pausePanel.SetActive(true);
        GameStateManager.Instance.PauseGame();
    }

    private void Close() {
        pausePanel.SetActive(false);
        GameStateManager.Instance.ResumeGame();
    }

    public void Resume() {
        Close();
    }

    public void MainMenu() {
        pausePanel.SetActive(false);
        GameStateManager.Instance.BackToMenu();
    }

    public void QuitGame() {
        pausePanel.SetActive(false);
        GameStateManager.Instance.QuitGame();
    }
}
