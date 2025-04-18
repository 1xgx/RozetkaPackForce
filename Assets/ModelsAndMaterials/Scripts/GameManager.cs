using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    [SerializeField] private List<GameObject> _boxImage;
    [SerializeField] private List<AudioClip> _clipsOnSwipeTypeOfBoxes;
    [SerializeField] private AudioClip _StartAudio;
    [SerializeField] private AudioSource _audioSource;
    private void Awake()
    {
        _zoneAccept.CheckType(_boxType);
        //_TextType.text = _boxType.ToString();
        showBoxImage();
    }
    private void Update()
    {
    }
    public void SpawnClick(GameObject btn)
    {
        _audioSource.PlayOneShot(_StartAudio);
        btn.SetActive(false);
        _spawner.Spawn();
    }
    public void ChangeType(bool plusOrMinus)
    {
        switch (plusOrMinus)
        {
            case false:
                _audioSource.PlayOneShot(_clipsOnSwipeTypeOfBoxes[0]);
                
                break;
            case true:
                _audioSource.PlayOneShot(_clipsOnSwipeTypeOfBoxes[1]);
                break;
        }
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
        //_TextType.text = _boxType.ToString();
        showBoxImage();
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
        _audioSource.PlayOneShot(_StartAudio);
        SceneManager.LoadScene(index);
        
    }
    private void showBoxImage() 
    {
        switch (_boxType)
        {
            case BoxType.EHBox:
                _boxImage[0].SetActive(true);
                _boxImage[1].SetActive(false);
                _boxImage[2].SetActive(false);
                break;
            case BoxType.DecoBox:
                _boxImage[0].SetActive(false);
                _boxImage[1].SetActive(true);
                _boxImage[2].SetActive(false);
                break;

            case BoxType.FurnitureBox:
                _boxImage[0].SetActive(false);
                _boxImage[1].SetActive(false);
                _boxImage[2].SetActive(true);
                break;
        }
    }
}
