using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class c_WarningStartScreen : MonoBehaviour
{
    Button GoButton;

    // Start is called before the first frame update
    void Start()
    {
        GoButton = GameObject.Find("Button").GetComponent<Button>();
        GoButton.onClick.AddListener(delegate { GoToMainMenu(); });
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    
}
