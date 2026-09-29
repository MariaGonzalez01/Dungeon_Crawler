using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Las variables se escriben en camelCase
    //Los métodos, clases y funciones se escriben en PascalCase

    Rigidbody rb; //Declara la variable
    [SerializeField] Vector3 movementDirection; //Permite usar la variable privada en el editor de Unity como una pública
    [SerializeField] private float horizontalMovement;
    [SerializeField] private float forwardMovement;
    [SerializeField] private float movementVelocity = 50;

    void Start() //Se ejecuta nada más que inicia el juego
    {
        rb = GetComponent<Rigidbody>(); //Inicializa la variable
        movementDirection = new Vector3(horizontalMovement, 0, forwardMovement);
    }

    void Update() //Se ejecuta en cada frame, la velocidad depende del ordenador
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        forwardMovement = Input.GetAxis("Vertical");
        movementDirection = new Vector3(horizontalMovement, 0, forwardMovement);
    }

    void Awake() //Se ejecuta cuando un GO aparece en escena
    {

    }

    //Update que se ejecuta 100 veces/segundo, independientemente del ordenador
    //Es la frecuencia con la que se actualiza el sistema de físicas
    void FixedUpdate()
    {
        rb.AddForce(movementDirection, ForceMode.Acceleration);
        /*
        ForceMode.Acceleration; Aceleración constante - Un coche
        ForceMode.Impulse; Da un solo impulso - Si me empujan en hielo, empieza con fuerza y se reduce
        ForceMode.VelocityChange; Cambia la velocidad - Me establece una velocidad concreta
        ForceMode.Force; Añade fuerza - Le da un empujón
        */
    }

    void LateUpdate() //
    {

    }

}