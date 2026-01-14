using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obst;
    public GameObject player;
    public Transform spawnPoint;
    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject PlayButton;


    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){}

    private void OnEnable()
    {
        Obstacle.OnPlayerPassedTheObstacle += HandlePlayerPassedTheObstacle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandlePlayerPassedTheObstacle() {
        score++;
        scoreText.text = score.ToString();
    }

    IEnumerator SpawnObstacle() {
        while (true) {
            float wait = Random.Range(0.7f, 2f);

            yield return new WaitForSeconds(wait);

            Instantiate(obst, spawnPoint.position, Quaternion.identity);
        }
    }
    public void GameStart() { 
        player.SetActive(true);
        StartCoroutine("SpawnObstacle");
        PlayButton.SetActive(false);
    }
}
