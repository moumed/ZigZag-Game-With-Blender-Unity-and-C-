using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondaryMenuScript : MonoBehaviour
{
    //Ici on déclare deux fonction Restart et Quit de notre menu scondaire dans la scène 2
    // Fonction QuitSceneGame, nous permet de charger la scene précedente, cad on quite la scéne en cours et on rejoint la scene précedente dans
    // l'ordre que nous avons assigné nos scènes
    public void QuitSceneGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
    }

    // Fonction RestartSceneGame nous permet de recharger la scene en cours.
    public void RestartSceneGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
