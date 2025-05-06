using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MinigameEnd : MonoBehaviour
{
    public GameObject[] wires;

    // keeps track of keycards collected, e.g. [0] = keycard0, [1] = keycard1, etc. If keycard0 is collected, isCollected[0] = true. Length is the same as wires[] length.\
    public static bool[] isCollected = {false, false, false}; 
    public static int minigamesLeft = 3; // number of minigames left to complete
    
    void Start()
    {
        //unlock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    // Update is called once per frame
    void Update() {
        if(AllWiresConnected()) {
            StartCoroutine(WaitForSceneLoad());
        }
    }

    bool AllWiresConnected() {
        foreach(GameObject wire in wires) {
            if(!wire.GetComponent<PoweredWireStats>().connected) {
                return false;
            }
        }
        return true;
    }

    private IEnumerator WaitForSceneLoad() {
        yield return new WaitForSeconds(1f);
        minigamesLeft--;
        SceneManager.LoadScene("Level1");
    }
}
