using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}