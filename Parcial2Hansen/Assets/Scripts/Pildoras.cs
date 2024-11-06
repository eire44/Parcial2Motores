using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pildoras : MonoBehaviour
{
    public Text timer;
    private float tiempo = 20f;

    public GameObject flag;

    public Text PowerUp;

    public GameObject campoProtector;

    public GameObject puVelocidad;
    public GameObject puCampo;
    public GameObject puLentitud;
    public GameObject puTripleDisparo;
    private bool velAct = false;
    private bool lenAct = false;
    private bool camAct = false;
    private bool salAct = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.gameObject.activeInHierarchy)
        {
            timer.text = tiempo.ToString();
            tiempo -= Time.deltaTime;
            puCampo.SetActive(false);
            puLentitud.SetActive(false);
            puTripleDisparo.SetActive(false);
            puVelocidad.SetActive(false);
        }
        else
        {
            if (velAct == true)
            {
                puVelocidad.SetActive(true);
            }
            if (camAct == true)
            {
                puCampo.SetActive(true);
            }
            if (salAct == true)
            {
                puTripleDisparo.SetActive(true);
            }
            if (lenAct == true)
            {
                puLentitud.SetActive(true);
            }

            PowerUp.gameObject.SetActive(false);
        }


        if (tiempo <= 0)
        {
            timer.gameObject.SetActive(false);
            tiempo = 20;

            //velocidad = 20;
            campoProtector.SetActive(false);
            flag.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PUvelocidadN1")
        {
            //velocidad = velocidad * 2;
            collision.gameObject.SetActive(false);
            estadoPU();
            timer.gameObject.SetActive(true);
            PowerUp.gameObject.SetActive(true);
            PowerUp.text = "¡Velocidad turbo activada!";

        }
        else if (collision.gameObject.tag == "PUlentoN1")
        {
            //velocidad = 5;
            collision.gameObject.SetActive(false);
            estadoPU();
            timer.gameObject.SetActive(true);
            PowerUp.gameObject.SetActive(true);
            PowerUp.text = "Velocidad nivel tortuga activada. No debiste hacer eso...";

        }
        else if (collision.gameObject.tag == "PUtripleDisparoN1")
        {
            flag.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
            estadoPU();
            timer.gameObject.SetActive(true);
            PowerUp.gameObject.SetActive(true);
            PowerUp.text = "Desbloqueaste otro disparo, ¡te servirá contra los clones!";

        }
        else if (collision.gameObject.tag == "PUcampoN1")
        {
            campoProtector.SetActive(true);
            collision.gameObject.SetActive(false);
            estadoPU();
            timer.gameObject.SetActive(true);
            PowerUp.gameObject.SetActive(true);
            PowerUp.text = "Campo protector activado, aprovéchalo";

        }
    }

    private void estadoPU()
    {
        if (puVelocidad.activeInHierarchy)
        {
            velAct = true;
        }
        else
        {
            velAct = false;
        }

        if (puCampo.activeInHierarchy)
        {
            camAct = true;
        }
        else
        {
            camAct = false;
        }

        if (puTripleDisparo.activeInHierarchy)
        {
            salAct = true;
        }
        else
        {
            salAct = false;
        }

        if (puLentitud.activeInHierarchy)
        {
            lenAct = true;
        }
        else
        {
            lenAct = false;
        }
    }
}
