using UnityEngine;

public class AgentCubeDamage : MonoBehaviour
{
    public float decreaseHealth;

    private void OnTriggerStay(Collider other)
    {

        if (!enabled)
            return;


        var health = other.GetComponent<Health>();
        if (health == null)
            return;

        health.DecreaseHealth(decreaseHealth);

    }

}