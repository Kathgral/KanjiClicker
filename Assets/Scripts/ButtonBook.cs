using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for the event trigger interfaces
using System.Collections; // For coroutines
using TMPro;

public class ButtonBook : MonoBehaviour, IPointerDownHandler, IPointerUpHandler // Implement these interfaces
{
    public AudioClip buttonSound;
    private AudioSource audioSource;
    public Image bookImage; // Reference to the book's Image component
    public float scaleIncrease = 1.1f; // Multiplier by which the book's scale will increase
    private Vector3 originalScale; // To store the original scale
    public TextMeshProUGUI popUpTextPrefab;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = buttonSound;
        if (bookImage != null) {
            originalScale = bookImage.rectTransform.localScale; // Store the original scale
        } else {
            Debug.LogError("Book image not assigned in ButtonBook script.");
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (bookImage != null) {
            bookImage.rectTransform.localScale = originalScale * scaleIncrease; // Increase the size
            CreateAndAnimateText(); // Create and animate the text
        }
        // Click logic
        DataManager.playerData.TotalPoints += DataManager.playerData.PointsPerClick;
        DataManager.playerData.TotalNumberOfClicks += 1;
        audioSource.Play();
    }

    private void CreateAndAnimateText() {
        // Instantiate the TextMeshProUGUI prefab at the position of the button, with no rotation, and as a child of the current transform.
        TextMeshProUGUI popUpTextInstance = Instantiate(popUpTextPrefab, transform.position, Quaternion.identity, transform);
        popUpTextInstance.text = popUpTextPrefab.text; // Set the text to the prefab's text.
        StartCoroutine(FadeAndMoveUpText(popUpTextInstance)); // Start the coroutine to fade and move the text.
    }

    private IEnumerator FadeAndMoveUpText(TextMeshProUGUI textInstance) {
        float duration = 2.0f; // Duration in seconds for the fade and movement.
        float elapsedTime = 0;
        Vector3 startPosition = textInstance.transform.position;
        float randomXDirection = Random.Range(-1f, 1f); // Get a random direction in X.

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            // Calculate new alpha based on elapsed time.
            float newAlpha = Mathf.Clamp01(1 - (elapsedTime / duration));
            textInstance.color = new Color(textInstance.color.r, textInstance.color.g, textInstance.color.b, newAlpha);

            // Move the text upwards and slightly randomly to the sides.
            float newY = Mathf.Lerp(startPosition.y, Screen.height, elapsedTime / duration);
            float newX = startPosition.x + (randomXDirection * elapsedTime * 50); // Randomize the x to create a flying effect.
            textInstance.transform.position = new Vector3(newX, newY, startPosition.z);

            yield return null;
        }

        Destroy(textInstance.gameObject); // Destroy the text object after the animation.
    }



    public void OnPointerUp(PointerEventData eventData) {
        if (bookImage != null) {
            bookImage.rectTransform.localScale = originalScale; // Reset the size to original
        }
    }
}

