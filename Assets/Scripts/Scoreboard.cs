using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    // Para pasar el valor del score a la UI
    [SerializeField] private TMP_Text scoreText;

    int score = 0;
    

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
