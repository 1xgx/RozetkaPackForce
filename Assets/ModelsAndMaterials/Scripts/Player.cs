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
    [SerializeField] private int _rescpectToHearts = 0;
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

        _money += Money;
        _rescpect += Respect;
        _hearts -= Hearts;
        _rescpectToHearts += Respect;
        if (_rescpectToHearts == 30)
        {
            _rescpectToHearts = 0;
            if(_hearts < 3)
            {
                _hearts++;
                _heartsImage[_hearts-1].SetActive(true);
            }
        }
        if (Hearts != 0)
        {
            _heartsImage[_hearts].SetActive(false);
            //_heartsImage.RemoveAt(_hearts);
        }
        if (_money == 0 || _hearts == 0)
        {
            _gameManager.GameOver();
        }
        UpdateText();
    }
    private void UpdateText()
    {
        _moneyText.text = $"{_money}";
        _RZTKScoreText.text = $"{_rescpect}";
    }
}

