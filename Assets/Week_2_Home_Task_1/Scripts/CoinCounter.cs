using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _winText;

    private int _allCoinsCount;

    private void Start()
    {
        _winText.gameObject.SetActive(false);
    }

    public void AddCoin()
    {
        _allCoinsCount += 1;
    }

    public void RemoveCoin()
    {
        _allCoinsCount -= 1;
        CheckWin();
    }

    private void CheckWin()
    {
        if (_allCoinsCount <= 0) _winText.gameObject.SetActive(true);
    }
}