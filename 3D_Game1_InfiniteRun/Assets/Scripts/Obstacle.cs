using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public static event Action OnPlayerPassedTheObstacle;
    bool playerPassed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (!playerPassed && transform.position.z <= -0.5f) {
            playerPassed = true;
            OnPlayerPassedTheObstacle?.Invoke();
            speed += 0.01f;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
