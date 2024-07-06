using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomMenu : MonoBehaviour
{
    // Método para iniciar o jogo
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Método para abrir as configurações
    public void OpenSettings()
    {
        // Ativar o painel de configurações (assumindo que você tem um GameObject de configurações)
        Debug.Log("Abrindo Configurações");
    }

    // Método para sair do jogo
    public void QuitGame()
    {
        Debug.Log("Saindo do Jogo");
        Application.Quit();
    }
}
