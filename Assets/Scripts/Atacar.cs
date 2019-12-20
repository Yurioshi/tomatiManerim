using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletForce = 30f;
    public Transform saida;
    public GameObject bala;

    private bool cooldown = false;
    private float cooldownTime;
    private float cooldownMaxTime;

    public GameObject hudAtaqueDis;
    public GameObject hudAtaqueFis;
    public GameObject ataque;

    public bool ataqueDis = false;
    public bool ataqueFis = true;
    public bool jaClicou = false;

    public Animator anim;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (ataqueDis == true)
            {
                Shoot();
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (ataqueFis == true)
            {
                Attack();
            }
        }

        if (Input.GetButtonDown("Fire2")) { Clique(); MudarAtaque(); }

        if (cooldownTime >= cooldownMaxTime)
        {
            cooldown = false;
        }

        else if (cooldown == true)
        {
            cooldownTime += Time.fixedDeltaTime;
        }
    }

    private void Shoot()
    {
        cooldownMaxTime = .4f;

        if (cooldown == false)
        {
            GameObject bullet = Instantiate(bala, saida.position, saida.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(saida.up * bulletForce, ForceMode2D.Impulse);
            cooldownTime = 0;
            cooldown = true;
        }
    }

    private void Attack()
    {
        cooldownMaxTime = .2f;

        if (cooldown == false)
        {
            anim.Rebind();
            cooldownTime = 0;
            cooldown = true;
        }
    }

    private void Clique()
    {
        if (jaClicou == false)
        {
            jaClicou = true;
            ataqueFis = false;
            ataqueDis = true;
        }

        else
        {
            jaClicou = false;
            ataqueFis = true;
            ataqueDis = false;
        }
    }

    private void MudarAtaque()
    {
        if (ataqueDis == true)
        {
            hudAtaqueDis.SetActive(true);
        }
        else
        {
            hudAtaqueDis.SetActive(false);
        }

        if (ataqueFis == true)
        {
            hudAtaqueFis.SetActive(true);
        }
        else
        {
            hudAtaqueFis.SetActive(false);
        }
    }
}
