using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public GameObject puerta;
    private int velocidad = 15;

    public GameObject player;

    public GameObject bala;
    private int velocidadBala = 1000;
    private int velocidadRotacion = 60;

    private float timer = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        if(!puerta.gameObject.activeInHierarchy)
        {
            Vector3 centro = new Vector3(0, 1.2f, -6.5f);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, centro, velocidad * Time.deltaTime);


            Vector3 direccion = player.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, velocidadRotacion * Time.deltaTime);
            

            if (gameObject.transform.position == centro)
            {
                timer += Time.deltaTime;

                if (timer >= 1f)
                {
                    disparar();
                    timer = 0f;
                }

            }
        }
    }

    void disparar()
    {
        GameObject balaE = Instantiate(bala, transform.position + transform.forward, transform.rotation);
        balaE.gameObject.SetActive(true);
        balaE.tag = "BalasDelEnemigo";
        Rigidbody rb = balaE.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * velocidadBala);
    }
}
