using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperLogic : MonoBehaviour
{
    public Animator anim;
    public string walkParameter;
    public string attackParameter;
    private Vector3 oldPosition;
    public Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Vector3.Distance(transform.position, oldPosition);
        speed = Mathf.Abs(speed);
        anim.SetFloat(walkParameter, speed);
        anim.SetBool(attackParameter, speed < 0.01f && playerHealth.currentHealth > 0);
        oldPosition = transform.position;
    }
}
