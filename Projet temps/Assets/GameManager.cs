using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using OVR.OpenVR;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //singleton instance
    public static GameManager Instance;
    public string state; //game state 
    public int trials; // nombre de trials
    public UIManager UImanager; // UI manager
    public SoundManager soundManager; // sound manager
    public DataToCSV    dataToCSV; // data to csv
    public List<double> Max_distances;
     public int count_max_distances; // liste des distances
     public bool record;
     public string Text_Name; // nom du participant et date etc 
    private string filePath = "C:/Users/33673/MOVIE/temps/Projet-temps-Movie/relevédedonnées";
    public int NumberOfTrials;
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
            Debug.Log("Activation de l'écran : " + i);
        }
    }

    // Update is called once per frame
    void Update()
    {     
        if (trials <= NumberOfTrials)
        switch (state)
        {   case("seated1"):
                wait_for_time(); // attendre un certain nombre de secondes aléatoires avant de commencer à marcher 
                record =false;
                state  = "Forward";
                break;
            case("Forward"):

                GoForward();
                record = true;// commencer à enregistrer les données
                state = "Backward";
                break;
            case ("Backward"):

                record=true;// continuer à enregistrer les données
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    //arréter le record des données 
            Debug.Log("Space key was pressed");
                record= false;

                }
                count_max_distances+=1;
                state = "seated 2";
                break;
            case("seated 2"):
                wait_for_time(); // attendre un certain nombre de secondes aléatoires avant de commencer à visualiser 
                record = false;
                state = "visualisation";
                break;
            case("visualisation"):

                record = true;// continuer à enregistrer les données
                if(OVRInput.GetUp(OVRInput.RawButton.A))
            {
                //arrêter le temps de visualisation et l'écrire dans le doc 
                record = false;
                }
                trials +=1;
                UImanager.ChangeText_Trials();
                state = "seated 1";
                break;  
        }
    
    }
    public void Create_distances_lists()
    {
        //créer une liste de distances aléatoires
        Max_distances= UImanager.Distance_list();
        shuffle();

    }
    public void writer()
    {
        //écrire les données dans un fichier csv
        filePath = Application.dataPath + GameManager.Instance.Text_Name.ToString() +"states"+ ".csv"; // compléter à partir de l'UI à chaque nouveau sujet 
        if (!File.Exists(filePath))
        {
            // Écrire l'en-tête du fichier CSV (par exemple : "Temps, Position X, Position Y, Position Z")
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Temps,Position X,Position Y,Position Z");
            }
        }
    }
    public void writer_state(string state)
    {
        //écrire les données dans un fichier csv
        filePath = Application.dataPath + GameManager.Instance.Text_Name.ToString() +"states"+ ".csv"; // compléter à partir de l'UI à chaque nouveau sujet 
        if (!File.Exists(filePath))
        {
            // Écrire l'en-tête du fichier CSV (par exemple : "Temps, Position X, Position Y, Position Z")
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(state);
            }
        }
    }

    public void GoBack()
    {
     //envoyer un son dans le casque pour dire de revenir en arrière 
    soundManager.playstop();
    
     // créer la vision de la fin de la course avec un mur ou quelque chose    
    }
    public void GoForward()
    {
        //envoyer un son dans le casque pour dire de commencer à marcher 
        //envoyer une image GO sur l'écran
    }
    
    public void reset_data()
    {
        //reset des données et des variables
        trials = 0;
        count_max_distances =0;
        state = "seated1";
        Create_distances_lists();
        writer(); // reset du fichier avec les states 
        dataToCSV.write_name();//reset du nom du fichier csv
        NumberOfTrials= int.Parse(UImanager.NumberOfTrials.text.ToString()); //reset du nombre de trials
        
    }
    public void wait_for_time ()
    {
        //attendre un certain temps avant de passer à l'étape suivante
        {
        StartCoroutine(WaitAndExecute(N_seconds: UImanager.generateCoolDown()));
        }
    }
    IEnumerator WaitAndExecute( float N_seconds)
    {
        yield return new WaitForSeconds(N_seconds);
    }
     public void change_quality()
    {
        // changer le nombre de triangles dans le mesh renderer 
    }
    public void shuffle()
    {
        int i;
    for( i=0; i<Max_distances.Count; i++)
        {   int rng = UnityEngine.Random.Range(0, Max_distances.Count);// le but ici est de shuffle la liste des temps d'attente possible 
            double temp  = Max_distances[rng];
            Max_distances[i] = temp;
            Max_distances[rng] = Max_distances[i];

        }
    }
    public void createName()
    {
         Text_Name= UImanager.Text_Date_person.ToString();
    }
}
