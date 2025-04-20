using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    [SerializeField]private bool isSwiping = false;

    public Transform FocusedObject;

    private void Update()
    {
        
    }
    private void OnEnable()
    {
        Debug.Log("Свайп активирован");
        _swipeControler.Enable();
        _swipeControler.performed += OnSwipePerformed;
        _swipeControler.canceled += OnSwipeCanceled;
    }
    private void OnDisable()
    {
        Debug.Log("Свайп неактивирован");
        _swipeControler.Disable();
        _swipeControler.performed -= OnSwipePerformed;
        _swipeControler.canceled -= OnSwipeCanceled;
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
        if (IsPointerOverUI()) return;
        float swipeDistance = endTouchPosition.y - startTouchPosition.y; // Движение по Y

        if (Mathf.Abs(swipeDistance) >= swipeThreshold)
        {
            if (swipeDistance < 0)
            {
                MoveObject(Vector3.up);
            }
        }
    }

    private void MoveObject(Vector3 direction)
    {
        if (FocusedObject == null) return;
        FocusedObject.position += direction * movementSpeed * Time.deltaTime;
        FocusedObject.DORewind();
        FocusedObject.DOShakeScale(.5f, .5f, 3, 20, true);


    }
    public static bool IsPointerOverUI()
    {
#if UNITY_EDITOR
        return EventSystem.current.IsPointerOverGameObject();
#elif UNITY_ANDROID || UNITY_IOS
    return Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
#else
    return EventSystem.current.IsPointerOverGameObject();
#endif
    }

}
