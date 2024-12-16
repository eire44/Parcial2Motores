using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public GameObject eneV;
    public GameObject eneS;
    public GameObject eneT;
    public GameObject victoria;
    public Text timer;
    public Text PowerUp;
    public Text enemigos;
    public GameObject puertaNivel;

    public GameObject ventanaPuertaNivel;
    public Button menu;


    public GameObject eneVN1;
    public GameObject eneSN1;
    public GameObject eneTN1;
    public GameObject eneMN1;
    public GameObject eneTelN1;

    public GameObject puertaFinal;

    public GameObject jugador;
    public GameObject pasoNivel;

    public GameObject flagPuertaFinal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R)) //&& pasoNivel.activeInHierarchy
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } 
        //else if (Input.GetKey(KeyCode.R) && !pasoNivel.activeInHierarchy)
        //{
        //    jugador.transform.position = new Vector3(pasoNivel.transform.position.x, jugador.transform.position.y, pasoNivel.transform.position.z);
        //}

        if(!eneV.gameObject.activeInHierarchy && !eneS.gameObject.activeInHierarchy && !eneT.gameObject.activeInHierarchy)
        {
            puertaNivel.SetActive(false);
            ventanaPuertaNivel.SetActive(false);

        }

        if(!eneVN1.gameObject.activeInHierarchy && !eneSN1.gameObject.activeInHierarchy && !eneTN1.gameObject.activeInHierarchy 
            && !eneMN1.gameObject.activeInHierarchy && !eneTelN1.gameObject.activeInHierarchy)
        {
            flagPuertaFinal.SetActive(true);

            if(!puertaFinal.activeInHierarchy)
            {
                victoria.SetActive(true);
                menu.gameObject.SetActive(false);
                PowerUp.gameObject.SetActive(false);
                timer.gameObject.SetActive(false);
                enemigos.gameObject.SetActive(false);
                Time.timeScale = 0;

            }
        }

    }
    
}
