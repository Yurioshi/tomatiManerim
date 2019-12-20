using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform alvo;
    public float speed;

    private float dist;
    private float maxDist = 4;

    private void Awake()
    {
        alvo = GameObject.Find("Tomate1").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Olhar();

        if (dist >= maxDist)
        {
            Andar();
        }
    }

    private void Update()
    {
        dist = Vector2.Distance((Vector2)transform.position, (Vector2)alvo.position);
    }

    private void Olhar()
    {
        Vector2 lookDir = (Vector2)alvo.position - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void Andar()
    {
        rb.MovePosition((Vector2)transform.position + ((Vector2)transform.up * speed * Time.deltaTime));
    }
}
