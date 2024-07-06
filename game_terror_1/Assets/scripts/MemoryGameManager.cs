using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MemoryGameManager : MonoBehaviour
{
    public Text resultText;
    public GameObject cardsPanel;
    public List<Button> buttons; // Lista de botões do jogo

    private List<int> cardValues; // Valores das cartas
    private bool firstGuess, secondGuess; // Controle de adivinhações
    private int countCorrectGuesses; // Contador de acertos
    private int firstGuessIndex, secondGuessIndex; // Índices das cartas adivinhadas

    void Start()
    {
        cardValues = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 }; // Pares de cartas
        Shuffle(cardValues); // Embaralha as cartas

        VerifyButtons(); // Verifica se os botões estão corretamente configurados
        AssignButtons(); // Atribui o texto vazio inicialmente
        AddListeners(); // Adiciona listeners aos botões
    }

    void VerifyButtons()
    {
        // Verifica se algum botão na lista está nulo
        foreach (var button in buttons)
        {
            if (button == null)
            {
                Debug.LogError("Um dos botões na lista 'buttons' é nulo!");
            }
        }
    }

    void AssignButtons()
    {
        // Atribui o texto vazio inicialmente a cada botão
        foreach (var button in buttons)
        {
            if (button != null)
            {
                button.GetComponentInChildren<Text>().text = "";
            }
        }
    }

    void AddListeners()
    {
        // Adiciona um listener de clique para cada botão
        foreach (var button in buttons)
        {
            if (button != null)
            {
                button.onClick.AddListener(() => PickACard(button));
            }
        }
    }

    public void PickACard(Button clickedButton)
    {
        int selectedButtonIndex = buttons.IndexOf(clickedButton); // Obtém o índice do botão clicado

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = selectedButtonIndex;
            buttons[firstGuessIndex].GetComponentInChildren<Text>().text = cardValues[firstGuessIndex].ToString();
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = selectedButtonIndex;
            buttons[secondGuessIndex].GetComponentInChildren<Text>().text = cardValues[secondGuessIndex].ToString();

            StartCoroutine(CheckIfTheCardsMatch());
        }
    }

    IEnumerator CheckIfTheCardsMatch()
    {
        yield return new WaitForSeconds(1f);

        if (cardValues[firstGuessIndex] == cardValues[secondGuessIndex])
        {
            buttons[firstGuessIndex].interactable = false;
            buttons[secondGuessIndex].interactable = false;
            buttons[firstGuessIndex].GetComponentInChildren<Text>().color = Color.clear;
            buttons[secondGuessIndex].GetComponentInChildren<Text>().color = Color.clear;
            CheckIfTheGameIsFinished();
        }
        else
        {
            buttons[firstGuessIndex].GetComponentInChildren<Text>().text = "";
            buttons[secondGuessIndex].GetComponentInChildren<Text>().text = "";
        }

        firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;
        if (countCorrectGuesses == cardValues.Count / 2)
        {
            resultText.text = "Você Venceu!";
            StartCoroutine(ReturnToMainScene());
        }
    }

    IEnumerator ReturnToMainScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainScene");
    }

    void Shuffle(List<int> list)
    {
        // Embaralha a lista de valores das cartas
        for (int i = 0; i < list.Count; i++)
        {
            int temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}