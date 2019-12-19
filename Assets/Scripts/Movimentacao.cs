using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    public Camera cam;

    private Vector2 movement;
    private Vector2 mousePos;

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(speed * movement.x, 0), ForceMode2D.Force);
        rb.AddForce(new Vector2(0, speed * movement.y), ForceMode2D.Force);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
