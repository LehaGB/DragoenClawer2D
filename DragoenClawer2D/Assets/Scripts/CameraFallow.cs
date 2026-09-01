using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float timeOffset = 0.2f;

    private Vector3 velocity;
    //void Start()
    //{
    //    if (target == null) return;
    //    offset = transform.position - target.transform.position;
    //}

    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, timeOffset);
    }
}
