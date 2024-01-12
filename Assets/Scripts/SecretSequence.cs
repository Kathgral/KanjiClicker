using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretSequence : MonoBehaviour
{
    private List<int> clickedSequence = new List<int>();
    private List<int> secretCode = new List<int> { 1,2,2,3,3,3,4,4,4,4 };
    private bool AllowSecretReward;

    void Awake()
    {
        AllowSecretReward = true;
        for (int i=0; i<secretCode.Count; i++){
            clickedSequence.Add(0);
        }
    }

    public void Button1(){
        clickedSequence.Add(1);
        clickedSequence.RemoveAt(0);
        ButtonClick();
    }

    public void Button2(){
        clickedSequence.Add(2);
        clickedSequence.RemoveAt(0);
        ButtonClick();
    }

    public void Button3(){
        clickedSequence.Add(3);
        clickedSequence.RemoveAt(0);
        ButtonClick();
    }

    public void Button4(){
        clickedSequence.Add(4);
        clickedSequence.RemoveAt(0);
        ButtonClick();
    }

    void ButtonClick()
    {
        // Check sequence
        bool correctSequence = true;
        for (int i = 0; i < secretCode.Count; i++){
            if (clickedSequence[i] != secretCode[i]){
                correctSequence = false;
                break;
            }
        }
        if (correctSequence){
            UnlockReward();
        }
        print("Sequence: " + string.Join(" - ", clickedSequence));
    }

    void UnlockReward()
    {
        Debug.Log("Secret code unlocked!");
        if (AllowSecretReward){  
            int bonusSecretReward = DataManager.playerData.TotalNumberOfPointsObtained;
            DataManager.playerData.TotalPoints += bonusSecretReward;
            DataManager.playerData.TotalNumberOfPointsObtained += bonusSecretReward;
            AllowSecretReward = false;
        }
    }
}
