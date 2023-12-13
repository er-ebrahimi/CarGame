using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isWalking;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameController gameInput; //Note

    [SerializeField] private GameObject[] lights;

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f ,inputVector.y);
        isWalking = moveDir != Vector3.zero;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * moveSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== "Tunnel")
        {
            foreach(GameObject light in lights)
            {
                light.SetActive(true);
            }
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag== "Tunnel")
        {
            foreach(GameObject light in lights)
            {
                light.SetActive(false);
            }
        }
    }
}
