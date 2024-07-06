using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Para carregar a próxima fase

public class DrawerOpener : MonoBehaviour
{
    public KeyCollector keyCollector; // Referência ao script KeyCollector
    public GameObject drawer; // Gaveta que será aberta
    public GameObject imagePanel; // Painel da imagem que será exibida
    public GameObject dialoguePanel; // Painel do diálogo com balão de fala
    public TMP_Text dialogueText; // Texto do diálogo (TextMeshPro)
    public string nextSceneName; // Nome da próxima cena

    private bool isDrawerOpen = false; // Verifica se a gaveta está aberta

    void Start()
    {
        // Desativa o painel de imagem e o painel de diálogo no início
        imagePanel.SetActive(false);
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Converte a posição do mouse para um ponto do mundo
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                TryOpenDrawer();
            }
        }
    }

    void TryOpenDrawer()
    {
        if (keyCollector.HasKey() && !isDrawerOpen)
        {
            isDrawerOpen = true;
            OpenDrawer();
            ShowDialogue("Gaveta aberta! Você encontrou um item.", LoadNextScene);
        }
        else if (!keyCollector.HasKey())
        {
            ShowDialogue("Você precisa de uma chave para abrir esta gaveta.", null);
        }
    }

    void OpenDrawer()
    {
        // Aqui você pode adicionar animação ou lógica para abrir a gaveta
        drawer.SetActive(false); // Exemplo de desativar a gaveta
        imagePanel.SetActive(true); // Exibir a imagem
    }

    void ShowDialogue(string message, System.Action callback)
    {
        dialogueText.text = message;
        dialoguePanel.SetActive(true);
        // Desativa o painel após 2 segundos e chama o callback
        Invoke("HideDialogue", 2f);
        if (callback != null)
        {
            Invoke("InvokeCallback", 2.1f); // Chama o callback após o diálogo
        }
    }

    void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }

    void InvokeCallback()
    {
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
