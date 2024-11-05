using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerEn1 : MonoBehaviour
{
    private bool enAlerta;
    public int rango;
    public LayerMask jugadorCapa;
    public int velocidad;
    public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enAlerta = Physics.CheckSphere(transform.position, rango, jugadorCapa);
        if(enAlerta)
        {
            Vector3 posJugador = jugador.transform.position;
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);
        }
    }
}
