using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public Rigidbody2D rb;
    readonly float speed = 1f;
    Vector2 alvoV2;
    Vector3 alvoV3;
    readonly float h = 7.4f;
    readonly float v = 5.7f;

    private void Start()
    {
        alvoV2 = RandomPos();
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, alvoV2, speed * Time.deltaTime);
        Vector2 lookDir = alvoV2 - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        alvoV3 = new Vector3(alvoV2.x, alvoV2.y, transform.position.z);

        if(transform.position == alvoV3)
        {
            alvoV2 = RandomPos();
        }
    }

    Vector2 RandomPos()
    {
        Vector2 newPos;

        newPos.x = Random.Range(h * -1, h);
        newPos.y = Random.Range(v * -1, v);

        return newPos;
    }
}
