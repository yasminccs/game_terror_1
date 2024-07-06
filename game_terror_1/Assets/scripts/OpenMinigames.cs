using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMinigame : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("MemoryGame");
    }
}