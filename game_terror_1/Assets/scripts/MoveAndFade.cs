using UnityEngine;
using UnityEngine.UI;

public class MoveAndFade : MonoBehaviour
{
    public float duration = 5f;    // Duração da animação
    private Vector3 startPosition; // Posição inicial
    private Vector3 targetPosition; // Posição final
    private float elapsedTime = 0f; // Tempo decorrido
    private Image image; // Referência à imagem
    private bool challengeCompleted = false; // Desafio concluído
    public AudioSource audioSource; // Referência ao AudioSource

    void Start()
    {
        // Posição inicial fornecida pelo usuário
        startPosition = new Vector3(-10.23f, 2.98f, 0f);
        // Posição final fornecida pelo usuário
        targetPosition = new Vector3(0.997f, 3.05f, 0f);
        // Definir a posição inicial da imagem
        transform.position = startPosition;
        // Obter a referência à imagem
        image = GetComponent<Image>();
    }

    void Update()
    {
        // Executar a animação se o desafio for concluído
        if (challengeCompleted)
        {
            if (elapsedTime < duration)
            {
                // Atualizar o tempo decorrido
                elapsedTime += Time.deltaTime;

                // Interpolação linear da posição
                transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);

                // Interpolação linear da opacidade
                Color color = image.color;
                color.a = Mathf.Lerp(1f, 0f, elapsedTime / duration);
                image.color = color;
            }
        }
    }

    // Método para iniciar a animação
    public void StartAnimation()
    {
        challengeCompleted = true;
        audioSource.Play(); // Reproduzir som quando a animação começar
    }
}