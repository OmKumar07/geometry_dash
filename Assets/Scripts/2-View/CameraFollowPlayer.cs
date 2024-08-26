using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float verticalThreshold = 5f;
    private float initialCameraY;

    public float verticalSmoothTime = 0.3f;
    private float velocityY = 0f;
    public PlayerModel playerModel;

    void Start()
    {
        initialCameraY = transform.position.y;
        playerModel = new PlayerModel(new Vector3(0, 0, 0));
    }

    void LateUpdate()
    {
        if (playerModel.IsAlive)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = playerTransform.position.x + offset.x;
            float targetY = initialCameraY;
            if (playerTransform.position.y > initialCameraY + verticalThreshold)
            {
                targetY = playerTransform.position.y + offset.y;
            }
            else if (playerTransform.position.y < initialCameraY - verticalThreshold)
            {
                targetY = playerTransform.position.y + offset.y;
            }
            newPosition.y = Mathf.SmoothDamp(transform.position.y, targetY, ref velocityY, verticalSmoothTime);
            transform.position = newPosition;
        }
    }
}
