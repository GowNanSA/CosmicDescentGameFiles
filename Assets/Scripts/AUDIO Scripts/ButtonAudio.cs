using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    [SerializeField] private AudioClip buttonHighlight;
    [SerializeField] private AudioClip buttonSelect;
    [SerializeField] private AudioClip buttonStartGame;

    public static AudioSource instance;

    public void HighlightedButtonSound() {
        SoundManager.instance.PlaySound(buttonHighlight);
    }

    public void SelectedButtonSound() {
        SoundManager.instance.PlaySound(buttonSelect);
    }

    public void StartGameButtonSound() {
        SoundManager.instance.PlaySound(buttonStartGame);
    }

    public static void stopMusic() {
        Destroy(instance.gameObject);
    }

}
