using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject bala;
    private int velocidad = 2000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            bala.SetActive(true);
            //Instantiate(bala, bala.transform.position, transform.rotation);
            GameObject bala2 = Instantiate(bala, bala.transform.position, transform.rotation) as GameObject;
            //bala.transform.position += Time.deltaTime * velocidad * transform.forward;
            bala2.tag = "Bala";
            Rigidbody rb = bala2.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * velocidad);
            bala.SetActive(false);
        }
    }
}
