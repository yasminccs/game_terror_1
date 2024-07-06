using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    public GameObject pao;
    public GameObject panela;

    public GameObject forno;
    public GameObject balcao;
    public GameObject torneira;

    public GameObject confirmationPanel;
    public Text confirmationText;
    public Button paoButton; // Botão para escolher pão
    public Button panelaButton; // Botão para escolher panela
    public Button yesButton; // Botão "Sim" para torneira
    public Button noButton; // Botão "Não" para torneira

    private GameObject currentLocal;

    private bool paoNoForno = false;
    private bool panelaNoBalcao = false;
    private bool torneiraDesligada = false;

    void Start()
    {
        // Inicializar os itens e painel de confirmação
        pao.SetActive(true);
        panela.SetActive(true);
        SetConfirmationPanelActive(false);

        // Configurar listeners para os botões
        paoButton.onClick.AddListener(OnPaoButtonClicked);
        panelaButton.onClick.AddListener(OnPanelaButtonClicked);
        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
    }

    public bool IsTorneiraDesligada()
    {
        return torneiraDesligada;
    }

    public void MostrarEscolhaItem(GameObject local)
    {
        currentLocal = local;
        confirmationText.text = "O que deseja colocar aqui?";
        paoButton.gameObject.SetActive(true);
        panelaButton.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(false); // Esconder botão "Sim"
        noButton.gameObject.SetActive(false); // Esconder botão "Não"
        SetConfirmationPanelActive(true);
    }

    public void MostrarMensagem(GameObject local, string mensagem)
    {
        currentLocal = local;
        confirmationText.text = mensagem;
        paoButton.gameObject.SetActive(false); // Esconder botão "Pão"
        panelaButton.gameObject.SetActive(false); // Esconder botão "Panela"
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
        SetConfirmationPanelActive(true);
    }

    private void OnPaoButtonClicked()
    {
        if (currentLocal.CompareTag("Forno"))
        {
            ColocarNoForno(pao);
        }
        else if (currentLocal.CompareTag("Balcao"))
        {
            ColocarNoBalcao(pao);
        }
    }

    private void OnPanelaButtonClicked()
    {
        if (currentLocal.CompareTag("Forno"))
        {
            ColocarNoForno(panela);
        }
        else if (currentLocal.CompareTag("Balcao"))
        {
            ColocarNoBalcao(panela);
        }
    }

    private void OnYesButtonClicked()
    {
        if (currentLocal.CompareTag("Torneira"))
        {
            torneiraDesligada = true;
            Debug.Log("Torneira desligada.");
        }

        SetConfirmationPanelActive(false);
        VerificarCondicoes();
    }

    private void OnNoButtonClicked()
    {
        if (currentLocal.CompareTag("Torneira"))
        {
            torneiraDesligada = false;
            Debug.Log("Torneira ligada.");
        }

        SetConfirmationPanelActive(false);
    }

    private void ColocarNoForno(GameObject item)
    {
        if (item == pao)
        {
            paoNoForno = true;
            Debug.Log("Pão colocado no forno.");
        }
        else if (item == panela)
        {
            Debug.Log("Não pode colocar panela no forno.");
        }
    }

    private void ColocarNoBalcao(GameObject item)
    {
        if (item == panela)
        {
            panelaNoBalcao = true;
            Debug.Log("Panela colocada no balcão.");
        }
        else if (item == pao)
        {
            Debug.Log("Não pode colocar pão no balcão.");
        }
    }

    private void VerificarCondicoes()
    {
        if (paoNoForno && panelaNoBalcao && torneiraDesligada)
        {
            Debug.Log("Condições satisfeitas. Passando de fase...");
            ProximaFase();
        }
    }

    private void ProximaFase()
    {
        confirmationText.text = "Parabéns! Você passou de fase.";
        SetConfirmationPanelActive(true);
        // Aqui você pode adicionar a lógica para mudar de cena ou iniciar uma nova fase
    }

    private void SetConfirmationPanelActive(bool isActive)
    {
        confirmationPanel.SetActive(isActive);
        paoButton.gameObject.SetActive(isActive);
        panelaButton.gameObject.SetActive(isActive);
        yesButton.gameObject.SetActive(isActive);
        noButton.gameObject.SetActive(isActive);
    }
}
