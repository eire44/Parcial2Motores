using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovJugador : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidad;
    public GameObject campoProtector;

    private bool enElPiso = false;
    private float fuerzaDeSalto = 300f;

    public Text timer;
    private float tiempo = 20f;

    public GameObject flag;

    public Text PowerUp;

    public GameObject puVelocidad;
    public GameObject puCampo;
    public GameObject puLentitud;
    public GameObject puTripleDisparo;
    private bool velAct = false;
    private bool lenAct = false;
    private bool camAct = false;
    private bool salAct = false;


    public GameObject gameOver;
    public Button menu;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(inputX * velocidad, 0.0f, inputY * velocidad);
        rb.velocity = movement;

        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }

        if(Input.GetKeyDown(KeyCode.Space) && enElPiso)
        {
            rb.AddForce(Vector3.up * fuerzaDeSalto, ForceMode.Impulse);
        }
        if(!enElPiso)
        {
            rb.AddForce(Vector3.down * 300f, ForceMode.Acceleration);
        }

        if(timer.gameObject.activeInHierarchy)
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

            velocidad = 20;
            campoProtector.SetActive(false);
            flag.gameObject.SetActive(false);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PUvelocidad")
        {
            velocidad = velocidad * 2;
            collision.gameObject.SetActive(false);
            estadoPU();
            timer.gameObject.SetActive(true);
            PowerUp.gameObject.SetActive(true);
            PowerUp.text = "¡Velocidad turbo activada!";

        } else if (collision.gameObject.tag == "PUtripleDisparo")
        {
            velocidad = 5;
            collision.gameObject.SetActive(false);
            estadoPU();
            timer.gameObject.SetActive(true);
            PowerUp.gameObject.SetActive(true);
            PowerUp.text = "Velocidad nivel tortuga activada. No debiste hacer eso...";

        }
        else if (collision.gameObject.tag == "PUsalto")
        {
            flag.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
            estadoPU();
            timer.gameObject.SetActive(true);
            PowerUp.gameObject.SetActive(true);
            PowerUp.text = "Desbloqueaste otro disparo, ¡te servirá contra los clones!";

        }
        else if (collision.gameObject.tag == "PUcampo")
        {
            campoProtector.SetActive(true);
            collision.gameObject.SetActive(false);
            estadoPU();
            timer.gameObject.SetActive(true);
            PowerUp.gameObject.SetActive(true);
            PowerUp.text = "Campo protector activado, aprovéchalo";

        } else if (collision.gameObject.tag == "EneVeloz" || collision.gameObject.tag == "BalasDelEnemigo" || collision.gameObject.tag == "EnemigoSaltador" || collision.gameObject.tag == "EnemigoSaltadorClon")
        {
            gameOver.gameObject.SetActive(true);
            menu.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else if (collision.gameObject.tag == "Piso")
        {
            enElPiso = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Piso")
        {
            enElPiso = false;
        }
    }

    private void estadoPU()
    {
        if (puVelocidad.activeInHierarchy)
        {
            velAct = true;
        } else
        {
            velAct = false;
        }

        if (puCampo.activeInHierarchy)
        {
            camAct = true;
        } else
        {
            camAct = false;
        }

        if (puTripleDisparo.activeInHierarchy)
        {
            salAct = true;
        } else
        {
            salAct = false;
        }

        if (puLentitud.activeInHierarchy)
        {
            lenAct = true;
        } else
        {
            lenAct = false;
        }
    }
}
