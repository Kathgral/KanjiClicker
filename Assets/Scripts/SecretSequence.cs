using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretSequence : MonoBehaviour
{
    private List<int> clickedSequence = new List<int>();
    private List<int> secretCode = new List<int> { 1,2,2,1,3,3,3,1 };
    private bool AllowSecretReward;

    void Awake()
    {
        AllowSecretReward = true;
    }

    public void Button1(){
        clickedSequence.Add(1);
        ButtonClick();
    }

    public void Button2(){
        clickedSequence.Add(2);
        ButtonClick();
    }

    public void Button3(){
        clickedSequence.Add(3);
        ButtonClick();
    }

    void ButtonClick()
    {
        // Check if the last elements of the clicked sequence match the secret code
        if (clickedSequence.Count <= secretCode.Count){
            int index = clickedSequence.Count - 1;
            if (clickedSequence[index] != secretCode[index]){
                    ResetSequence();
                }
            if (clickedSequence.Count == secretCode.Count){
                UnlockReward();
            }
        }
        else {
            ResetSequence();
        }
        print("Sequence: " + string.Join(" - ", clickedSequence));
    }

    void UnlockReward()
    {
        Debug.Log("Secret code unlocked!");
        if (AllowSecretReward){  
            float bonusSecretReward = DataManager.playerData.TotalNumberOfPointsObtained;
            DataManager.playerData.TotalPoints += bonusSecretReward;
            DataManager.playerData.TotalNumberOfPointsObtained += bonusSecretReward;
            ResetSequence();
            AllowSecretReward = false;
        }
    }

    void ResetSequence()
    {
        clickedSequence.Clear();
    }
}
