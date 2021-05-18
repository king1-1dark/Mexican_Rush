using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Transform Cross;
    public static Player_Controller instance;
    public float moveSpeed = 5f;  //Скорость персонажа
    public Camera cam;
    public Rigidbody2D rb;
    public Vector2 lookDir;
    Vector2 mousePos;
    Vector2 movement;
    private void Awake()
    {
        Cursor.visible = false;
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Time.timeScale == 1)
            Cross.position = Input.mousePosition;
        else
            Cross.gameObject.SetActive(false);
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
