using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _delay;
    public void SwipeScene()
    {
        StartCoroutine(SmoothSwipeScene());
    }
    private IEnumerator SmoothSwipeScene()
    {
        _audioSource.PlayOneShot(_clip);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(1);
    }
}
