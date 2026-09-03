using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float timeOffset = 0.2f;

    private Vector3 velocity;

    private void Awake()
    {
        transform.position = target.position + offset;
    }

    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, timeOffset);
    }
}
