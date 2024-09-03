using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderColision : MonoBehaviour
{
    // Referencia al componente CharacterController del personaje.
    public CharacterController controller;

    // Velocidad de movimiento del personaje.
    public float speed = 6f;

    // Fuerza de la gravedad aplicada al personaje.
    public float gravity = -9.81f;

    // Transform usado para verificar si el personaje está tocando el suelo.
    public Transform groundCheck;

    // Radio de la esfera usada para detectar si el personaje está en el suelo.
    public float groundDistance = 0.4f;

    // Máscara de capas que se consideran como "suelo".
    public LayerMask groundMask;

    // Vector que almacena la velocidad del personaje, especialmente en el eje Y.
    Vector3 velocity;

    // Variable booleana que indica si el personaje está tocando el suelo.
    bool isGrounded;

    void Update()
    {
        // Verifica si el personaje está en el suelo mediante una esfera invisible en la posición del groundCheck.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Si el personaje está en el suelo y su velocidad en Y es negativa (está cayendo), resetea la velocidad en Y.
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Evita que el personaje continúe acelerando hacia abajo.
        }

        // Obtiene la entrada del jugador en los ejes X (horizontal) y Z (vertical).
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calcula el vector de movimiento en función de la entrada del jugador y la orientación del personaje.
        Vector3 move = transform.right * x + transform.forward * z;

        // Mueve el personaje en la dirección calculada, ajustado por la velocidad y el tiempo entre frames.
        controller.Move(move * speed * Time.deltaTime);

        // Aplica la gravedad al personaje en el eje Y.
        velocity.y += gravity * Time.deltaTime;

        // Mueve el personaje en el eje Y en función de la gravedad.
        controller.Move(velocity * Time.deltaTime);
    }
}

