using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade de movimento do personagem
    private Vector3 targetPosition;  // Posi��o alvo para onde o personagem se mover�
    private bool isMoving = false;  // Indicador se o personagem est� se movendo
    private Animator animator;  // Refer�ncia ao componente Animator
    private SpriteRenderer spriteRenderer;  // Refer�ncia ao componente SpriteRenderer

    void Start()
    {
        // Inicialmente, a posi��o alvo � a posi��o inicial do personagem
        targetPosition = transform.position;
        // Obt�m a refer�ncia ao componente Animator
        animator = GetComponent<Animator>();
        // Obt�m a refer�ncia ao componente SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Verifica se o bot�o esquerdo do mouse foi clicado
        if (Input.GetMouseButtonDown(0))
        {
            // Converte a posi��o do clique do mouse para a posi��o no mundo
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z;  // Mant�m a posi��o z do personagem
            isMoving = true;  // Define o personagem como em movimento

            // Verifica a dire��o do movimento para virar o personagem
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

        // Se o personagem estiver se movendo, move-o em dire��o � posi��o alvo
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Verifica se o personagem chegou � posi��o alvo
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;  // Define o personagem como parado
            }
        }

        // Define o par�metro isWalking no Animator
        animator.SetBool("isWalking", isMoving);
    }
}
