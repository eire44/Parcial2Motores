using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasEnemigo : MonoBehaviour
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
        if (collision.gameObject.tag != "EnemigoTirador" && collision.gameObject.tag != "BalasDelEnemigo" && collision.gameObject.tag != "EnemigoFinal")
        {
            
            gameObject.SetActive(false);
        }
    }
}
