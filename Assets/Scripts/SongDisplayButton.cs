using UnityEngine;
using TMPro;

public class SongDisplayButton : MonoBehaviour
{
    public TextMeshProUGUI songNameText;

    void Start()
    {

        if (songNameText == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on the SongDisplayButton GameObject!");
            return;
        }

        // Find the AudioBackground script in the hierarchy
        AudioBackground audioBackground = FindObjectOfType<AudioBackground>();

        if (audioBackground != null)
        {
            // Subscribe to the event for song changes
            audioBackground.OnSongChanged += UpdateSongName;
        }
        else
        {
            Debug.LogError("AudioBackground script not found in the scene!");
        }
    }

    void UpdateSongName(string songName)
    {
        // Update the text with the current song name
        songNameText.text = "" + songName;
    }
}
