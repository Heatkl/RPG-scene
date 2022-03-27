using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperDamage : MonoBehaviour
{
    public float damage;
    public Health health;
    public void DecreaseHealth() => health.DecreaseHealth(damage);

}
