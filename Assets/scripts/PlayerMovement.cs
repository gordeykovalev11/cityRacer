using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 startPosition;
    public GameManager gameManager;
    public float speed = 0f;
    public float rotationSpeed = 15f;
    public float horizontal, vertical;
    public float acceleration = 20f;
    public float deceleration = 10f;
    public float maxReverseSpeed = -20f;
    public float maxSpeed = 25f;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (OutOfBounds())
        {
            transform.position = startPosition;   
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (vertical > 0 )
        {
            speed = Mathf.MoveTowards(speed,maxSpeed, acceleration * Time.deltaTime);
        }
        else if (vertical < 0 )
        {
            speed = Mathf.MoveTowards(speed, maxReverseSpeed, deceleration * Time.deltaTime);
        }
        else
        {
            speed = Mathf.MoveTowards(speed, 0, deceleration * Time.deltaTime);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime * vertical);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontal);
        //transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
        //if (Input.GetKey(KeyCode.W))
        //{ transform.Translate(Vector3.forward * speed * Time.deltaTime); } //time.DeltaTime - время одного кадра
        //if (Input.GetKey(KeyCode.S))
        //{ transform.Translate(Vector3.back * speed * Time.deltaTime); }
        //if (Input.GetKey(KeyCode.D))
        //{ transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("checkPoint"))
        {
            gameManager.CheckPointReached(other.gameObject);
        }
        if (other.CompareTag("Finish"))
        {
            gameManager.FinishReached(other.gameObject);
        }
    }
    bool OutOfBounds()
    {
        if (transform.position.y < -10)
        {
            return true;
        }
        else return false;
    }
}
