using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
public class MainMenuManager : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public void Play()
    {
        // Load game scene
        // TransitionManager.LoadAsnyc(TransitionManager.SceneEnum.Gameplay);
    }

    public void Quit()
    {
        // Call save maybe
        Application.Quit();
    }
}
