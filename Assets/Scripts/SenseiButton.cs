using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Give bonus points if you click quickly in the sensei icon
public class SenseiButton : MonoBehaviour
{
    public GameObject NewKanjiText;
    public TextMeshProUGUI SenseiText;        
    public static float lastUpdateTime;
    private string currentText;
    List<string> texts = new List<string> 
        {
            "You've got this!",
            "Keep going!",
            "Stay focused!",
            "Believe in yourself!",
            "Dream big!",
            "Make it happen!",
            "Stay positive!",
            "Embrace the journey!",
            "Chase your dreams!",
            "You are unstoppable!",
            "Turn obstacles into opportunities!",
            "Strive for progress, not perfection!",
            "Seize the day!",
            "Be fearless!",
            "You can do it!",
            "You can overcome anything!",
            "Don't give up!",
            "You're stronger than you think!",
            "Keep pushing forward!",
            "Stay motivated!",
        };

    public void TextUpdater()
    {
        lastUpdateTime = Time.time;
        // Choose a random text from the list (you can modify this logic as needed)
        int randomIndex = Random.Range(0, texts.Count);
        SenseiText.text = texts[randomIndex];
    }


    private int multBonusPoints = 5;
    private Queue<float> clickTimes = new Queue<float>();
    private int queueLength = 0;
    private float interval = 5f; // Time interval for counting clicks
    private bool isBonusOnCooldown = false;
    private float cooldownDuration = 15f;
    private int NbOfClicksRequired = 20;

    public void AddClicks()
    {
        // Check if the bonus is not on cooldown
        if (!isBonusOnCooldown)
        {
            // Store the current timestamp
            float currentTime = Time.time;

            // Enqueue the current timestamp
            clickTimes.Enqueue(currentTime);
            queueLength += 1;

            // Remove clicks that occurred more than 10 seconds ago
            while (queueLength > 0 && currentTime - clickTimes.Peek() > interval)
            {
                clickTimes.Dequeue();
                queueLength -= 1;
            }

            // Check if the click count exceeds the threshold
            if (clickTimes.Count >= NbOfClicksRequired)
            {
                // Award bonus points
                int awardedPoints = DataManager.playerData.PointsPerClick * multBonusPoints * clickTimes.Count;
                DataManager.playerData.TotalPoints += awardedPoints;
                DataManager.playerData.TotalNumberOfPointsObtained += awardedPoints;
                // Start the cooldown
                StartCoroutine(NbBonusPointsMessage(awardedPoints));
                StartCoroutine(BonusCooldown());
                StartCoroutine(CooldownSlider());
            }
        }
    }

    public GameObject BonusTextObject;
    public TextMeshProUGUI BonusText;
    IEnumerator NbBonusPointsMessage(float awardedPoints)
    {
        BonusTextObject.SetActive(true);
        BonusText.text = "+" + awardedPoints;
        yield return new WaitForSeconds(3f);
        BonusTextObject.SetActive(false);
    }

    IEnumerator BonusCooldown()
    {
        // Set the bonus on cooldown
        isBonusOnCooldown = true;

        // Wait for the cooldown duration
        yield return new WaitForSeconds(cooldownDuration);

        // Reset the bonus cooldown
        isBonusOnCooldown = false;

        // Clear the click times to allow counting for the next bonus
        clickTimes.Clear();
        queueLength = 0;
    }


    public Slider cooldownSlider;
    public GameObject SliderObject;
    IEnumerator CooldownSlider()
    {
        SliderObject.SetActive(true);
        cooldownSlider.value = 0f;
        float currentTime = cooldownDuration;

        while (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            float normalizedTime = currentTime / cooldownDuration;

            // Update the slider value
            cooldownSlider.value = 1-normalizedTime;

            yield return null;
        }
        cooldownSlider.value = 1f;  // Reset the slider to fully filled
        SliderObject.SetActive(false);
    }

}
