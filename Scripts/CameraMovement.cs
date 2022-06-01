using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;

    private Vector3 offset;
    private float smoothTime;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 1.5f, -10f);
        smoothTime = 0.25f;
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x, targetPosition.y, targetPosition.z), ref velocity, smoothTime);
    }
}
