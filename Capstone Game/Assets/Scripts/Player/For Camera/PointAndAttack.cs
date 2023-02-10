using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndAttack : MonoBehaviour
{
    public GameObject player;
    public GameObject lemon;
    public float lemonSpeed;
    public GameObject sword;
    public float swordSpeed;
    public float timeBetweenAttacks;
    public float attackCooldown;
    Vector3 target;

    void Update() {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        Vector3 difference = target - player.transform.position;                        //Rotates to follow mouse
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        attackCooldown += Time.deltaTime;

        if (Input.GetMouseButton(0) && attackCooldown >= timeBetweenAttacks) {          //Left click
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();

            MeleeAttack(direction, rotationZ);
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
        bullet.transform.position = player.transform.position;                          //Starting at Player

        bullet.transform.rotation = Quaternion.Euler(0, 0, rotationZ);                  //Orients in correct direction
        bullet.GetComponent<Rigidbody2D>().velocity = direction * lemonSpeed;           //Fires lemon

        attackCooldown = 0;
    }

    void MeleeAttack(Vector2 direction, float rotationZ) {
        
        attackCooldown = 0;
    }
}
