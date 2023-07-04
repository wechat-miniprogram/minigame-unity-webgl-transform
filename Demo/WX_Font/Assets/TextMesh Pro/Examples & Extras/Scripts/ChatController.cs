using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatController : MonoBehaviour {


    public TMP_InputField ChatInputField;

    public TMP_Text ChatDisplayOutput;

    public Scrollbar ChatScrollbar;

    void OnEnable()
    {
        ChatInputField.onSubmit.AddListener(AddToChatOutput);
    }

    void OnDisable()
    {
        ChatInputField.onSubmit.RemoveListener(AddToChatOutput);
    }


    void AddToChatOutput(string newText)
    {
        // Clear Input Field
        ChatInputField.text = string.Empty;

        var timeNow = System.DateTime.Now;

        string formattedInput = "[<#FFFF80>" + timeNow.Hour.ToString("d2") + ":" + timeNow.Minute.ToString("d2") + ":" + timeNow.Second.ToString("d2") + "</color>] " + newText;

        if (ChatDisplayOutput != null)
        {
            // No special formatting for first entry
            // Add line feed before each subsequent entries
            if (ChatDisplayOutput.text == string.Empty)
                ChatDisplayOutput.text = formattedInput;
            else
                ChatDisplayOutput.text += "\n" + formattedInput;
        }

        // Keep Chat input field active
        ChatInputField.ActivateInputField();

        // Set the scrollbar to the bottom when next text is submitted.
        ChatScrollbar.value = 0;
    }

}
