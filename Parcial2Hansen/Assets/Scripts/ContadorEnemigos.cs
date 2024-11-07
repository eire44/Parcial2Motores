using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorEnemigos : MonoBehaviour
{
    public Text enemigos;
    List<GameObject> listaEnemigos = new List<GameObject>();
    List<GameObject> listaEnemigosClonada = new List<GameObject>();

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
        listaEnemigosClonada.Clear();
        foreach (GameObject enemigo in listaEnemigos)
        {
            if (enemigo.activeInHierarchy)
            {
                listaEnemigosClonada.Add(enemigo);
            }

            
        }
        enemigos.text = "Enemigos: " + listaEnemigosClonada.Count + "/3";
    }

}
