using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class Enmey3 : MonoBehaviour
{
    public GameObject player;
    public float teshholdDistance;
    public float limit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        limit = Mathf.Abs(limit);
        teshholdDistance = Mathf.Abs(teshholdDistance);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if ( distance <= teshholdDistance) {
            if (player.transform.position.x > transform.position.x)
            {
                if (transform.position.x < limit)
                {
                    transform.position = transform.position + new Vector3(distance / 2, 0, 0) * Time.deltaTime;
                }
            }
            else {
                if (transform.position.x < limit)
                {
                    transform.position = transform.position - new Vector3(distance / 2, 0, 0) * Time.deltaTime;
                }
            }
        }
    }
}
