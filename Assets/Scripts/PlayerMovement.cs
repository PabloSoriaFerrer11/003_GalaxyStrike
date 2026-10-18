using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float xClampRange = 12f;
    [SerializeField] private float yClampRange = 9f;

    [SerializeField] private float controlRollFactor = 25f;
    [SerializeField] private float controlPitchFactor = 15f;
    

    Vector2 movementInput;


    void Start()
    {

    }

    void Update()
    {
        MovementProcess();
        RotationProcess();
    }

    private void MovementProcess()
    {
        // Con el Timeline el jugador recorre el escenario
        // Los controles del jugador solo afectan la posición en X y Y
        float xOffset = movementInput.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;

        // Se limita la posición en X del jugador para que no se salga de la pantalla
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);
        
        float yOffset = movementInput.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;

        // Se limita la posición en Y del jugador para que no se salga de la pantalla
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(
            clampedXPos,
            clampedYPos,
            0f);
    }

    private void RotationProcess()
    {
        float pitch = -controlPitchFactor * movementInput.y;
        float roll = -controlRollFactor * movementInput.x;

        // Quaternion.Euler permite rotar el jugador en los ejes X, Y y Z
        // El negativo en el eje Z es para que el jugador rote hacia la izquierda cuando se mueve a la derecha y viceversa
        Quaternion target = Quaternion.Euler(pitch, 0f, roll);

        // lerp permite suavizar la rotación del jugador para que no sea tan brusca
        transform.localRotation = Quaternion.Lerp(transform.localRotation, target, Time.deltaTime * rotationSpeed);
        //transform.localRotation = target;


    }

    public void OnMove(InputValue value)
    {
        // Se obtiene el valor del input del jugador
        movementInput = value.Get<Vector2>();
    }

  
}
