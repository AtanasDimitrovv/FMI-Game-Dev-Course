using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;

    private Vector3 offset;

    [SerializeField]
    private float smoothSpeed;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        offset = transform.position - player.transform.position;
        smoothSpeed =1f;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
