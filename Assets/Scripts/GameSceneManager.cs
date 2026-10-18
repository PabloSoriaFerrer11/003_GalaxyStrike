using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void ReloadLevel()
    {
        // Se inicia la corrutina para recargar el nivel después de un segundo
        StartCoroutine(ReloadLevelRoutine());
    }

    IEnumerator ReloadLevelRoutine()
    {
        yield return new WaitForSeconds(1f);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;        
        SceneManager.LoadScene(currentSceneIndex);
        
    }
}
