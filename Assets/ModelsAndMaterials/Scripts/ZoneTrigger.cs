using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    [SerializeField] private Player _player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Box>()) 
        {
            Box newBox = other.GetComponent<Box>();
            newBox.CheckPosition(newBox.Speed);
            _player.SendTransform(newBox.transform);
        }
        
    }
}
