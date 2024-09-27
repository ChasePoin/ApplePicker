using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public UnityEngine.UI.Button button;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.UI.Button btn = button.GetComponent<UnityEngine.UI.Button>();
        btn.onClick.AddListener(StartGame);
    }

    void StartGame() {
        Debug.Log("Loading Scene");
        SceneManager.LoadScene("_Scene_0");
        
    }
}
