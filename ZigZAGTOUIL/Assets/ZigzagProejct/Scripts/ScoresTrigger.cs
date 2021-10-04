using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresTrigger : MonoBehaviour
{
    // Lorsqu'on détecte l'entrée d'un triger on éxecute la fonction StartCaroutine()
    private void OnTriggerEnter(Collider other)
	{
        // On lance une caroutine qui execute l IEnumerator WaitForScore
        StartCoroutine(WaitForScore(other));

    }
    // On déclare les variable dont on aurra besoin
    private float Score = 0f; // Variable pour le Score finale obtenu
    private float ScorteInit = 0f; // Variable pour le score Initiale
    public Text TextScore; // pour Affichae du score
    public Text TextTag; // pour récompenser le user
    public Text TextTime; // pour l'affichage du temps dans le jeu
    public Text HighScore; // pour le plus grand score obtenu dans le jeu
    private float StartTime; // Pour début du chronometre
    private bool finished; // pour detecter si le jeu est terminé ( cad la boule est tombée du chemin
    public GameObject ScoreMenu; // pour le menu qui affiche le score dans le jeu

    void Start(){
        // On lance le chronometre
        StartTime = Time.time;
        
    }

    void Update(){
        // si la boulle est tombée on arrete le chrono
        if (finished)
            return;
        // on récupère le temps
        float t = Time.time - StartTime; // on fait la diff entre le startTime et le temps à l'instant
        string minutes = ((int) t / 60).ToString(); // on récupère les minutes
        string seconds = (t % 60).ToString("f2"); // on récupère les secondes

        TextTime.text = minutes + ":" + seconds; // on assemble les minutes et les secondes
       
    }

    // l'IEnumerator WaitForScore nous permet d'attendre un moment spécifique avant d'executer notre code
    // nous avons besoin de ça pour le bon affichage des résultats dans le jeu
    IEnumerator WaitForScore(Collider col)
    {
        // Après 1.4 secondes 
        yield return new WaitForSeconds(2f);

        
        // ici on récupere les scores obtenus
        // on teste selon le nom du Trigger de chaque score dans le plateau (la boite de notre jeux)
        // pour chaque trigger on affecte le score initiale qui lui correspond, et on arrete le chrono
        // Cas de score 0
        if (col.gameObject.name == "TriggerScoreZero")
        {
            ScorteInit = 0f;
            finished = true;
        }
        // Cas de score 10
        else if (col.gameObject.name == "TriggerScoreDix")
        {
            ScorteInit = 10f;
            finished = true;
        }
        // Cas de score 20
        else if (col.gameObject.name == "TriggerScoreVingt")
        {
            ScorteInit = 20f;
            finished = true;
        }
        // Cas de score 30
        else if (col.gameObject.name == "TriggerScoreTrente")
        {
            ScorteInit = 30f;
            finished = true;
        }
        // Cas de score 40
        else if (col.gameObject.name == "TriggerScoreQuarente")
        {
            ScorteInit = 40f;
            finished = true;
        }
        // Cas de score 50
        else if (col.gameObject.name == "TriggerScoreCinquante")
        {
            ScorteInit = 50f;
            finished = true;
        }
        // Cas de score 60
        else if (col.gameObject.name == "TriggerScoreSoixante")
        {
            ScorteInit = 60f;
            finished = true;
        }
        // Cas de score 70   
        else if (col.gameObject.name == "TriggerScoreSoixantedix")
        {
            ScorteInit = 70f;
            finished = true;
        }
        // Cas de score 80
        else if (col.gameObject.name == "TriggerScoreQuatrevingt")
        {
            ScorteInit = 80f;
            finished = true;
        }
        // Cas de score 90 
        else if (col.gameObject.name == "TriggerScoreQuatrevingtdix")
        {
            ScorteInit = 90f;
            finished = true;
        }
        // Cas de score 100
        else if (col.gameObject.name == "TriggerScoreCent")
        {
            ScorteInit = 100f;
            finished = true;
        }

        // On rend le menu des scores Actif ( pour l'affichage ) 
        ScoreMenu.SetActive(true);

        // ici  on crée une sauvgarde dans notre system avec ID="HighScore", et on la déclare à 0
        HighScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString(); // on l'affecte au text de high score pour l'affichage

        // On assigne le score globale
        Score = ScorteInit;

        // On affecte le score à TextScore object pour l'affichage
        TextScore.text =  Score +" Points";
        
        // Ici on donne la récompence visuelle à l'utilisateur
        // Cas de 0
        if(Score == 0)
        {
            // On affiche un text en Rouge
            TextTag.color = new Color(255f, 0f, 0f); //Rouge
            // et sa récompence est "Oups"
            TextTag.text = "Oups !";
        }
        // Cas ou il a batu le high Score
        else if (Score >= PlayerPrefs.GetFloat("HighScore", 0))
        {
            // récompencer par "Great"
            TextTag.text = "Great !";
            // on sauvgarde le nouveau High Score
            PlayerPrefs.SetFloat("HighScore", Score);
            // La récompence en Vert
            TextTag.color = new Color(0.1f, 0.6f, 0.9f);//vert
            // On Assigne le high score au HighScore Text Object
            HighScore.text = Score.ToString();
        }
        // Cas ou il ne dépasse pas le High score
        else 
        {
            // récompnse "Oups" en rouge
            TextTag.color = new Color(255f, 0f, 0f); //Rouge
            TextTag.text = "Oups !";
        }
        
    }

    // ici une fonction qui permet de rinitialiser le HighScore, que nous allons assigner à un boutton
    public void ResetHighScore()
    {
        // On suprime la sauvgarde avec l'ID="HighScore" en cours
        PlayerPrefs.DeleteKey("HighScore");
        // On la rinitialise à Zero 
        HighScore.text = "0";
    }

    private void OnTriggerExit(Collider other)
    {
        Score = 0;
    }


    
}
