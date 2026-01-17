using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    Vector3 difference;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        difference = target.position - transform.position;
    }

    // Update is called once per frame
    void Update(){}

    private void FixedUpdate()
    {
        transform.position = target.position - difference;
    }
}
