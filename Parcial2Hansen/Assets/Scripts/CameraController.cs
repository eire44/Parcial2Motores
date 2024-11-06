using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject jugador;
    private float sensibilidad = 5f;
    private float rotacion = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxis("Mouse X") * sensibilidad;
            float mouseY = Input.GetAxis("Mouse Y") * sensibilidad;

            rotacion -= mouseY;
            rotacion = Mathf.Clamp(rotacion, -90f, 90f);

            transform.localRotation = Quaternion.Euler(rotacion, 0f, 0f);
            jugador.transform.Rotate(Vector3.up * mouseX);
            //transform.position = new Vector3(jugador.transform.position.x, jugador.transform.position.y + 5, jugador.transform.position.z -5);
        } else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
