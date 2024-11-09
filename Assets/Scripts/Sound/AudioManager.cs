using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    [Header("Game Sound Config")]
    public AudioSource audioSourceBGM;
    public AudioSource audioSourceSFX;

    [SerializeField] private AudioType[] audioList;

    [Range(0, 1)] public float bgmVolume = 1f;
    [Range(0, 1)] public float sfxVolume = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetGameVolume(bgmVolume, sfxVolume);
        PlayBGM(global::AudioTypeList.BackGroundMusic);
    }

    public void SetGameVolume(float bgmVolume, float sfxVolume)
    {
        audioSourceBGM.volume = bgmVolume;
        audioSourceSFX.volume = sfxVolume;
    }

    public AudioClip GetAudioClip(AudioTypeList audio)
    {
        AudioType audioItem = Array.Find(audioList, item => item.audioType == audio);

        if (audioItem != null)
            return audioItem.audioClip;

        return null;
    }

    public void PlayBGM(AudioTypeList audio)
    {
        AudioClip clip = GetAudioClip(audio);

        if (clip == null) return;

        audioSourceBGM.clip = clip;
        audioSourceBGM.loop = true;
        audioSourceBGM.Play();
    }

    public void PlaySFX(AudioTypeList audio)
    {
        AudioClip clip = GetAudioClip(audio);

        if (clip == null) return;

        audioSourceSFX.PlayOneShot(clip);
    }
}

[Serializable]
public class AudioType
{
    public AudioTypeList audioType;
    public AudioClip audioClip;
}

public enum AudioTypeList
{
    BackGroundMusic,
    HealthPickupSound,
    ScorePickupSound,
    EnemyCollisionSound,
    GameOverRestartButtonSound,
    GameOverMenuButtonSound,
    EnemyHit,
    BulletFire,
    EnemyDeath,
    DoubleScorePowerup,
    HealthImmunityPowerup
}