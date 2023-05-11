using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [SerializeField] private string levelJogo;

    public void Jogar()
    {
        SceneManager.LoadScene(levelJogo);
    }

    public void SairJogo()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }

    public void Menu()
    {
        SceneManager.LoadScene(levelJogo);
    }
}
