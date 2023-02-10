using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;

    void Start() {
        offset = transform.position - player.transform.position;
    }
    void Update() {
        Vector3 position = transform.position;
        position.x = (player.transform.position + offset).x;
        transform.position = position;
    }
}
