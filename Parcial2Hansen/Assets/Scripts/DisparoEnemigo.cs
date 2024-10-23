using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public GameObject puerta;
    private int velocidad = 15;

    public GameObject bala;
    private int velocidadBala = 1000;
    private int velocidadRotacion = 60;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!puerta.gameObject.activeInHierarchy)
        {
            Vector3 centro = new Vector3(0, 1.2f, -6.5f);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, centro, velocidad * Time.deltaTime);

            transform.Rotate(0, Time.deltaTime * velocidadRotacion, 0);

            if(gameObject.transform.position == centro)
            {
                timer += Time.deltaTime;

                if(timer >= 0.5f)
                {
                    disparar();
                    timer = 0f;
                }
                
            }
        }
    }


    void disparar()
    {
        GameObject balaE = Instantiate(bala, bala.transform.position, transform.rotation);
        balaE.gameObject.tag = "BalasDelEnemigo";
        Rigidbody rb = balaE.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * velocidadBala);
    }
}
