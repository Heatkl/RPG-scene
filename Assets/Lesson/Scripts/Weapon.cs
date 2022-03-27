using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float shootDelay = 0.1f;
    public float shootDistance = 1000f;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public Transform shootPoint;
    public LineRenderer lineRenderer;
    public Light pointLight;
    public GameObject shootEffect;

    private float shootDelayCurrent;
    private Material lineMaterial;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = 2;
        lineMaterial = lineRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ShootProcess();
        }

        var tempColor = lineMaterial.color;
        if (tempColor.a > 0)
        {
            tempColor.a -= 0.01f;
            lineMaterial.color = tempColor;
        }
        pointLight.intensity -= 1f;
        
    }

    private void ShootProcess()
    {
        if (shootDelayCurrent > 0)
        {
            shootDelayCurrent -= Time.deltaTime;
            return;
        }

        CrateRay();

        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);

        shootDelayCurrent = shootDelay;
    }

    private void CrateRay()
    {
        RaycastHit ray;
        if(Physics.Raycast(shootPoint.position, shootPoint.TransformDirection(Vector3.forward), out ray, shootDistance))
        {
            DrawLine(shootPoint.position, ray.point);
            if (ray.collider.GetComponent<ParticleStop>())
            {
                ray.collider.GetComponent<ParticleStop>().Pause();
            }
            if (ray.collider.GetComponent<ChomperDamage>())
            {
                ray.collider.GetComponent<ChomperDamage>().DecreaseHealth();
            }
        }
        else
        {
            DrawLine(shootPoint.position, shootPoint.TransformDirection(Vector3.forward) * shootDistance);
        }
    }

    private void DrawLine(Vector3 positionFrom, Vector3 positionTo)
    {
        var tempColor = lineMaterial.color;
        tempColor.a = 1f;
        lineMaterial.color = tempColor;

        pointLight.intensity = 5f;

        lineRenderer.SetPosition(0, positionFrom);
        lineRenderer.SetPosition(1, positionTo);

        var effect = Instantiate(shootEffect, positionTo, Quaternion.identity);
        effect.SetActive(true);
        
    }
}
