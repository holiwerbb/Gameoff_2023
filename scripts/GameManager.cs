using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [FMODUnity.EventRef]
    public string fmodEvent;  // Asigna el evento de FMOD desde el inspector.

    FMOD.Studio.EventInstance eventInstance;
    FMOD.Studio.TIMELINE_BEAT_PROPERTIES beatProperties;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        eventInstance.start();
    }

    public void PauseMusic()
    {
        FMOD.Studio.PLAYBACK_STATE playbackState;
        eventInstance.getPlaybackState(out playbackState);
        if (playbackState == FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            eventInstance.getTimelinePosition(out beatProperties.position);
            eventInstance.setPaused(true);
        }
    }

    public void ResumeMusic()
    {
        eventInstance.setTimelinePosition(beatProperties.position);
        eventInstance.setPaused(false);
    }
}
