using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAccept : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _salary = 5;
    [SerializeField] private int _respect = 10;
    [SerializeField] private int _damage = 1;
    [SerializeField] private BoxType _boxType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Box>())
        {
            Box newBox = other.GetComponent<Box>();
            CheckCorrectDistract(newBox.Type);
            newBox.Spawner.Spawn();
            Destroy(other.gameObject);
        }
    }
    private void CheckCorrectDistract(BoxType Type)
    {
        if(Type == _boxType)
        _player.SendAward(_salary, _respect, 0);
        else
        {
            _player.SendAward(_salary*-3, 0, _damage);
        }
    }
    public BoxType CheckType(BoxType Type)
    {
        return _boxType = Type;
    }
    
}
