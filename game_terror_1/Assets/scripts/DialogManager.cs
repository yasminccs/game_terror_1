using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public Button nextButton;
    public List<string> dialogLines;
    private int currentLineIndex = 0;

    void Start()
    {
        // Inicia a caixa de diálogo desativada
        dialogBox.SetActive(false);
        // Inicia a corrotina para mostrar a caixa de diálogo após 5 segundos
        StartCoroutine(ShowDialogBoxWithDelay(5f));

        // Adiciona o listener ao botão
        nextButton.onClick.AddListener(ShowNextLine);
    }

    IEnumerator ShowDialogBoxWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        dialogBox.SetActive(true);
        ShowNextLine();
    }

    public void ShowNextLine()
{
    if (currentLineIndex < dialogLines.Count)
    {
        dialogText.text = dialogLines[currentLineIndex];
        currentLineIndex++;
    }
    else
    {
        Debug.Log("Não há mais linhas para mostrar.");
        // Se não houver mais linhas, desativa a caixa de diálogo
        dialogBox.SetActive(false);
    }
}
}