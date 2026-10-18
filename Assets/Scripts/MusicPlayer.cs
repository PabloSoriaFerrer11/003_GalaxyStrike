using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Singleton like pattern

    void Start()
    {
       int numMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;

       if(numMusicPlayers > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }
}
