using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float speed;

    public float rangeX;
    public float rangeZ;

    float moveX;
    float moveZ;

    Vector3 initialPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        initialPosition = transform.position;
        moveX = rangeX / (rangeX + rangeZ);
        moveZ = rangeZ / (rangeZ + rangeX);
    }

    // Update is called once per frame
    void Update(){}

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveX, 0, moveZ);
        Vector3 newPosition = transform.position + speed * move * Time.deltaTime;

        transform.position = newPosition;

        if (newPosition.x - initialPosition.x >= rangeX || newPosition.x - initialPosition.x <= (-1) * rangeX) {
            moveX = -moveX;
        }

        if (newPosition.z - initialPosition.z >= rangeZ || newPosition.z - initialPosition.z <= (-1) * rangeZ) { 
            moveZ = -moveZ;
        }

        
    }
}
