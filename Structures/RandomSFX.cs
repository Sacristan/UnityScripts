using UnityEngine;

[System.Serializable]
public class RandomSFX
{
    [SerializeField] private AudioClip[] sfxes = new AudioClip[0];

    public bool HasAnythingToPlay => sfxes == null || sfxes.Length > 0;

    public AudioClip GetRandomAudioClip()
    {
        if (sfxes == null) return null;

        switch (sfxes.Length)
        {
            case 0:
                return null;
            case 1:
                return sfxes[0];
            default:
                int index = Random.Range(0, sfxes.Length);
                return sfxes[index];
        }
    }
}