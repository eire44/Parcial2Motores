using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerrarPuertaInicio : MonoBehaviour
{
    public GameObject puerta;
    Vector3 posicionOriginal;

    // Start is called before the first frame update
    void Start()
    {
        posicionOriginal = puerta.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            puerta.transform.position = posicionOriginal;
            puerta.transform.Rotate(0, 90, 0);
            gameObject.SetActive(false);
        }
    }
}
