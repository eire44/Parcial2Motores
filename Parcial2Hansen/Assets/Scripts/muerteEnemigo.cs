using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class muerteEnemigo : MonoBehaviour
{
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
                    Debug.Log(hijo);
                    hijo.AddComponent<Rigidbody>();
                }
            }

            gameObject.SetActive(false);

        }
    }
}
