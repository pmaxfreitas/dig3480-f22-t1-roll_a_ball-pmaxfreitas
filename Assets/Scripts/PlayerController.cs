using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI livesText;
    public GameObject winTextObject;
    public GameObject resetButton;

    private Rigidbody rb;
    private int count;
    private int lives;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        lives = 3;

        resetButton.SetActive(false);
        winTextObject.SetActive(false);

        SetCountText();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        livesText.text = "Lives: " + lives.ToString();

        if(count >= 20)
        {
            winTextObject.SetActive(true);
            resetButton.SetActive(true);
        }
        if (count == 12)
        {
            transform.position = new Vector3(45.0f, 0.5f, 0.0f);
        }
        if (lives <= 0)
        {
            winTextObject.GetComponent<TextMeshProUGUI>().text = "GameOver!";
            winTextObject.SetActive(true);
            resetButton.SetActive(true);
            GameObject.Find("Player").GetComponent<Renderer>().material.color = new Color(0.05f, 0.38f, 0.43f);
            Destroy(this);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives--;

            SetCountText();
        }
    }
}