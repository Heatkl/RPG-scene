using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStop : MonoBehaviour
{
    public ParticleSystem partSystem;
    public Light pointLight;
    public float defaultTimer;
    public Behaviour[] components;


    private bool pause;
    private float currentTimer;


    private void SetActiveComponents(bool isActive)
    {
        foreach (var component in components)
            component.enabled = isActive;
    }

    public void Pause()
    {
        partSystem.Stop(true);
        currentTimer = defaultTimer;
        pause = true;
        SetActiveComponents(!pause);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause) 
            return;

        if (currentTimer <= 0)
            Activate();

        currentTimer -= Time.deltaTime;

        if (pointLight.intensity > 0)
            pointLight.intensity -= 0.1f;
    }

    private void Activate()
    {
        partSystem.Play(true);
        pause = false;
        pointLight.intensity = 1f;
        SetActiveComponents(!pause);
    }
}
