using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxDist;

    private void Awake()
    {
        rb.drag = maxDist;        
    }

    void Start()
    {
        Destroy(this.gameObject, 5f);
    }
}
