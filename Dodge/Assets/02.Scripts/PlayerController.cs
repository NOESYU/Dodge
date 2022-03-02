using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float speed = 8f;
    public GameObject my;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        playerRb.velocity = newVelocity;
    }

    void DirectInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRb.AddForce(0f, 0f, speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            playerRb.AddForce(0f, 0f, -speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRb.AddForce(speed, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRb.AddForce(-speed, 0f, 0f);
        }
    }

    public void Die()
    {
        my.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.EndGame();
    }
}
