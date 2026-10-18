using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem enemyDeathFX;
    [SerializeField] private ParticleSystem playerDeathFX;

    GameSceneManager gameSceneManager;

    void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        HandlePlayerCollision(other);
    }

    private void HandlePlayerCollision(Collider player)
    {
        gameSceneManager.ReloadLevel();
        if (playerDeathFX != null)
        {
            Instantiate(playerDeathFX, transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
        

    }
}
