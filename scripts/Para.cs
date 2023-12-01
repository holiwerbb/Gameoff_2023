using UnityEngine;
using FMODUnity;

public class Para : MonoBehaviour
{
    void Start()
    {
        StopAllEvents();
    }

    void StopAllEvents()
    {
        FMOD.Studio.Bus masterBus;
        FMODUnity.RuntimeManager.StudioSystem.getBus("bus:/", out masterBus);
        masterBus.stopAllEvents(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
