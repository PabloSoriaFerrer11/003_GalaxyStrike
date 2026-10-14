using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject destroyEffect;

    [SerializeField] int hitPoints = 6;
    
    [SerializeField] int scoreValue = 10;

    Scoreboard scoreboard;

    void Start()
    {
        // Se busca el primer objeto de tipo Scoreboard en la escena. Esto es costoso para CPU
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    // Para poder detectar la colisión de partículas , se debe activar la opción "Send Collision Messages" en el sistema de partículas del láser del jugador.
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Enemy collided with: " + other.name);

        ProcessHit();

    }

    private void ProcessHit()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            // Instaciación del efecto
            // Quaternion.identity representa la rotación por defecto (sin rotación) para el efecto de destrucción
            Instantiate(destroyEffect, transform.position, Quaternion.identity);

            Destroy(this.gameObject); // Destruye el enemigo al colisionar con un láser    

            scoreboard.IncreaseScore(scoreValue);            
        }
    }
}
