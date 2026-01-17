using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float force;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI infoText;
    public AudioClip BallHitSound;
    public AudioClip GoalSound;

    bool gameOver;
    float xInput;
    float yInput;

    Rigidbody rb;
    AudioSource Audio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Audio = GetComponent<AudioSource>();
        force = Mathf.Abs(force);
        winText.enabled = false;
        infoText.enabled = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (!gameOver && transform.position.y <-5f) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (gameOver && Input.GetKey(KeyCode.Space)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void FixedUpdate()
    {
        if (!gameOver) {
            rb.AddForce(xInput * speed, 0, yInput * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Vector3 forceVector = (-1) * rb.linearVelocity.normalized * force;
            rb.AddForce(forceVector, ForceMode.Impulse);
            Audio.PlayOneShot(BallHitSound);
        } else if (collision.gameObject.tag == "GoalDedector") { 
            winText.enabled = true;
            infoText.enabled = true;
            rb.linearVelocity = new Vector3(0,0,0);
            gameOver = true;
            Audio.PlayOneShot(GoalSound);
        }
    }
}
