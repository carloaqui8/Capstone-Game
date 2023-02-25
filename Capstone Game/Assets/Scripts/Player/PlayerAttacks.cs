using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] float timeBetweenAttacks;
    float attackCooldown = 9;


    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButton(0)) {            //Left click
            MeleeAttack();
        }
        else if (Input.GetMouseButton(1)) {       //Right click
            RangedAttack();
        }
        else {}
    }

    void RangedAttack() {
        attackCooldown = 0;
        attackCooldown += Time.deltaTime;
    }

    void MeleeAttack() {
        attackCooldown = 0;
        attackCooldown += Time.deltaTime;
    }
}
