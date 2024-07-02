using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Fun��o para iniciar o jogo
    public void StartGame()
    {
        // Carrega a cena do jogo (substitua "GameScene" pelo nome da sua cena de jogo)
        SceneManager.LoadScene("GameScene");
    }

    // Fun��o para abrir as configura��es
    public void OpenSettings()
    {
        // Carrega a cena de configura��es (substitua "SettingsScene" pelo nome da sua cena de configura��es)
        SceneManager.LoadScene("SettingsScene");
    }

    // Fun��o para sair do jogo
    public void ExitGame()
    {
        // Sai do jogo
        Application.Quit();
        // Se estiver no editor, parar a reprodu��o
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
