using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Para usar a UI
using UnityEngine.SceneManagement;  // Para carregar a próxima fase
using System.Collections;

public class ClickHandler2D : MonoBehaviour
{
    public GameObject panel;  // Referência ao painel
    public Text messageText;  // Referência ao componente de texto

    private bool isLamparinaOff = false;

    void Start()
    {
        // Certifique-se de que o painel está desativado no início
        panel.SetActive(false);
    }

    void OnMouseDown()
    {
        if (!isLamparinaOff)
        {
            // Primeira mensagem
            messageText.text = "A lamparina foi desligada!";
            panel.SetActive(true);
            isLamparinaOff = true;

            // Mude a mensagem após 2 segundos
            StartCoroutine(ChangeMessageAfterDelay(2.0f, "Com as luzes apagadas posso ver um papel brilhando."));
        }
        else
        {
            // Caso a lamparina já esteja desligada
            messageText.text = "Com as luzes apagadas posso ver um papel brilhando.";
            panel.SetActive(true);

            // Avançar para a próxima fase após 2 segundos
            StartCoroutine(LoadNextSceneAfterDelay(2.0f));
        }
    }

    IEnumerator ChangeMessageAfterDelay(float delay, string newMessage)
    {
        yield return new WaitForSeconds(delay);
        messageText.text = newMessage;

        // Avançar para a próxima fase após exibir a nova mensagem
        StartCoroutine(LoadNextSceneAfterDelay(2.0f));
    }

    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // Carregar a próxima cena na ordem do build
    }
}
