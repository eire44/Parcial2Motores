using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerEn2 : MonoBehaviour
{
    private bool enAlerta;
    public int rango;
    public LayerMask jugadorCapa;
    public int velocidad;
    public GameObject jugador;

    public GameObject bala;
    private int velocidadBala = 1000;
    private float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enAlerta = Physics.CheckSphere(transform.position, rango, jugadorCapa);
        if (enAlerta)
        {
            Vector3 posJugador = jugador.transform.position;
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);
            timer += Time.deltaTime;

            if (timer >= 1f)
            {
                disparar();
                timer = 0f;
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
