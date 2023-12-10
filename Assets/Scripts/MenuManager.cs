using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string gameName;
    public void startGame() {
        SceneManager.LoadScene(gameName);
    }

    public void exitGame() {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
