using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> Boxes;
    [SerializeField] private float _delay = 1.0f;
    [SerializeField] private float _waitTime = 5.0f; 
    [SerializeField] private new Vector3 _offset = new Vector3(3.3f,-1.0f,-1.4f);
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private int _boxSpawned = 0;
    public void Spawn()
    {
        _boxSpawned++;
        _waitTime = GetWaitTime(_boxSpawned);
        GameManager newGameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        int Index = Random.Range(0, Boxes.Count);
        GameObject newObject = Instantiate(Boxes[Index], _offset, Quaternion.identity);
        Box newBox = newObject.GetComponent<Box>();
        newBox.Spawner = this;
        newBox.GameManager = newGameManager;
        newBox.Speed = _speed;
        newBox._delay = _waitTime;
    }
    private float GetWaitTime(int Index)
    {
        
        float baseTime = 5.0f;
        float minTime = 1.0f;
        float rate = 0.9f;
        return Mathf.Max(baseTime * Mathf.Pow(rate, Index), minTime);

    }
}
