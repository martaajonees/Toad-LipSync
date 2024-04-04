using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Jugador : MonoBehaviour
{
    // publico
    public float velocidad = 7.0f;
    public Text comentario;
    // privado
    private Vector3 DireccionActual;
    private Rigidbody rb;
    private int puntos = 0;
    private Vector3 posicionInicial; // Guarda la posición inicial del jugador

    void Start()
    {
        string EscenaActual = SceneManager.GetActiveScene().name;
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position; // Guarda la posición inicial
    }

    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Si el jugador presiona alguna tecla de movimiento
        if (horizontalInput != 0 || verticalInput != 0)
        {
            CambiarDireccion(horizontalInput, verticalInput);
            
        }

        transform.Translate(DireccionActual * velocidad * Time.deltaTime);
    }




    void CambiarDireccion(float horizontalInput, float verticalInput)
    {
        Vector3 direccionDeseada = Vector3.zero;
        if (horizontalInput > 0)
        {
            direccionDeseada += Vector3.right;
            comentario.text = "Gira a la derecha";
        }
        else if (horizontalInput < 0)
        {
            direccionDeseada += -Vector3.right;
            comentario.text = "Gira a la izquierda";
        }

        if (verticalInput > 0)
        {
            direccionDeseada += Vector3.forward;
            comentario.text = "Avanza hacia adelante";
        }
        else if (verticalInput < 0)
        {
            direccionDeseada += -Vector3.forward;
            comentario.text = "Retrocede";
        }

        if (direccionDeseada != Vector3.zero)
        {
            DireccionActual = direccionDeseada;
        }
    }
}
