using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for the event trigger interfaces

public class ButtonBook : MonoBehaviour, IPointerDownHandler, IPointerUpHandler // Implement these interfaces
{
    public AudioSource soundButton;
    public Image bookImage; // Reference to the book's Image component
    public float scaleIncrease = 1.1f; // Multiplier by which the book's scale will increase
    private Vector3 originalScale; // To store the original scale

    void Start() {
        if (bookImage != null) {
            originalScale = bookImage.rectTransform.localScale; // Store the original scale
        } else {
            Debug.LogError("Book image not assigned in ButtonBook script.");
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (bookImage != null) {
            bookImage.rectTransform.localScale = originalScale * scaleIncrease; // Increase the size
        }
        // You can also add your click logic here
        GameManager.TotalClicks += GameManager.TotalClicksPerTap;
        if (soundButton != null) {
            soundButton.Play();
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (bookImage != null) {
            bookImage.rectTransform.localScale = originalScale; // Reset the size to original
        }
    }
}
