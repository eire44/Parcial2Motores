using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorEnemigos : MonoBehaviour
{
    public Text enemigos;
    List<GameObject> listaEnemigos = new List<GameObject>();
    List<GameObject> listaEnemigosClonada = new List<GameObject>();
    List<GameObject> listaEnemigosN1 = new List<GameObject>();
    public GameObject nivel1;
    private int cantidad;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objetos = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject o in objetos)
        {
            if (o.layer == 7)
            {
                listaEnemigos.Add(o);
            }
            if (o.layer == 8 && o.gameObject.tag != "Llave" && o.gameObject.tag != "CampoMagnetico")
            {
                listaEnemigosN1.Add(o);
            }
        }
        //listaEnemigosClonada = listaEnemigos;
        foreach (GameObject e in listaEnemigos)
        {
            listaEnemigosClonada.Add(e);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(nivel1.activeInHierarchy)
        {
            listaEnemigosClonada.Clear();
            foreach (GameObject enemigo in listaEnemigos)
            {
                if (enemigo.activeInHierarchy)
                {
                    listaEnemigosClonada.Add(enemigo);
                }

            }
            cantidad = listaEnemigos.Count;
        } else
        {
            listaEnemigosClonada.Clear();
            foreach (GameObject enemigo in listaEnemigosN1)
            {
                if (enemigo.activeInHierarchy)
                {
                    listaEnemigosClonada.Add(enemigo);
                }

            }
            cantidad = listaEnemigosN1.Count;
        }

        enemigos.text = "Enemigos: " + listaEnemigosClonada.Count + "/" + cantidad;
    }

}
