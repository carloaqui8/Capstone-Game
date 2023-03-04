using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public bool flag1 = true;
    public bool flag2 = false;

    void Start() {
        offset = transform.position - player.transform.position;
    }
    void Update() {
        if (flag1) {
            lockX();
        }
        else { }

        if (flag2)
        {
            lockY();
        }
        else { }
    }

    void lockX() {
        Vector3 position = transform.position;
        position.x = (player.transform.position + offset).x;
        transform.position = position;
    }

    void lockY()
    {
        Vector3 position = transform.position;
        position.y = (player.transform.position + offset).y;
        transform.position = position;
    }
}
