using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public string interactionButton = "Pause"; 
    public GameObject pauseMenuUI;
    public GameObject androidMenuUI;

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape)){
        if(CrossPlatformInputManager.GetButtonDown(interactionButton)){
            if(IsPaused){
                Resume();
                androidMenuUI.SetActive(true);
            }else{
                Pause();
                androidMenuUI.SetActive(false);
            }
        }        
    }

    public void Resume(){
        Debug.Log("Juego sin pausa");
        pauseMenuUI.SetActive(false);
        androidMenuUI.SetActive(true);
        Time.timeScale = 1f; //congela el juego
        IsPaused = false;
    }

    void Pause(){
        Debug.Log("Juego pausado...");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //congela el juego
        IsPaused = true;
    }


    public void QuitGame(){
        Debug.Log("Se termino la ejecución");
        Application.Quit();
    }
}
