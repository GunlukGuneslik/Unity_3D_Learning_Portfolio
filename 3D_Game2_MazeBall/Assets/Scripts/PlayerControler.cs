using TMPro;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMover : MonoBehaviour
{
    public int winScore;
    private int score;
    public TextMeshProUGUI WinText;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI scoreText;
    public float speed;
    Rigidbody rb;
    float x;
    float y;
    private bool pause;

    // for object's own variables
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        WinText.enabled = false;
        infoText.enabled = false;
        scoreText.text = "Score: " + score;
    }

    // for other things realted with other objects
    void Start(){
        score = 0;
        pause = false;
    }

    // Update is called once per frame
    void Update(){
        if (transform.position.y < -5f) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (pause && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //For smooth movements
    private void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        //transform.Translate(x * speed, 0f, y * speed);
        rb.AddForce(x * speed, 0 , y * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin") {
            other.gameObject.SetActive(false);
            score++;
            scoreText.text = "Score: " + score;
        }

        if (score >= winScore) {
            pause = true;
            rb.isKinematic = true;
            WinText.enabled = true;
            infoText.enabled = true;
        }
    }
}
