using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas : MonoBehaviour
{
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
        if(collision.gameObject.tag == "Puerta")
        {
            collision.gameObject.SetActive(false);
        }
        if(!(collision.gameObject.tag == "Player"))
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "EnemigoSaltador")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
