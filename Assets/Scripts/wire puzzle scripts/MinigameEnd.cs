using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MinigameEnd : MonoBehaviour
{
    public GameObject[] wires;
    public static int minigamesLeft = 3; 
    
    void Start()
    {
        
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
