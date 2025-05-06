using UnityEngine;

public class KeycardCheck : MonoBehaviour
{
    public GameObject[] keycards;

    void Start() {

    }

    void Update() {
        //check if keycards are collected and hide the object if the id matches the index of isCollected
        for (int i = 0; i < keycards.Length; i++) {
            if (MinigameEnd.isCollected[i]) {
                keycards[i].SetActive(false);
            }
        }
    }
}