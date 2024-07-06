using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyCollector : MonoBehaviour
{
    public GameObject dialoguePanel; // Painel do diálogo
    public TMP_Text dialogueText; // Texto do diálogo (TextMeshPro)

    private bool hasKey = false; // Verifica se a chave foi coletada

    void Start()
    {
        // Desativa o painel de diálogo no início
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
                CollectKey();
            }
        }
    }

    void CollectKey()
    {
        if (!hasKey)
        {
            hasKey = true;
            ShowDialogue("Chave coletada!");
            // Destrua ou desative o objeto chave após a coleta
            gameObject.SetActive(false);
        }
    }

    void ShowDialogue(string message)
    {
        dialogueText.text = message;
        dialoguePanel.SetActive(true);
        // Desativa o painel após 2 segundos
        Invoke("HideDialogue", 2f);
    }

    void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }

    public bool HasKey()
    {
        return hasKey;
    }
}
