using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnBoardLoad : MonoBehaviour
{
    [SerializeField] private GameObject[] _items;
    private int _itemIndex;

    private void Start()
    {
        _itemIndex = PlayerPrefs.GetInt("ItemIndex", 0);
        _items[_itemIndex].SetActive(true);
        _itemIndex++;
        if (_itemIndex == _items.Length)
        {
            _itemIndex = 0;
        }
        PlayerPrefs.SetInt("ItemIndex", _itemIndex);

        StartCoroutine(LoadMenuScene());
    }

    private IEnumerator LoadMenuScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Menu");
    }
}