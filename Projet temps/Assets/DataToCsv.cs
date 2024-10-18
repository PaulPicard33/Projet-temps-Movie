using System.IO;   // Pour utiliser StreamWriter
using UnityEngine;

public class DataToCSV : MonoBehaviour
{
    // Chemin du fichier CSV (modifie ce chemin si nécessaire)
    private string filePath = "C:/Users/33673/MOVIE/temps/Projet-temps-Movie/relevédedonnées";

    void Start()
    {
        // Initialisation du chemin (on peut aussi mettre un chemin absolu)
        filePath = Application.dataPath + "/DataCollected.csv"; // compléter à partir de l'UI à chaque nouveau sujet 

        // Si le fichier n'existe pas, le créer et écrire l'en-tête
        if (!File.Exists(filePath))
        {
            // Écrire l'en-tête du fichier CSV (par exemple : "Temps, Position X, Position Y, Position Z")
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Temps,Position X,Position Y,Position Z");
            }
        }
    }

    void Update()
    {   
        
        if (GameManager.Instance.state == "Forward" || GameManager.Instance.state == "Backward" || GameManager.Instance.state =="visualisation")
        // Collecter des données à chaque frame (par exemple la position du joueur)
        {float time = Time.time;
        Vector3 position = transform.position;

        // Écrire ces données dans le fichier CSV
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            string dataLine = time + "," + position.x + "," + position.y + "," + position.z;
            writer.WriteLine(dataLine);
        }
    }
}
}