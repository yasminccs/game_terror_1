using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementAndFade : MonoBehaviour
{
    public float fadeInDuration = 2.0f;  // Duração do efeito de aparecimento gradual
    public float moveDuration = 3.0f;    // Duração do movimento em segundos
    public float fadeOutDuration = 2.0f; // Duração do efeito de desaparecimento gradual
    public float moveSpeed = 1.0f;       // Velocidade do movimento para a direita

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the character.");
            return;
        }

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the character.");
            return;
        }

        // Inicialmente invisível
        Color initialColor = spriteRenderer.color;
        spriteRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);

        StartCoroutine(AppearMoveAndDisappear());
    }

    IEnumerator AppearMoveAndDisappear()
    {
        // Gradualmente aparecendo
        float elapsedTime = 0f;
        Color originalColor = spriteRenderer.color;
        while (elapsedTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);

        // Toca o som após o fade-in
        audioSource.Play();

        // Move o personagem para a direita por moveDuration segundos
        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Gradualmente desaparecendo
        elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutDuration);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Certifique-se de que o alpha é 0 no final do fade
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}
