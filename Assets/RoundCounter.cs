using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RoundCounter : MonoBehaviour
{
    [Header("Dynamic")]
    private TMP_Text uiText;
    public int round = 1;
    // Start is called before the first frame update
    void Start() {
        uiText = GetComponent<TextMeshProUGUI>();
    }
    void Update() {
        if (round == 5) {
            SceneManager.LoadScene("Victory");
        }else {
            uiText.text = round.ToString("Round: ,0");
        }
    }
}
