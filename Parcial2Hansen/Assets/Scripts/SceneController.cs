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
    public GameObject puertaNivel;

    public Button menu;


    public GameObject eneVN1;
    public GameObject eneSN1;
    public GameObject eneTN1;
    public GameObject eneMN1;
    public GameObject eneTelN1;

    public GameObject puertaFinal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(!eneV.gameObject.activeInHierarchy && !eneS.gameObject.activeInHierarchy && !eneT.gameObject.activeInHierarchy)
        {
            if(puertaNivel.transform.rotation == Quaternion.Euler(0, 90, 0))
            {
                puertaNivel.SetActive(false);
                //puertaNivel.transform.Rotate(0, 90, 0);
                //puertaNivel.transform.position = new Vector3(0f, 5.844141f, 10f);
            }
            
        }

        if(!eneVN1.gameObject.activeInHierarchy && !eneSN1.gameObject.activeInHierarchy && !eneTN1.gameObject.activeInHierarchy 
            && !eneMN1.gameObject.activeInHierarchy && !eneTelN1.gameObject.activeInHierarchy && !puertaFinal.activeInHierarchy)
        {
            victoria.SetActive(true);
            menu.gameObject.SetActive(false);
            PowerUp.gameObject.SetActive(false);
            timer.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

}
