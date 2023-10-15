using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    [SerializeField] GameObject followedObject;
    private Vector3 offset;

    // Update is called once per frame
    void Start(){
        offset = followedObject.transform.position - transform.position;
    }
    void Update()
    {
        transform.position = followedObject.transform.position - offset;
    }
}
