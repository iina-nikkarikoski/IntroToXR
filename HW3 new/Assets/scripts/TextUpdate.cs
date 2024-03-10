using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class TextUpdate : MonoBehaviour
{
    public TMP_Text textDisplay;
    private Story story;

    private void Start()
    {
        if (story == null)
        {
            Debug.LogError("Story script reference not set in UIManager.");
            return;
        }
        story.OnButtonPressed += UpdateButtonListText;

        UpdateButtonListText(-1);
    }

    private void UpdateButtonListText(int x)
    {
        string listText = "Button List:\n" + string.Join("\n", story.buttonList);

        if (textDisplay != null)
        {
            textDisplay.text = listText;
        }
    }
}
