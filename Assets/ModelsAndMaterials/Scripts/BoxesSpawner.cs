using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> Boxes;
    [SerializeField] private float _delay = 1.0f;
    [SerializeField] private new Vector3 _offset = new Vector3(3.3f,-1.0f,-1.4f);
    [SerializeField] private float _speed = 5.0f;

    private void Start()
    {
        //StartCoroutine(SpawnOneBox());
        //Spawn();
    }
    public void Spawn()
    {
        GameManager newGameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        int Index = Random.Range(0, Boxes.Count);
        GameObject newObject = Instantiate(Boxes[Index], _offset, Quaternion.identity);
        newObject.GetComponent<Box>().Spawner = this;
        newObject.GetComponent<Box>().GameManager = newGameManager;
        newObject.GetComponent<Box>().Speed = _speed;
    }
    private IEnumerator SpawnOneBox()
    {
        for (int i = 0; i < Boxes.Count; i++) 
        {

            GameObject newObject = Instantiate(Boxes[i], _offset, Quaternion.identity);
            newObject.GetComponent<Box>().Speed = _speed;
            yield return new WaitForSeconds(_delay);
        }
        
    }
}
