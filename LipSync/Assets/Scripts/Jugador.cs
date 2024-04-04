using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class Jugador : MonoBehaviour
{
    // Variables públicas
    public float velocidad = 7.0f;
    public Text comentario;
    public AudioClip[] audiosCambioDireccion; // Los audios que se reproducirán al cambiar de dirección

    // Variables privadas
    private Vector3 DireccionActual;
    private Rigidbody rb;
    private int puntos = 0;
    private Vector3 posicionInicial; // Guarda la posición inicial del jugador
    private AudioSource audioSource; // El AudioSource asociado al jugador

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position; // Guarda la posición inicial

        // Obtenemos o añadimos un AudioSource al objeto del jugador
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
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
        AudioClip audioACambiar = null;

        // Determinar la dirección deseada
        if (horizontalInput > 0)
        {
            direccionDeseada += Vector3.right;
            comentario.text = "Gira a la derecha";
            if (audiosCambioDireccion.Length > 0)
                audioACambiar = audiosCambioDireccion[0]; // Ejemplo: reproducir el primer audio
        }
        else if (horizontalInput < 0)
        {
            direccionDeseada += -Vector3.right;
            comentario.text = "Gira a la izquierda";
            if (audiosCambioDireccion.Length > 1)
                audioACambiar = audiosCambioDireccion[1]; // Ejemplo: reproducir el segundo audio
        }

        if (verticalInput > 0)
        {
            direccionDeseada += Vector3.forward;
            comentario.text = "Avanza hacia adelante";
            if (audiosCambioDireccion.Length > 2)
                audioACambiar = audiosCambioDireccion[2]; // Ejemplo: reproducir el tercer audio
        }
        else if (verticalInput < 0)
        {
            direccionDeseada += -Vector3.forward;
            comentario.text = "Retrocede";
            if (audiosCambioDireccion.Length > 3)
                audioACambiar = audiosCambioDireccion[3]; // Ejemplo: reproducir el cuarto audio
        }

        if (direccionDeseada != Vector3.zero && audioACambiar != null)
        {
            DireccionActual = direccionDeseada;

            // Reproducir el audio de cambio de dirección si está configurado
            audioSource.PlayOneShot(audioACambiar);
        }
    }

    // Método para cargar un archivo MP4 y extraer su audio
    public void CargarArchivoMP4(string filePath)
    {
        // Comprueba si el archivo seleccionado es un archivo MP4
        if (filePath.ToLower().EndsWith(".mp4"))
        {
            // Utiliza FFmpeg para extraer el audio del MP4
            string command = string.Format("ffmpeg -i \"{0}\" -vn -acodec pcm_s16le -ar 44100 -ac 2 \"{1}\"", filePath, Application.persistentDataPath + "/audio.wav");

            ProcessStartInfo info = new ProcessStartInfo("cmd.exe", "/c " + command);
            info.CreateNoWindow = true;
            info.UseShellExecute = true;

            Process.Start(info);
        }
    }
}
