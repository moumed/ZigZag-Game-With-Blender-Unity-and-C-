using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCheminOnDragMouse : MonoBehaviour
{
    //Variable qui contorle la vitesse de controle du chemin
    float speed = 1.2f; 

    // Ici nous déclarons la fonction qui permet de controler le chemin en ZigZag
    // Ceci en cliquant sur le bouton Gauche de la souris et la déplacer en haut, en bas,à gauche ou à droite
    private void OnMouseDrag()
    {
        // on récupère la valeur sur l'axe X, et on la transforme en gradiants
        float rotx = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
        // on récupère la valeur sur l'axe Y, et on la transforme en gradiants
        float roty = Input.GetAxis("Mouse Y") * speed * Mathf.Deg2Rad;
        // ici on limite l'orientation de notre chemin sur les deux axes
        roty = Mathf.Clamp(roty, -0.0003f, 0.0003f);
        rotx = Mathf.Clamp(rotx, -0.003f, 0.003f);

        // On déclare des vecteurs 3D qui permette d'orienter le chemin
        Vector3 forwardAngle = Vector3.forward; // Orientation Haut et Bas
        Vector3 leftAngle = Vector3.left; // Orientation à gauche et à droite

        // on assigne les angles d'orientation au transform de notre objet (le Chemin)
        // on effectue une orientation autour du Pivot de l'objet (le chemin)
        transform.RotateAround(forwardAngle, rotx);
        transform.RotateAround(leftAngle, roty);


        


    }

    private void Update()
    {
        // si Clique gauche de la souris
        if (Input.GetMouseButtonDown(0))
        {
            // on appel notre fonction OnDragMouse()
            OnMouseDrag();
        }

    }
}



