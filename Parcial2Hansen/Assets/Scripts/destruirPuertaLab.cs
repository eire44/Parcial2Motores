using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirPuertaLab : MonoBehaviour
{
    public GameObject cartel1;
    public GameObject cartel2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("BalasDelEnemigo"))
        {
            cartel1.SetActive(false);
            cartel2.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
