using UnityEngine;

namespace Library.Tools
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogWarning("There can only be one soundmanager in the scene!");
                Application.Quit();
            }

            Instance = this;
        }

        public AudioClip[] clips;
        public AudioSource source;

        public void PlaySound(string sound)
        {
            switch (sound)
            {
                case "MG":
                    source.clip = clips[0];
                    source.Play();
                    return;
                case "Flame":
                    source.clip = clips[1];
                    source.Play();
                    return;
                case "Flak":
                    source.clip = clips[2];
                    source.Play();
                    return;
                case "Explosion":
                    source.clip = clips[3];
                    source.Play();
                    return;
                case "Enabled":
                    source.clip = clips[4];
                    source.Play();
                    return;
                case "Disabled":
                    source.clip = clips[5];
                    source.Play();
                    return;
                case "Hit":
                    source.clip = clips[6];
                    source.Play();
                    return;
                case "Stop":
                    source.Stop();
                    return;
                default:
                    return;
            }
        }

    }
}
