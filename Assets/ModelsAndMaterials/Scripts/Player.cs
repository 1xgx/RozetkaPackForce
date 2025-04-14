using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header ("Statistic")]
    [SerializeField] private int _money = 15;
    [SerializeField] private int _hearts;
    [SerializeField] private int _rescpect = 15;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _RZTKScoreText;
    public void SendTransform(Transform tmpTransform) 
    {
        if (!tmpTransform) return;
        gameObject.GetComponent<SwipeControl>().FocusedObject = tmpTransform;
    }
    public void SendAward(int Money, int Respect)
    {
        _money += Money;
        _rescpect += Respect;
        Debug.Log($"{_money} : Money" +
            $"{_rescpect} : RZTKRespect");

        _moneyText.text = $"Money: {_money}";
        _RZTKScoreText.text = $"Money: {_rescpect}";
    }
}
