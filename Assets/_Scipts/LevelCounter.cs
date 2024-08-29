using System.Collections;
using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] private GameObject[] _labyrinths;
    [SerializeField] private GameObject[] _locks;
    [SerializeField] private GameObject[] _finishes;
    [SerializeField] private StarsGroup[] _starsGroup;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private GameObject _plane;
    private int _currentLevel;
    private int _labyrinthIndex;

    private void OnEnable()
    {
        _labyrinthIndex = PlayerPrefs.GetInt("CurrentLabyrinth", 0);
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        _labyrinths[_labyrinthIndex].SetActive(true);
        _levelText.text = _currentLevel.ToString();
    }

    public void IncreaseLevel()
    {
        StartCoroutine(LevelCompleteBehavior());
    }

    private IEnumerator LevelCompleteBehavior()
    {
        LockFinish();

        GameObject[] starsGroup = _starsGroup[_labyrinthIndex].Stars;
        foreach (var item in starsGroup)
        {
            item.SetActive(true);
        }

        _labyrinths[_labyrinthIndex].SetActive(false);
        _currentLevel++;
        _labyrinthIndex++;
        if (_labyrinthIndex == _labyrinths.Length)
        {
            _labyrinthIndex = 0;
        }
        PlayerPrefs.SetInt("CurrentLevel", _currentLevel);
        PlayerPrefs.SetInt("CurrentLabyrinth", _labyrinthIndex);
        yield return new WaitForSeconds(2.0f);
        _plane.transform.position = new Vector2(0, 3.5f);
        _labyrinths[_labyrinthIndex].SetActive(true);
        _levelText.text = _currentLevel.ToString();
    }

    public void UnlockFinish()
    {
        _locks[_labyrinthIndex].SetActive(false);
        _finishes[_labyrinthIndex].SetActive(true);
    }

    private void LockFinish()
    {
        _finishes[_labyrinthIndex].SetActive(false);
        _locks[_labyrinthIndex].SetActive(true);
    }
}

[System.Serializable]
public class StarsGroup
{
    public GameObject[] Stars;
}