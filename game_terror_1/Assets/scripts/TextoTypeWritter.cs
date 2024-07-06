using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float typingSpeed = 0.05f;
    private string fullText;

    private bool isTyping = false; // Flag para verificar se já está digitando

    void Start()
    {
        if (textComponent == null)
        {
            Debug.LogWarning("Text component not assigned to TypewriterEffect script.");
            enabled = false; // Desativa o script para evitar erros
            return;
        }

        fullText = textComponent.text;
        textComponent.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        isTyping = true;

        foreach (char letter in fullText.ToCharArray())
        {
            if (textComponent == null)
            {
                break; // Sai do loop se o componente for destruído
            }

            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void Update()
    {
        // Exemplo de pausa no efeito de digitação
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopCoroutine(TypeText());
                textComponent.text = fullText; // Exibe o texto completo imediatamente
                isTyping = false;
            }
        }
    }
}
