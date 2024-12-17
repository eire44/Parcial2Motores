using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CajaFuerte : MonoBehaviour
{
    public GameObject interfazCodigo;
    public Text codigo;
    private int codigoAIngresar = 2604;
    public GameObject tapa;
    private bool abierto = false;
    private bool rotar = true;

    public GameObject llaveFinal;
    public GameObject llaveEnMano;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void  Update()
    {
        if(interfazCodigo.activeInHierarchy)
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(key))
                    {
                        string tecla = key.ToString();

                        if (tecla.StartsWith("Alpha"))
                        {
                            char numero = tecla[tecla.Length - 1];
                            codigo.text += numero.ToString();
                        }
                        else if (tecla == "Keypad0") codigo.text += "0";
                        else if (tecla == "Keypad1") codigo.text += "1";
                        else if (tecla == "Keypad2") codigo.text += "2";
                        else if (tecla == "Keypad3") codigo.text += "3";
                        else if (tecla == "Keypad4") codigo.text += "4";
                        else if (tecla == "Keypad5") codigo.text += "5";
                        else if (tecla == "Keypad6") codigo.text += "6";
                        else if (tecla == "Keypad7") codigo.text += "7";
                        else if (tecla == "Keypad8") codigo.text += "8";
                        else if (tecla == "Keypad9") codigo.text += "9";
                    }
                }
            }

        }

        if(codigo.text.Equals(codigoAIngresar.ToString()) && rotar)
        {
            interfazCodigo.SetActive(false);
            tapa.transform.Rotate(-80, 0, 0);
            abierto = true;
            rotar = false;

            llaveEnMano.SetActive(true);
            llaveFinal.SetActive(false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Caja Fuerte") && !abierto)
        {
            interfazCodigo.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Caja Fuerte") && !abierto)
        {
            interfazCodigo.SetActive(false);
            codigo.text = "";
        }
    }
}
