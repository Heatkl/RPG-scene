using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{

    Animator anim;
    public string stateAttack;
    bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isAttack && Input.GetMouseButton(0))
        {
            isAttack = true;
            anim.SetBool(stateAttack, isAttack);
        }
        else if (isAttack && !Input.GetMouseButton(0))
        {
            isAttack = false;
            anim.SetBool(stateAttack, isAttack);
        }
    }
}
