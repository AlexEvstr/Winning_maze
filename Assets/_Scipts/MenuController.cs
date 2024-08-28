using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenPrivacyPolicy()
    {
        Application.OpenURL("https://www.google.com/?client=safari");
    }
}
