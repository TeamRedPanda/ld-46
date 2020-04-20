using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject GameOverScreen;

    public bool IsGameOver {
        get => m_IsGameOver;
        set {
            m_IsGameOver = value;
            if (m_IsGameOver)
                GameOverScreen.SetActive(true);
        }
    }
    bool m_IsGameOver = false;

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
