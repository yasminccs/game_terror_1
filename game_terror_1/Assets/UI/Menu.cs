using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Método para iniciar o jogo
    public void PlayGame()
    {
        // Carregar a próxima cena (assumindo que a cena do jogo é a próxima na Build Settings)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Método para abrir as configurações
    public void OpenSettings()
    {
        // Ativar o painel de configurações (assumindo que você tem um GameObject de configurações)
        // Defina seu painel de configurações aqui e ative-o
        Debug.Log("Abrindo Configurações");
    }

    // Método para sair do jogo
    public void QuitGame()
    {
        // Fechar o jogo
        Debug.Log("Saindo do Jogo");
        Application.Quit();
    }
}
