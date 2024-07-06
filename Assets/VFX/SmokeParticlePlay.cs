using UnityEngine;

public class SmokeParticlePlay : MonoBehaviour
{
    public ParticleSystem ptcSystem;
    public GameObject smokePusher;
    public bool playPeriodically = false;
    public float playInterval = 2f; // Default interval of 2 seconds
    public float particleDuration = 3f; // Default particle duration of 3 seconds

    void Start()
    {

        
        // Ensure particle system is assigned
        if (ptcSystem == null)
        {
            ptcSystem = GetComponent<ParticleSystem>();
            if (ptcSystem == null)
            {
                Debug.LogError("Particle system not assigned or found on the object.");
                enabled = false; // Disable script if particle system is not found
                return;
            }
        }

        var mainModule = ptcSystem.main;
        mainModule.loop = true;

        if (!playPeriodically)
        {
            Invoke("StopParticleSystem", playInterval);
            Invoke("SmokeTriggerOff", playInterval);
        }
    }

    void PlayParticleSystem()
    {

        var mainModule = ptcSystem.main;
        mainModule.loop = true;
        ptcSystem.Play();
        Invoke("StopParticleSystem", playInterval); // Invoke stopping the particle system after specified duration
        Invoke("SmokeTriggerOff", playInterval);
    }

    void SmokeTriggerOn()
    {
        smokePusher.SetActive(true);
    }

    void SmokeTriggerOff()
    {
        smokePusher.SetActive(false);
    }

    void StopParticleSystem()
    {
        var mainModule = ptcSystem.main;
        mainModule.loop = false;
        Invoke("PlayParticleSystem", particleDuration);
        Invoke("SmokeTriggerOn", playInterval+0.1f);
    }
}