using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _rules;
    [SerializeField] private Button _rulesBtn;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void MenuButton()
    {
        StartCoroutine(WaitForSound());
    }

    private IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Menu");
    }

    public void RulesButton()
    {
        StartCoroutine(ShowRules());
    }

    private IEnumerator ShowRules()
    {
        _rules.SetActive(true);
        _rulesBtn.enabled = false;
        yield return new WaitForSeconds(3.0f);
        _rules.SetActive(false);
        _rulesBtn.enabled = true;
    }
}