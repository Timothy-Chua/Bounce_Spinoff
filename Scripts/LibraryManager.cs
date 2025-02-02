using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LibraryManager : MonoBehaviour
{
    public int loginSceneIndex = 0;
    public int bounceSceneIndex = 2;
    public GameObject panelAllGames;
    public GameObject panelMyGames;

    public void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        _BtnAllGames();
    }

    public void _BtnAllGames()
    {
        panelAllGames.SetActive(true);
        panelMyGames.SetActive(false);
    }

    public void _BtnMyGames()
    {
        panelAllGames.SetActive(false);
        panelMyGames.SetActive(true);
    }

    public void _BtnBounce()
    {
        SceneManager.LoadScene(bounceSceneIndex);
    }

    public void _BtnLogOut()
    {
        SceneManager.LoadScene(loginSceneIndex);
    }
}
