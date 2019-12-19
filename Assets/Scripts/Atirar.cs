using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public float bulletForce = 30f;
    public Transform saida;
    public GameObject bala;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shoot();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bala, saida.position, saida.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(saida.up * bulletForce, ForceMode2D.Impulse);
    }
}
