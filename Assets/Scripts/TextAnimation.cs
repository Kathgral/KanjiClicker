using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextAnimation : MonoBehaviour
{
    public TextMeshProUGUI textElement;
    private float animationDuration = 1f;

    void Start()
    {
        StartCoroutine(PeriodicTextAnimation());
    }

    IEnumerator PeriodicTextAnimation()
    {
        while (true)
        {
            // Fade out
            float elapsedTime = 0f;

            // Reset text color and size
            textElement.transform.localScale = Vector3.one;

            // Pause for a moment before the next animation
            yield return new WaitForSeconds(0.8f);

            // Shrink in size
            elapsedTime = 0f;
            Vector3 initialScale = textElement.transform.localScale;
            Vector3 targetScale = Vector3.zero;

            while (elapsedTime < animationDuration)
            {
                textElement.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / animationDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
