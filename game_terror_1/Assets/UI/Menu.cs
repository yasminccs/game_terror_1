using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Função para iniciar o jogo
    public void StartGame()
    {
        // Carrega a cena do jogo (substitua "GameScene" pelo nome da sua cena de jogo)
        SceneManager.LoadScene("GameScene");
    }

    // Função para abrir as configurações
    public void OpenSettings()
    {
        // Carrega a cena de configurações (substitua "SettingsScene" pelo nome da sua cena de configurações)
        SceneManager.LoadScene("SettingsScene");
    }

    // Função para sair do jogo
    public void ExitGame()
    {
        // Sai do jogo
        Application.Quit();
        // Se estiver no editor, parar a reprodução
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
