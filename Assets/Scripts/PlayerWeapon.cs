using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] lasers;
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Transform targetPoint;

    [SerializeField] private float targetDistance = 100f;
    

    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
       FiringProcess();
       MoveCrosshair();
       MoveTargetPoint();
       AimLasers();
    }

    void FiringProcess()
    {
        // var emissionModule = laser.GetComponent<ParticleSystem>().emission;
        // emissionModule.enabled = isFiring;
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }
    
    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            // Se calcula la dirección del disparo desde la posición del láser hasta el punto objetivo
            //Vector3 fireDirection = targetPoint.position - laser.transform.position;
            
            // Se calcula la dirección del disparo desde la posición del jugador hasta el punto objetivo
            Vector3 fireDirection = targetPoint.position - this.transform.position;

            // Se calcula la rotación necesaria para que el láser apunte hacia el punto objetivo
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);

            laser.transform.rotation = rotationToTarget;
        }
    }

    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    void MoveTargetPoint()
    {
       // ScreenToWorldPoint permite convertir la posición del mouse en coordenadas de mundo
       Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
       targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
}
