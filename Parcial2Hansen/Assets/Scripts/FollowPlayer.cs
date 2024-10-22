using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform jugador;
    private int velocidad = 45;
    public GameObject puerta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!puerta.activeInHierarchy)
        {

            transform.position = Vector3.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);
        }
    }
}
