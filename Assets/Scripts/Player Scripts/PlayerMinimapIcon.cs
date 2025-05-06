using UnityEngine;

public class PlayerMinimapIcon : MonoBehaviour
{
    public Transform playerCamera; 

    void Update()
    {
        if (playerCamera != null)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, playerCamera.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}