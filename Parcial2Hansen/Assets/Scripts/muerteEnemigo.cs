using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class muerteEnemigo : MonoBehaviour
{
    private int contadorVidas = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bala")
        {
            if(gameObject.CompareTag("EnemigoTeletransportador"))
            {
                foreach (Transform hijo in transform)
                {
                    hijo.SetParent(null);
                    hijo.AddComponent<Rigidbody>();
                    hijo.AddComponent<CapsuleCollider>();
                }
            }

            if (gameObject.CompareTag("EnemigoFinal"))
            {
                contadorVidas++;

                if(contadorVidas >= 5)
                {

                    gameObject.SetActive(false);
                }
            } else
            {
                gameObject.SetActive(false);

            }


        }
    }
}
