using UnityEngine;
using TMPro;

public class DialogLines : MonoBehaviour
{
    [SerializeField] string[] timelineDialogLines;
    [SerializeField] TMP_Text dialogText;

    int currentDialogIndex = 0;
    public void NextDialogLine()
    {
        currentDialogIndex++;
        dialogText.text = timelineDialogLines[currentDialogIndex];
    }
}
