using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public string GameAI;
    public string Game;
    public string MainScreen;
    public void VsBot()
    {
        SceneManager.LoadSceneAsync(GameAI);
    }
    public void VsPlayer()
    {
        SceneManager.LoadSceneAsync(Game);
    }
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(MainScreen);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
