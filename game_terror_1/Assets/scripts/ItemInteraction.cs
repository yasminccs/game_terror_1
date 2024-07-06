using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public InteractionController interactionController;
    public GameObject forno;
    public GameObject balcao;
    public GameObject torneira;

    void OnMouseDown()
    {
        if (gameObject == forno || gameObject == balcao)
        {
            interactionController.MostrarEscolhaItem(gameObject);
        }
        else if (gameObject == torneira)
        {
            string mensagem = interactionController.IsTorneiraDesligada() ? "Deseja ligar a torneira?" : "Deseja desligar a torneira?";
            interactionController.MostrarMensagem(gameObject, mensagem);
        }
    }
}
