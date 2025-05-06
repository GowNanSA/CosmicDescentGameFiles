using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    public AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();

        // Keep this object even when we go to a new scene
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != null && instance != this) { // Destroy duplicate gameobjects
            Destroy(gameObject);
        }
    }

    void Update() {
        if (SceneManager.GetActiveScene().name == "Level1") {
            Destroy(gameObject); // Destroy this SoundManager instance
        }
    }

    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}