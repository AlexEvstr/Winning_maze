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
    [SerializeField] private GameObject _characterObject;
    [SerializeField] private GameObject _effectLevel;
    [SerializeField] private GameObject _effectCompleted;
    [SerializeField] private GameObject _fireWorlEffect;
    [SerializeField] private GameObject[] _charatcerImages;
    [SerializeField] private Sprite[] _characterSprites;
    [SerializeField] private SpriteRenderer _characterSprite;
    private int _characterIndex;
    private GameSounds _gameSounds;

    private int _currentLevel;
    private int _labyrinthIndex;
    private int _isEffects;

    private void OnEnable()
    {
        _characterIndex = PlayerPrefs.GetInt("CurrentCharacter", 0);
        _characterSprite.sprite = _characterSprites[_characterIndex];
        _charatcerImages[_characterIndex].SetActive(true);

        _labyrinthIndex = PlayerPrefs.GetInt("CurrentLabyrinth", 0);
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        _labyrinths[_labyrinthIndex].SetActive(true);
        _levelText.text = _currentLevel.ToString();
        _isEffects = PlayerPrefs.GetInt("Effects", 1);
        _gameSounds = GetComponent<GameSounds>();
    }

    public void IncreaseLevel()
    {
        StartCoroutine(LevelCompleteBehavior());
    }

    private IEnumerator LevelCompleteBehavior()
    {
        LockFinish();

        if (_isEffects == 1)
        {
            StartCoroutine(ShowFireWork());
        }
            
        GameObject[] starsGroup = _starsGroup[_labyrinthIndex].Stars;
        foreach (var item in starsGroup)
        {
            item.SetActive(true);
        }

        _labyrinths[_labyrinthIndex].SetActive(false);
        _characterObject.SetActive(false);
        _charatcerImages[_characterIndex].SetActive(false);
        _currentLevel++;

        _labyrinthIndex++;
        if (_labyrinthIndex == _labyrinths.Length)
        {
            _labyrinthIndex = 0;
        }

        _characterIndex++;
        if (_characterIndex == _characterSprites.Length)
        {
            _characterIndex = 0;
        }

        PlayerPrefs.SetInt("CurrentLabyrinth", _labyrinthIndex);
        PlayerPrefs.SetInt("CurrentCharacter", _characterIndex);
        PlayerPrefs.SetInt("CurrentLevel", _currentLevel);

        if (_isEffects == 1)
        {
            yield return new WaitForSeconds(2.0f);
            ShowEffect();
        }   

        yield return new WaitForSeconds(2.0f);
        _characterObject.SetActive(true);
        _characterSprite.sprite = _characterSprites[_characterIndex];
        _charatcerImages[_characterIndex].SetActive(true);
        _characterObject.transform.position = new Vector2(0, 3.5f);
        _labyrinths[_labyrinthIndex].SetActive(true);
        _levelText.text = _currentLevel.ToString();
    }

    private IEnumerator ShowFireWork()
    {
        _gameSounds.PlayFirework();
        GameObject fireWork1 = Instantiate(_fireWorlEffect);
        fireWork1.transform.position = new Vector2(-1, 0);
        yield return new WaitForSeconds(0.1f);
        _gameSounds.PlayFirework();
        GameObject fireWork2 = Instantiate(_fireWorlEffect);
        fireWork2.transform.position = new Vector2(0, 0);
        yield return new WaitForSeconds(0.1f);
        _gameSounds.PlayFirework();
        GameObject fireWork3 = Instantiate(_fireWorlEffect);
        fireWork3.transform.position = new Vector2(1, 0);
        yield return new WaitForSeconds(0.1f);
        _gameSounds.PlayFirework();
        GameObject fireWork4 = Instantiate(_fireWorlEffect);
        fireWork4.transform.position = new Vector2(-1, -2);
        yield return new WaitForSeconds(0.1f);
        _gameSounds.PlayFirework();
        GameObject fireWork5 = Instantiate(_fireWorlEffect);
        fireWork5.transform.position = new Vector2(0, -2);
        yield return new WaitForSeconds(0.1f);
        _gameSounds.PlayFirework();
        GameObject fireWork6 = Instantiate(_fireWorlEffect);
        fireWork6.transform.position = new Vector2(1, -2);
    }

    private void ShowEffect()
    {
        _gameSounds.PlayWin();
        GameObject level = Instantiate(_effectLevel);
        level.transform.position = new Vector2(0, 1);
        Destroy(level, 2);
        GameObject completed = Instantiate(_effectCompleted);
        completed.transform.position = new Vector2(0, -0.5f);
        Destroy(completed, 2);
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