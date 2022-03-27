using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Image healthImage;
    public float currentHealth;
    public Behaviour[] components;
    // Start is called before the first frame update
    public Animator anim;

    public string parameterName;
    public void DecreaseHealth(float damage)
    {
        if (currentHealth <= 0)
            return;

        currentHealth -= damage;
        UpdateUI();
        if (currentHealth <= 0)
            DeathProcess();
    }


    private void DeathProcess()
    {
        anim.SetBool(parameterName, true);

        foreach(var component in components)
        {
            component.enabled = false;
        }

        var componentCollider = GetComponent<CapsuleCollider>();
        if (componentCollider == null)
            return;

        componentCollider.height = 0f;
        componentCollider.radius = 0.05f;
    }
    private void UpdateUI() => healthImage.fillAmount = currentHealth / 100f;
    

    void Start() => UpdateUI();

    // Update is called once per frame
    void Update()
    {
        
    }
}
