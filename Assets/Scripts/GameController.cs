using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public float scoreIncreaseRate = 1;
    public int scoreMultiplier = 10;
    public GameObject gameOver;
    public Text rankingText;
    public Text scoreText;
    public PhysicMaterial normalPhysics;
    public PhysicMaterial hardPhysics;

    private bool isGameOver = false;
    private float score = 0;
    private Collider shelfBody;


    // Use this for initialization
    void Start () {
        isGameOver = false;
        scoreText.text = 0.ToString();
        shelfBody = GameObject.FindWithTag("Shelf").GetComponent<Collider>();
        shelfBody.material.dynamicFriction = GetFriction();
    }

    float GetFriction() {
        return PlayerPrefs.GetFloat("friction");
    }

    void SetFriction(float f) {
        PlayerPrefs.SetFloat("friction", f);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") && isGameOver){ SceneManager.LoadScene("Main"); }
        if (Input.GetKeyDown("1")) {
            SetFriction(0.05f);
            shelfBody.material.dynamicFriction = GetFriction();
            print ("Normal");
        }
        if (Input.GetKeyDown("2")) {
            SetFriction(0.0f);
            shelfBody.material.dynamicFriction = GetFriction();
            print("Hard");
        }
	}

    public void IncreaseScore() {
        score += Time.deltaTime * scoreIncreaseRate;
        scoreText.text = ScoreCalc().ToString();
    }

    int ScoreCalc() {
        return Mathf.FloorToInt(score * scoreMultiplier);
    }

    public void Lose() {
        isGameOver = true;
        gameOver.SetActive(true);
        gameOver.GetComponent<Text>().text = "Score: " + ScoreCalc();
        if (ScoreCalc() <= 20)                          { rankingText.text = "Rank: Sad Sapling"; }
        else if (ScoreCalc() > 20 && ScoreCalc() <= 40) { rankingText.text = "Rank: Scrub Shrub"; }
        else if (ScoreCalc() > 40 && ScoreCalc() <= 60) { rankingText.text = "Rank: Grassy Knoll"; }
        else if (ScoreCalc() > 50 && ScoreCalc() <= 80) { rankingText.text = "Rank: Willfull Weed"; }
        else if (ScoreCalc() > 80 && ScoreCalc() <= 100){ rankingText.text = "Rank: Thorny Rose"; }
        else if (ScoreCalc() >100 && ScoreCalc() <= 120){ rankingText.text = "Rank: Old Oak"; }
        else                                            { rankingText.text = "Rank: Weed Wizard"; }
    }
}