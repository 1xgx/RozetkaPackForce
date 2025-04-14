using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAccept : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _salary = 5;
    [SerializeField] private int _respect = 5;

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
        _player.SendAward(_salary, _respect);
    }
    
}
