using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;
    private Vector2 movementValue;
    private float lookValue;

    [SerializeField] private Camera cam;

    public void OnMove(InputValue value){
        movementValue = value.Get<Vector2>() * speed;
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos) - transform.position;
        transform.Translate(movementValue.x * Time.deltaTime, 0, movementValue.y * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(mousePos, Vector3.up); 
    }
}
