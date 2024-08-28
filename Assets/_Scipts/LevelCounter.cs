using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] private GameObject[] _labyrinths;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private GameObject _plane;
    private int _currentLevel;
    private int labyrinthIndex;

    private void OnEnable()
    {
        labyrinthIndex = PlayerPrefs.GetInt("CurrentLabyrinth", 0);
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        _labyrinths[labyrinthIndex].SetActive(true);
        _levelText.text = _currentLevel.ToString();
    }

    public void IncreaseLevel()
    {
        StartCoroutine(LevelCompleteBehavior());
    }

    private IEnumerator LevelCompleteBehavior()
    {
        _labyrinths[labyrinthIndex].SetActive(false);
        _currentLevel++;
        labyrinthIndex++;
        if (labyrinthIndex == _labyrinths.Length)
        {
            labyrinthIndex = 0;
        }
        PlayerPrefs.SetInt("CurrentLevel", _currentLevel);
        PlayerPrefs.SetInt("CurrentLabyrinth", labyrinthIndex);
        yield return new WaitForSeconds(2.0f);
        _plane.transform.position = new Vector2(0, 3.5f);
        _labyrinths[labyrinthIndex].SetActive(true);
        _levelText.text = _currentLevel.ToString();
    }
}
