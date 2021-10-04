using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // ici on déclare deux fonction pour les bouton Start et Quit du menu principale
    // Fonction Play game permet de lancer le jeu
    public void PlayGame()
    {
        // Ici on charge la scene de l'indexe suivant, nous permet de quitter la scene en cours et rejoindre la suivante dans l'ordre
        //  que nous avons assigné les scènes
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // fonction QuitGame, qui permet de fermer le jeu.
    public void QuitGame()
    {
        Application.Quit();
    }
}
