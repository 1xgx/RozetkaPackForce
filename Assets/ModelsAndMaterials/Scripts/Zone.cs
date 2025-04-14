using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    private readonly string DecoBox = "DecoBox";
    private readonly string EHBox = "EHBox";
    private readonly string FurnitureBox = "Furniture";
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Box>()) 
        {
            Box newBox = other.GetComponent<Box>();
            newBox.CheckPosition(newBox.Speed);
            Debug.Log("" + newBox.Type);
        }
        
    }
}
