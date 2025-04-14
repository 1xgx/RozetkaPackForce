using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private BoxesSpawner _spawner;
    public Player Player;
    [SerializeField] private ZoneAccept _zoneAccept;
    [SerializeField] private BoxType _boxType;
    [SerializeField] private TextMeshProUGUI _TextType;
    private void Awake()
    {
        _zoneAccept.CheckType(_boxType);
        _TextType.text = _boxType.ToString();
    }
    private void Update()
    {
    }
    public void SpawnClick(GameObject btn)
    {
        btn.SetActive(false);
        _spawner.Spawn();
    }
    public void ChangeType(bool plusOrMinus)
    {
        if (plusOrMinus)
        {
            int next = ((int)_boxType + 1) % System.Enum.GetNames(typeof(BoxType)).Length;
            _boxType = (BoxType)next;
        }
        else 
        {
            int total = System.Enum.GetNames(typeof(BoxType)).Length;
            int next = ((int)_boxType - 1 + total) % total;
            _boxType = (BoxType)next;
        }
        _TextType.text = _boxType.ToString();
        _zoneAccept.CheckType(_boxType);
    }
}
