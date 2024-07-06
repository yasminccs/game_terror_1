using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArmarioInteracao : MonoBehaviour
{
    public GameObject dialogPanel; // O painel do diálogo
    public Text dialogText; // O texto do diálogo
    public GameObject imageDisplay; // O objeto de exibição da imagem
    public Button nextPhaseButton; // O botão para avançar para a próxima fase

    private int currentDialogIndex = 0; // Índice atual do diálogo
    private string[] dialogMessages = {
        "Você abriu o armário.",
        "Dentro do armário existe uma caixa.",
        "Dentro desta caixa está o último papel."
    };

    void Start()
    {
        dialogPanel.SetActive(false); // Esconde o painel do diálogo no início
        imageDisplay.SetActive(false); // Esconde a imagem no início
        nextPhaseButton.gameObject.SetActive(false); // Esconde o botão no início

        nextPhaseButton.onClick.AddListener(CarregarProximaFase);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                MostrarProximoDialogo();
            }
        }
    }

    void MostrarProximoDialogo()
    {
        if (currentDialogIndex < dialogMessages.Length)
        {
            dialogPanel.SetActive(true);
            dialogText.text = dialogMessages[currentDialogIndex];
            currentDialogIndex++;

            if (currentDialogIndex == dialogMessages.Length)
            {
                // Mostra a imagem após o último diálogo
                StartCoroutine(ShowImageAndButton());
            }
        }
    }

    IEnumerator ShowImageAndButton()
    {
        yield return new WaitForSeconds(2.0f); // Espera 2 segundos após o último diálogo
        imageDisplay.SetActive(true); // Exibe a imagem
        dialogPanel.SetActive(false); // Esconde o painel de diálogo
        nextPhaseButton.gameObject.SetActive(true); // Exibe o botão para a próxima fase
    }

    void CarregarProximaFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Carrega a próxima cena na ordem do build
    }
}
