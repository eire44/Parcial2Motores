using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropLlave : MonoBehaviour
{
    public GameObject llaveCopia;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            llaveCopia.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
