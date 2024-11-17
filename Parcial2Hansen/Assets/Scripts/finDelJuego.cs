using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finDelJuego : MonoBehaviour
{
    public GameObject inicio;
    public GameObject menuPrincipal;

    public Button reiniciarV;
    public Button reiniciarM;
    public Button reiniciarP;

    public Button instruccionesM;
    public GameObject instrucciones;
    public Button volverInstrucciones;

    public Button reanudar;
    public Button salirM;
    public Button salirV;
    public Button salirP;
    public Button salirI;

    public Button comenzar;
    public Button menu;

    public Text enemigos;

    public GameObject pasoNivel;
    public GameObject jugador;
    void Start()
    {
        Time.timeScale = 0;

        reiniciarV.onClick.AddListener(reiniciar);
        reiniciarP.onClick.AddListener(reiniciar);
        reiniciarM.onClick.AddListener(reiniciar);

        comenzar.onClick.AddListener(comenzarJ);

        salirM.onClick.AddListener(salirDelJuego);
        salirP.onClick.AddListener(salirDelJuego);
        salirV.onClick.AddListener(salirDelJuego);
        salirI.onClick.AddListener(salirDelJuego);

        reanudar.onClick.AddListener(cerrarMenu);
        instruccionesM.onClick.AddListener(mostrarInstrucciones);
        volverInstrucciones.onClick.AddListener(cerrarInstrucciones);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            abrirMenu();
        }
    }


    void reiniciar()
    {
        //if (pasoNivel.activeInHierarchy)
        //{
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
        //else if (!pasoNivel.activeInHierarchy)
        //{
        //    jugador.transform.position = new Vector3(pasoNivel.transform.position.x, jugador.transform.position.y, pasoNivel.transform.position.z);
        //}
    }

    void comenzarJ()
    {
        inicio.SetActive(false);
        menu.gameObject.SetActive(true);
        enemigos.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    void abrirMenu()
    {
        menuPrincipal.SetActive(true);
        menu.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    void cerrarMenu()
    {
        menuPrincipal.SetActive(false);
        menu.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    void salirDelJuego()
    {
        #if UNITY_EDITOR  //Es una directiva de preprocesador que se evalúa antes de la compilación. Esto significa que el código dentro de esta directiva 
                            //solo se incluye en el compilado si la condición se cumple, lo cual es útil para ejecutar código que solo debe funcionar en el editor de Unity.
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    void mostrarInstrucciones()
    {
        menuPrincipal.SetActive(false);
        instrucciones.SetActive(true);
    }

    void cerrarInstrucciones()
    {
        menuPrincipal.SetActive(true);
        instrucciones.SetActive(false);
    }
}
