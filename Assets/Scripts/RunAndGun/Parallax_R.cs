using UnityEngine;

public class ParallaxR : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    [Header("Configuración de Cámara")]
    public Transform cameraTransform; 
    public float parallaxMultiplier = 0.5f; 

    private Vector3 lastCameraPosition;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        lastCameraPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        float offsetAmount = deltaMovement.x * parallaxMultiplier;

        meshRenderer.material.mainTextureOffset += new Vector2(offsetAmount, 0);

        // NUEVO: Hacemos que el objeto físico siga a la cámara en el eje X.
        // Mantenemos la posición Y y Z originales del suelo.
        transform.position = new Vector3(cameraTransform.position.x, transform.position.y, transform.position.z);
        lastCameraPosition = cameraTransform.position;
    }
}