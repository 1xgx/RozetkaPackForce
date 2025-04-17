using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private BoxesSpawner _spawner;
    public Player Player;
    [SerializeField] private SwipeControl _swipeControl;
    [SerializeField] private ZoneAccept _zoneAccept;
    [SerializeField] private BoxType _boxType;
    [SerializeField] private TextMeshProUGUI _TextType;
    [SerializeField] private GameObject _HUD;
    [SerializeField] private GameObject _gameOverHUD;
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
    public void GameOver()
    {
        _gameOverHUD.SetActive(true);
        _spawner.StopAllCoroutines();
        _spawner.enabled = false;
        _swipeControl.enabled = false;
        _HUD.SetActive(false);
    }
    public void SwipeScene(int index)
    {
        SceneManager.LoadScene(index);
        
    }
}
