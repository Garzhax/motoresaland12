using UnityEngine; // Importa la biblioteca de Unity, necesaria para trabajar con componentes y funcionalidades de Unity.

public class PlayerMovement : MonoBehaviour // Declara una nueva clase llamada 'SphereMovement' que hereda de 'MonoBehaviour', la clase base para los scripts en Unity.
{
    public float moveSpeed = 5f; // Declara una variable pública de tipo float que controla la velocidad de movimiento de la esfera. Es pública para que puedas ajustar la velocidad desde el Inspector en Unity.

    public Rigidbody rb; // Declara una variable pública de tipo 'Rigidbody', que se usará para referenciar el componente Rigidbody de la esfera.

    void Start() // Este método se llama una vez al inicio, cuando el juego comienza. Aquí se inicializan las variables o se preparan los componentes.
    {
        // Si 'rb' no ha sido asignado en el Inspector, se intenta obtener el Rigidbody del mismo objeto al que está asignado este script.
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>(); // 'GetComponent<Rigidbody>()' busca y obtiene el componente Rigidbody adjunto al objeto.
        }
    }

    void Update() // Este método se llama una vez por frame, es donde se maneja la lógica de movimiento.
    {
        // Obtiene el input del jugador para el movimiento horizontal (flechas izquierda/derecha o teclas A/D).
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Obtiene el input del jugador para el movimiento vertical (flechas arriba/abajo o teclas W/S).
        float moveVertical = Input.GetAxis("Vertical");

        // Crea un vector que representa la dirección del movimiento basado en el input del jugador.
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Aplica una fuerza al Rigidbody en la dirección del vector 'movement' multiplicada por la velocidad de movimiento.
        rb.AddForce(movement * moveSpeed);
    }
}
