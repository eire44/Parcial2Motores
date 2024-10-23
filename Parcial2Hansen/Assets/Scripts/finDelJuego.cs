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

    public Button reanudar;

    public Button comenzar;
    public Button menu;

    
    void Start()
    {
        Time.timeScale = 0;

        reiniciarV.onClick.AddListener(reiniciar);
        reiniciarP.onClick.AddListener(reiniciar);
        reiniciarM.onClick.AddListener(reiniciar);

        comenzar.onClick.AddListener(comenzarJ);

        menu.onClick.AddListener(abrirMenu);

        reanudar.onClick.AddListener(cerrarMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void comenzarJ()
    {
        inicio.SetActive(false);
        menu.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    void abrirMenu()
    {
        menuPrincipal.SetActive(true);
        Time.timeScale = 0;
    }

    void cerrarMenu()
    {
        menuPrincipal.SetActive(false);
        Time.timeScale = 1;
    }
}
