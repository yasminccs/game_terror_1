using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCodePanel : MonoBehaviour
{
    public SecretCode secretCode; // Referência ao script SecretCode

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
                secretCode.OpenPanel();
            }
        }
    }
}
