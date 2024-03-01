using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float followThreshold = 1f;
    public float idleTimeThreshold = 3f;

    private bool isFollowing = false;
    private Vector3 lastPosition;
    private float idleTimer = 0f;

    void LateUpdate()
    {
        if (target != null && isFollowing)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            // Reset the idle timer if the player has moved
            if ((target.position - lastPosition).sqrMagnitude > 0.001f)
            {
                idleTimer = 0f;
            }

            // Update the player's last position
            lastPosition = target.position;

            // Increment the idle timer
            idleTimer += Time.deltaTime;

            // Stop following if the player has been idle for too long
            if (idleTimer >= idleTimeThreshold)
            {
                isFollowing = false;
            }
        }
    }

    public void StartFollowing()
    {
        isFollowing = true;
        idleTimer = 0f; // Reset the idle timer when starting to follow
    }

    void Update()
    {
        if (!isFollowing && target != null)
        {
            if (Mathf.Abs(target.position.x - transform.position.x) > followThreshold)
            {
                StartFollowing();
            }
        }
    }
}
