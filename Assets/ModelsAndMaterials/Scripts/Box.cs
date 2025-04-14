using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float Speed;
    private float _offsetX = 0.0f;
    private float _delay = 5.0f;
    [SerializeField] private BoxType _type;

    public BoxType Type => _type;
    private void Update()
    {
        moveObject();
        if (transform.position.x <= -5.0f)
        {
            Destroy(gameObject);
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
        yield return new WaitForSeconds(_delay);
        Speed = speed;
    }
}
