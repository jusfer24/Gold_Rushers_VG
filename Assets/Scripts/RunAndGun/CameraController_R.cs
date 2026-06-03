using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class CameraController_R : MonoBehaviour {

    public Transform target;

    private float fixedY;
    private float fixedZ;
    private float maxX;
    private float offsetX;

    private void Awake()
    {
        fixedY = transform.position.y;
        fixedZ = transform.position.z;

        if (target != null)
        {
            offsetX = transform.position.x - target.position.x;
        }

        maxX = transform.position.x;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        float targetX = target.position.x + offsetX;

        if (targetX > maxX)
        {
            maxX = targetX;
        }

        transform.position = new Vector3(maxX, fixedY, fixedZ);
    }
}
