using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SecretCode : MonoBehaviour
{
    public GameObject codePanel; // Painel do código
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    public TMP_InputField inputField4;
    public TMP_Text resultText;

    public GameObject dialoguePanel; // Painel de diálogo
    public TMP_Text dialogueText;
    public string dialogueMessage = "Objeto desbloqueado! Indo para a próxima fase...";

    private string correctCode = "3613"; // Código correto

    void Start()
    {
        codePanel.SetActive(false);
        dialoguePanel.SetActive(false);
    }

    public void CheckCode()
    {
        string enteredCode = inputField1.text + inputField2.text + inputField3.text + inputField4.text;
        if (enteredCode == correctCode)
        {
            resultText.text = "Código correto!";
            Unlock();
        }
        else
        {
            resultText.text = "Código incorreto. Tente novamente.";
        }
    }

    public void ClosePanel()
    {
        codePanel.SetActive(false);
    }

    public void OpenPanel()
    {
        codePanel.SetActive(true);
        resultText.text = "";
        // Limpar os campos de entrada
        inputField1.text = "";
        inputField2.text = "";
        inputField3.text = "";
        inputField4.text = "";
    }

    void Unlock()
    {
        // Adicione a lógica para o que acontece quando o código está correto
        Debug.Log("Código correto! Objeto desbloqueado.");
        // Fechar o painel após desbloquear
        codePanel.SetActive(false);

        // Exibir o balão de diálogo
        StartCoroutine(ShowDialogueAndLoadNextScene());
    }

    IEnumerator ShowDialogueAndLoadNextScene()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogueMessage;
        yield return new WaitForSeconds(5f);
        LoadNextScene();
    }

    void LoadNextScene()
    {
        // Substitua "NextSceneName" pelo nome da próxima cena
        SceneManager.LoadScene("telaCozinha");
    }
}
