using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class campoProtector : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BalasDelEnemigo")
        {

            other.gameObject.SetActive(false);
        }
    }
}
