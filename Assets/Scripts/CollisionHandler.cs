using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem enemyDeathFX;
    [SerializeField] private ParticleSystem playerDeathFX;

    void OnTriggerEnter(Collider other)
    {
        HandlePlayerCollision(other);
    }

    private void HandlePlayerCollision(Collider player)
    {
        if (playerDeathFX != null)
        {
            Instantiate(playerDeathFX, transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}
