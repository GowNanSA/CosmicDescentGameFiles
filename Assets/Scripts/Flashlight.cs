using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] Transform playerCamera; 

    void Update()
    {
        if (playerCamera != null)
        {
            transform.rotation = Quaternion.Euler(playerCamera.eulerAngles.x + 35, playerCamera.eulerAngles.y, playerCamera.eulerAngles.z);
        }
    }
}
