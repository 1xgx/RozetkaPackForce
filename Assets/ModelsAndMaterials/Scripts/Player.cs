using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Statistic")]
    [SerializeField] private int _money = 15;
    [SerializeField] private int _hearts = 3;
    [SerializeField] private int _rescpect = 15;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _RZTKScoreText;
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private List<GameObject> _heartsImage;
    private void Start()
    {
        UpdateText();
    }
    public void SendTransform(Transform tmpTransform)
    {
        if (!tmpTransform) return;
        gameObject.GetComponent<SwipeControl>().FocusedObject = tmpTransform;
    }
    public void SendAward(int Money, int Respect, int Hearts)
    {
        if (Hearts != 0)
        {
            _heartsImage[_hearts - 1].SetActive(false);
        }
        _money += Money;
        _rescpect += Respect;
        _hearts -= Hearts;
        
        if (_money == 0 || _hearts == 0)
        {
            _gameManager.GameOver();
        }
        UpdateText();
    }
    private void UpdateText()
    {
        _moneyText.text = $"Money: {_money}";
        _RZTKScoreText.text = $"RZTKScore: {_rescpect}";
    }
}

