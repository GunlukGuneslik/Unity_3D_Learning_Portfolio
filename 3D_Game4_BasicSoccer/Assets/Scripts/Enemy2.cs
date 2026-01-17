using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public float angularSpeed;
    public float radius;
    public bool centerAtRight;

    Vector3 center;
    float angle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        radius = Mathf.Abs(radius);
        if (centerAtRight)
        {
            center = transform.position + new Vector3(radius, 0, 0);
        }
        else { 
            center = transform.position - new Vector3(radius, 0, 0);
        }
    }

    // Update is called once per frame
    void Update(){}

    private void FixedUpdate()
    {
        angle = angle + angularSpeed * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        transform.position = center + new Vector3(x, 0, z);
    }
}
