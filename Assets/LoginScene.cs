using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScene : MonoBehaviour
{
    [SerializeField] private Button loginButton;
    
    
    // Start is called before the first frame update
    void Start()
    {

        loginButton.onClick.AddListener(ReplaceScene);
        
       // GetComponent<AudioSource>().Play();
    }
    
    
    

    // Update is called once per frame


  private  void ReplaceScene()
    {

        SceneManager.LoadSceneAsync("Game");

    }
}

