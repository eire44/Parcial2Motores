using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerrarPuertaInicio : MonoBehaviour
{
    public GameObject puerta;
    public GameObject ventana;

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
        if(collision.gameObject.CompareTag("Player"))
        {
            puerta.SetActive(true);
            ventana.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
