using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public void GameAgain()
    {
        SceneManager.LoadScene(LevelSelect.LevelIndex);
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene(0);
    }

    public void Next()
    {
        if (LevelSelect.LevelIndex <= 7)
        {
            SceneManager.LoadScene(++LevelSelect.LevelIndex);
        }
    }
}
