using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade de movimento do personagem
    private Vector3 targetPosition;  // Posição alvo para onde o personagem se moverá
    private bool isMoving = false;  // Indicador se o personagem está se movendo
    private Animator animator;  // Referência ao componente Animator
    private SpriteRenderer spriteRenderer;  // Referência ao componente SpriteRenderer
    private Rigidbody2D rb;  // Referência ao componente Rigidbody2D

    void Start()
    {
        // Inicialmente, a posição alvo é a posição inicial do personagem
        targetPosition = transform.position;
        // Obtém a referência ao componente Animator
        animator = GetComponent<Animator>();
        // Obtém a referência ao componente SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Obtém a referência ao componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Certifique-se de que o Rigidbody2D está configurado como Kinematic
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        // Verifica se o botão esquerdo do mouse foi clicado
        if (Input.GetMouseButtonDown(0))
        {
            // Converte a posição do clique do mouse para a posição no mundo
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = transform.position.z;  // Mantém a posição z do personagem

            // Verifica se há colisão no caminho para a posição clicada
            RaycastHit2D hit = Physics2D.Raycast(transform.position, clickPosition - transform.position, Vector2.Distance(transform.position, clickPosition));
            if (hit.collider == null)
            {
                targetPosition = clickPosition;
                isMoving = true;  // Define o personagem como em movimento

                // Verifica a direção do movimento para virar o personagem
                if (targetPosition.x > transform.position.x)
                {
                    // Vira o personagem para a direita
                    spriteRenderer.flipX = false;
                }
                else if (targetPosition.x < transform.position.x)
                {
                    // Vira o personagem para a esquerda
                    spriteRenderer.flipX = true;
                }
            }
        }

        // Se o personagem estiver se movendo, move-o em direção à posição alvo
        if (isMoving)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            Vector2 move = direction * moveSpeed * Time.deltaTime;

            // Movimenta o personagem usando MovePosition
            rb.MovePosition(rb.position + move);

            // Verifica se o personagem chegou à posição alvo
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;  // Define o personagem como parado
            }
        }

        // Define o parâmetro isWalking no Animator
        animator.SetBool("isWalking", isMoving);
    }
}