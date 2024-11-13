using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
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

    public GameObject camara;

    public GameObject puVelocidadN1;
    public GameObject puCampoN1;
    public GameObject puLentitudN1;
    public GameObject puTripleDisparoN1;
    private bool velActN1 = false;
    private bool lenActN1 = false;
    private bool camActN1 = false;
    private bool salActN1 = false;

    public GameObject llaveCopia;
    public Text enemigos;


    public Volume globalVolume;
    private MotionBlur blur;



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
        Vector3 movement = new Vector3(inputX, 0.0f, inputY).normalized;
        rb.velocity = movement * velocidad;

        if (movement != Vector3.zero)
        {
            Vector3 forward = camara.transform.forward;
            Vector3 right = camara.transform.right;

            forward.y = 0;
            right.y = 0;

            forward.Normalize();
            right.Normalize();

            Vector3 moveDirection = forward * movement.z + right * movement.x;

            rb.velocity = moveDirection * velocidad;

            Quaternion toRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, velocidad * Time.deltaTime);
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
            puCampoN1.SetActive(false);
            puLentitudN1.SetActive(false);
            puTripleDisparoN1.SetActive(false);
            puVelocidadN1.SetActive(false);
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
            if (velActN1 == true)
            {
                puVelocidadN1.SetActive(true);
            }
            if (camActN1 == true)
            {
                puCampoN1.SetActive(true);
            }
            if (salActN1 == true)
            {
                puTripleDisparoN1.SetActive(true);
            }
            if (lenActN1 == true)
            {
                puLentitudN1.SetActive(true);
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

            if (globalVolume.profile != null)
            {
                if (globalVolume.profile.TryGet(out blur))
                {
                    blur.active = false;
                }
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PUvelocidad" || collision.gameObject.tag == "PUvelocidadN1")
        {
            velocidad = velocidad * 1.5f;
            collision.gameObject.SetActive(false);
            estadoPU();
            timer.gameObject.SetActive(true);
            PowerUp.gameObject.SetActive(true);
            PowerUp.text = "¡Velocidad turbo activada!";
            if (globalVolume.profile != null)
            {
                if (globalVolume.profile.TryGet(out blur))
                {
                    blur.active = true;
                }
            }
        }
        else if (collision.gameObject.tag == "PUlento" || collision.gameObject.tag == "PUlentoN1")
        {
            velocidad = 5;
            collision.gameObject.SetActive(false);
            estadoPU();
            timer.gameObject.SetActive(true);
            PowerUp.gameObject.SetActive(true);
            PowerUp.text = "Velocidad nivel tortuga activada. No debiste hacer eso...";

        }
        else if (collision.gameObject.tag == "PUtripleDisparo" || collision.gameObject.tag == "PUtripleDisparoN1")
        {
            flag.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
            estadoPU();
            timer.gameObject.SetActive(true);
            PowerUp.gameObject.SetActive(true);
            PowerUp.text = "Desbloqueaste otro disparo, ¡te servirá contra los clones!";

        }
        else if (collision.gameObject.tag == "PUcampo" || collision.gameObject.tag == "PUcampoN1")
        {
            campoProtector.SetActive(true);
            collision.gameObject.SetActive(false);
            estadoPU();
            timer.gameObject.SetActive(true);
            PowerUp.gameObject.SetActive(true);
            PowerUp.text = "Campo protector activado, aprovéchalo";

        }
        else if (collision.gameObject.tag == "EneVeloz" || collision.gameObject.tag == "BalasDelEnemigo" || collision.gameObject.tag == "EnemigoTeletransportador" ||
            collision.gameObject.tag == "EnemigoSaltador" || collision.gameObject.tag == "EnemigoSaltadorClon" || collision.gameObject.tag == "EnemigoMagnetico")
        {
            Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);
            timer.gameObject.SetActive(false);
            PowerUp.gameObject.SetActive(false);
            menu.gameObject.SetActive(false);
            enemigos.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Piso" || collision.gameObject.tag == "HabilitarSalto")
        {
            enElPiso = true;  
        }
        else if (collision.gameObject.tag == "PuertaSalida" && llaveCopia.activeInHierarchy)
        {
            llaveCopia.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Piso" || collision.gameObject.tag == "HabilitarSalto")
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

        if (puVelocidadN1.activeInHierarchy)
        {
            velActN1 = true;
        }
        else
        {
            velActN1 = false;
        }

        if (puCampoN1.activeInHierarchy)
        {
            camActN1 = true;
        }
        else
        {
            camActN1 = false;
        }

        if (puTripleDisparoN1.activeInHierarchy)
        {
            salActN1 = true;
        }
        else
        {
            salActN1 = false;
        }

        if (puLentitudN1.activeInHierarchy)
        {
            lenActN1 = true;
        }
        else
        {
            lenActN1 = false;
        }
    }
}
