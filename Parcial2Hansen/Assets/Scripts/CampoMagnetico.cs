using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoMagnetico : MonoBehaviour
{
    bool dentroDelCampo;
    public GameObject jugador;
    public GameObject enemigo;
    public int velocidad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dentroDelCampo)
        {
            jugador.transform.position = Vector3.MoveTowards(jugador.transform.position, enemigo.transform.position, velocidad * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            dentroDelCampo = true;
        }
    }
}
