using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject badApplePrefab;
    public RoundCounter roundCounter;
    public float      speed = 2f;
    public float      leftAndRightEdge = 10f;
    public float      changeDirChance = 0.02f;
    public float      appleDropDelay = 1f;
    public float      badAppleDropChance = .05f;
    public int        curr = 1;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
        GameObject roundGO = GameObject.Find("RoundCounter");
        roundCounter = roundGO.GetComponent<RoundCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        ChangeDirection(pos);
    }
    void FixedUpdate() {
        if (Random.value < changeDirChance) {
            speed *= -1;
        }
    }
    void ChangeDirection(Vector3 pos) {
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge) {
            speed = -speed;
        }
    }
    void DropApple() {
        if (Random.value < badAppleDropChance) {
            GameObject badApple = Instantiate<GameObject>(badApplePrefab);
            badApple.transform.position = transform.position;
            Invoke("DropApple", appleDropDelay);
        }else {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
            Invoke("DropApple", appleDropDelay);
        }

    }
    public void UpdateDifficulty() {
        speed = speed * roundCounter.round;
        badAppleDropChance = badAppleDropChance * (roundCounter.round / 2);
    }
}
