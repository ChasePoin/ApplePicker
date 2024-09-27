using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int        numBaskets = 4;
    public float      basketBottomY = -14f;
    public float      basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i =0; i < numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed() {
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");
        GameObject[] badAppleArray=GameObject.FindGameObjectsWithTag("BadApple");
        foreach (GameObject tempGO in appleArray) {
            Destroy(tempGO);
        }
        foreach (GameObject tempGO in badAppleArray ) {
            Destroy(tempGO);
        }
        int basketIndex = basketList.Count - 1;

        // gets reference to existing basket at that index
        GameObject basketGO = basketList[basketIndex];
        // removes it from the list then destroys it
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);
        if (basketList.Count == 0) {
            SceneManager.LoadScene("GameOver");
        }
    }
}
