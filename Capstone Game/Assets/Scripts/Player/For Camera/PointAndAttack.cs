using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndAttack : MonoBehaviour
{
    public GameObject rangedWeapon;
    public GameObject meleeWeapon;
    public GameObject lemon;
    public float lemonSpeed;
    public float swordSpeed;
    public float timeBetweenAttacks;
    public float attackCooldown;

    public Transform attackPosR;
    public Transform attackPosL;
    public LayerMask whatIsEnemies;
    public float attackRangeR;
    public float attackRangeL;

    Vector3 target;
    Quaternion rotation1 = Quaternion.Euler(0, 0, 0);
    Quaternion rotation2 = Quaternion.Euler(0, 0, 0);
    private bool flag = false;

    void Update() {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        Vector3 difference = target - rangedWeapon.transform.position;                          //Rotates to follow mouse
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rangedWeapon.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        attackCooldown += Time.deltaTime;

        if (flag) {                                                                             //The most roundabout way to play an attack animation ever
            rotation1 = meleeWeapon.transform.rotation;                                         //Doing this because I need a constant running deltaTime

            meleeWeapon.transform.rotation = Quaternion.Slerp(rotation1, rotation2, Time.deltaTime * swordSpeed);

            if (meleeWeapon.transform.rotation == Quaternion.Euler(0, 0, -135) || meleeWeapon.transform.rotation == Quaternion.Euler(0, 0, 135))
            {
                meleeWeapon.transform.rotation = Quaternion.Euler(0, 0, 0);
                flag = false;
            }
            else { }
        }
        else { }


        if (Input.GetMouseButton(0) && attackCooldown >= timeBetweenAttacks) {          //Left click
            //Actual damage stuff
            MeleeAttack();
            
        }
        else if (Input.GetMouseButton(1) && attackCooldown >= timeBetweenAttacks) {     //Right click
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();

            RangedAttack(direction, rotationZ);
        }
        else { }
    }

    void RangedAttack(Vector2 direction, float rotationZ) {
        GameObject bullet = Instantiate(lemon) as GameObject;                           //Creates lemon
        bullet.transform.position = rangedWeapon.transform.position;                    //Starting at Player

        bullet.transform.rotation = Quaternion.Euler(0, 0, rotationZ);                  //Orients in correct direction
        bullet.GetComponent<Rigidbody2D>().velocity = direction * lemonSpeed;           //Fires lemon

        attackCooldown = 0;
    }

    void MeleeAttack() {                                                                //This could be made way easier with animation
        if (target.x < meleeWeapon.transform.position.x)
        {
            meleeWeapon.GetComponentInChildren<SpriteRenderer>().flipX = false;         //Damage enemies on the left
            rotation2 = Quaternion.Euler(0, 0, 135);

            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosL.position, attackRangeL, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyHealth>().takeDamage(2);
            }

            //Damaging Enemy Part Left
        }
        else
        {
            meleeWeapon.GetComponentInChildren<SpriteRenderer>().flipX = true;          //Damage enemies on the right
            rotation2 = Quaternion.Euler(0, 0, -135);
            
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosR.position, attackRangeR, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyHealth>().takeDamage(2);
            }
            //Damaging Enemy Part Right
        }
        flag = true;
        attackCooldown = 0;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosR.position, attackRangeR);
        Gizmos.DrawWireSphere(attackPosL.position, attackRangeL);
    }

}
