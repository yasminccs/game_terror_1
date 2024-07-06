using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TorneiraInteracao : MonoBehaviour
{
    public GameObject dialogPanel; // O painel do diálogo
    public Text dialogText; // O texto do diálogo
    public GameObject speechBubble; // Balão de fala para mostrar mensagem adicional

    public Button simButton; // O botão "Sim"
    public Button naoButton; // O botão "Não"

    private bool torneiraDesligada = false;

    void Start()
    {
        dialogPanel.SetActive(false); // Esconde o painel do diálogo no início
        speechBubble.SetActive(false); // Esconde o balão de fala no início

        simButton.onClick.AddListener(DesligarTorneira);
        naoButton.onClick.AddListener(ContinuarFase);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                MostrarDialogo();
            }
        }
    }

    void MostrarDialogo()
    {
        dialogPanel.SetActive(true);
        dialogText.text = "Deseja desligar a torneira?";
    }

    void DesligarTorneira()
    {
        dialogPanel.SetActive(false);
        torneiraDesligada = true;
        dialogText.text = "Você desligou a torneira.";

        // Exibir o balão de fala com a mensagem adicional
        speechBubble.SetActive(true);
        StartCoroutine(HideSpeechBubbleAfterDelay(4.0f)); // Esconde o balão após 4 segundos

        // Mude a mensagem após 2 segundos
        StartCoroutine(ChangeMessageAfterDelay(2.0f, "Desligada a torneira, vejo um pedaço de papel em cima do balcão"));
    }

    IEnumerator ChangeMessageAfterDelay(float delay, string newMessage)
    {
        yield return new WaitForSeconds(delay);
        dialogText.text = newMessage;

        // Desativar os botões após exibir a nova mensagem
        simButton.gameObject.SetActive(false);
        naoButton.gameObject.SetActive(false);
    }

    IEnumerator HideSpeechBubbleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        speechBubble.SetActive(false);
        
        // Avançar para a próxima fase após esconder o balão de fala
        StartCoroutine(LoadNextSceneAfterDelay(2.0f));
    }

    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // Carregar a próxima cena na ordem do build
    }

    void ContinuarFase()
    {
        dialogPanel.SetActive(false);
    }
}
