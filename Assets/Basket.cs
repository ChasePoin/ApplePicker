using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public RoundCounter roundCounter;
    public AppleTree appleTree;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();

        GameObject roundGO = GameObject.Find("RoundCounter");
        roundCounter = roundGO.GetComponent<RoundCounter>();

        GameObject atGO = GameObject.Find("AppleTree");
        appleTree = atGO.GetComponent<AppleTree>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll){
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple")) {
            Destroy(collidedWith);
            scoreCounter.score += 100;

            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
            Update_Round(scoreCounter.score);
        }
        else if(collidedWith.CompareTag("BadApple")) {
            SceneManager.LoadScene("GameOver");
        }
    }
    void Update_Round(int score) {
        if (score % 2000 == 0) {
            roundCounter.round = roundCounter.round + 1;
            appleTree.UpdateDifficulty();
        }
    }
}
