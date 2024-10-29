using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject bala;
    private int velocidad = 2000;
    public GameObject flag;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            bala.SetActive(true);
            GameObject bala2 = Instantiate(bala, bala.transform.position, transform.rotation) as GameObject;
            //bala.transform.position += Time.deltaTime * velocidad * transform.forward;
            bala2.tag = "Bala";
            Rigidbody rb2 = bala2.GetComponent<Rigidbody>();

            rb2.AddForce(transform.forward * velocidad);

            if(flag.gameObject.activeInHierarchy)
            {

                GameObject bala3 = Instantiate(bala, bala.transform.position, bala.transform.rotation) as GameObject;
                bala3.transform.Rotate(0, 15, 0);
                bala3.tag = "Bala";
                Rigidbody rb3 = bala3.GetComponent<Rigidbody>();
                rb3.AddForce(transform.forward * velocidad);



                GameObject bala4 = Instantiate(bala, bala.transform.position, bala.transform.rotation) as GameObject;
                bala4.transform.Rotate(0, -15, 0);
                bala4.tag = "Bala";
                Rigidbody rb4 = bala4.GetComponent<Rigidbody>();
                rb4.AddForce(transform.forward * velocidad);
            }

            bala.SetActive(false);
        }
    }
}
