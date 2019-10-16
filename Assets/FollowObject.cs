using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform ObjectToFollow;

    [Range(0.0f, 1.0f)]
    public float SmoothRate;

    void Start()
    {
        Vector3 currentPosition = GetComponent<Transform>().position;
        GetComponent<Transform>().position = new Vector3(ObjectToFollow.position.x, currentPosition.y, currentPosition.z);
    }

    void FixedUpdate()
    {
        Vector3 currentPosition = GetComponent<Transform>().position;
        Vector3 desiredPosition = new Vector3(ObjectToFollow.position.x, currentPosition.y, currentPosition.z);
        GetComponent<Transform>().position = Vector3.Lerp(currentPosition, desiredPosition, SmoothRate);
    }
}
