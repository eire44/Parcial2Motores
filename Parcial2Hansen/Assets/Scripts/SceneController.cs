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

    public Button menu;
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
            victoria.SetActive(true);
            menu.gameObject.SetActive(false);
            PowerUp.gameObject.SetActive(false);
            timer.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

}
