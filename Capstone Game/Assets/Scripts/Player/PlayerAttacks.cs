using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] float attackCooldown;

    // Update is called once per frame
    void Update()
{
        if (Input.GetMouseButton(0))              //Left click
        {
            MeleeAttack();
        }
        else if (Input.GetMouseButton(1))         //Right click
        {
            RangedAttack();
        }
    }

    void RangedAttack()
    {

    }

    void MeleeAttack()
    {

    }
}
