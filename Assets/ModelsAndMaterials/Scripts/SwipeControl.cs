using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeControl : MonoBehaviour
{
    [Header ("Input")]
    [SerializeField] private InputAction _swipeControler;
    [Header("How much I have to swipe to swipecontrol is work")]
    [SerializeField] private float swipeThreshold = 50f;
    [SerializeField] private float movementSpeed = 5f;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isSwiping = false;

    public Transform FocusedObject;

    private void OnEnable()
    {
        _swipeControler.Enable();
        _swipeControler.performed += OnSwipePerformed;
        _swipeControler.canceled += OnSwipeCanceled;
    }
    private void OnDisable()
    {
        _swipeControler.Disable();
        _swipeControler.performed += OnSwipePerformed;
        _swipeControler.canceled += OnSwipeCanceled;
    }
    private void OnSwipePerformed(InputAction.CallbackContext context)
    {
        if (!isSwiping)
        {
            startTouchPosition = context.ReadValue<Vector2>();
            isSwiping = true;
        }
    }
    private void OnSwipeCanceled(InputAction.CallbackContext context)
    {
        if (isSwiping)
        {
            endTouchPosition = context.ReadValue<Vector2>();
            isSwiping = false;
            ProcessSwipe();
        }
    }
    private void ProcessSwipe()
    {
        float swipeDistance = endTouchPosition.y - startTouchPosition.y; // Движение по Y

        if (Mathf.Abs(swipeDistance) >= swipeThreshold)
        {
            if (swipeDistance > 0)
            {
                Debug.Log("Свайп вперед (по оси Y+)");
                MoveObject(Vector3.up);
            }
            else
            {
                Debug.Log("Свайп назад (по оси Y-)");
                //MoveObject(Vector3.down);
            }
        }
    }

    private void MoveObject(Vector3 direction)
    {
        //transform.position += direction * movementSpeed * Time.deltaTime;
        if (FocusedObject == null) return;
        FocusedObject.position += direction * movementSpeed * Time.deltaTime;


    }

}
