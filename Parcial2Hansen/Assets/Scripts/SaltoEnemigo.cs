using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoEnemigo : MonoBehaviour
{
    public float jumpForce = 500f;
    public float jumpInterval = 1f;
    private Rigidbody rb;
    public GameObject enemigo;
    private float timer = 0f;
    private int contadorClones = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Jump", 0f, jumpInterval);
        //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
            if (gameObject.CompareTag("EnemigoSaltador"))
            {
                timer += Time.deltaTime;

                if (timer >= 1.5f)
                {

                    Clonar();
                    contadorClones++;
                    timer = 0f;
                }
            }
        
    }

    void Jump()
    {
        // Generar una dirección aleatoria
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)).normalized;
        //Vector3 randomDirection = Vector3.up; Para que solo salte hacia arriba, ignorando los ejes x y z
        
        rb.AddForce(randomDirection * jumpForce, ForceMode.Impulse);
    }

    void Clonar()
    {
        GameObject Clon = Instantiate(enemigo, transform.position + transform.forward, transform.rotation);
        Clon.tag = "EnemigoSaltadorClon";
        //Clon.transform.SetParent(transform);
        Rigidbody rb = Clon.GetComponent<Rigidbody>();
    }
}
