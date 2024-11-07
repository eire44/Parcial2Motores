using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teletransportacion : MonoBehaviour
{
    public GameObject posicion1;
    public GameObject posicion2;
    public GameObject posicion3;
    public GameObject posicion4;
    public GameObject posicion5;


    private float tiempo = 2.3f;
    private int iterador = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;
        if(tiempo <= 0)
        {
            if (iterador == 0)
            {
                transform.position = posicion1.transform.position;
            }
            else if (iterador == 1)
            {
                transform.position = posicion2.transform.position;
            }
            else if (iterador == 2)
            {
                transform.position = posicion3.transform.position;
            } else if (iterador == 3)
            {
                transform.position = posicion4.transform.position;
            } else if(iterador == 4)
            {
                transform.position = posicion5.transform.position;
            }

            iterador++;
            if (iterador >= 5)
            {
                iterador = 0;
            }
            tiempo = 3;
        }
    }
}
