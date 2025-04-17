using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public float Speed;
    private float _offsetX = 0.0f;
    public float _delay = 0f;
    [SerializeField] private BoxType _type;
    public GameManager GameManager;
    [SerializeField] private int _money = -10;
    public BoxesSpawner Spawner;
    [SerializeField] private Slider _slider;

    public BoxType Type => _type;

    private void Start()
    {
        _slider.maxValue = _delay;
        _slider.value = _delay;
    }

    private void Update()
    {
        moveObject();
        if (Spawner && GameManager)
        {
        if (transform.position.x <= -5.0f)
        {
            Spawner.Spawn();
            GameManager.Player.SendAward(_money,0,1);
            Destroy(gameObject);
        }

        }
    }
    private void moveObject()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }
    public void CheckPosition(float speed)
    {
            Speed = 0;
            transform.position = new Vector3(_offsetX, transform.position.y,transform.position.z);
            StartCoroutine(StopMove(speed));
    }
    private IEnumerator StopMove(float speed)
    {
        while (true) 
        {
            _delay-= Time.deltaTime;
            _slider.value = _delay;
            yield return new WaitForSeconds(0.001f);
            if(_delay <= 0)
            {
                Speed = speed;
                StopCoroutine(StopMove(Speed));
            }
        }
    }
    

}
