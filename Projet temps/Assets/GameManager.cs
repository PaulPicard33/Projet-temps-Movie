using System;
using System.Collections;
using System.Collections.Generic;
using OVR.OpenVR;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //singleton instance
    public static GameManager Instance;
    public string state; //game state
    public bool EndOfRoad; // booléen pour savoir si on est arrivé à la fin du chemin
    public bool StartWalking; //booléen pour savoir quand commencer à marcher 
    public int trials; // nombre de trials
    public UIManager UImanager; // UI manager
    public List<double> Max_distances; // liste des distances
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
        switch (state)
        {   case("seated1"):

                Max_distances = UImanager.Distance_list();
                wait_for_time(); // attendre un certain nombre de secondes aléatoires avant de commencer à marcher 
                state  = "Forward";
                break;
            case("Forward"):
            



                record()    ; // commencer à enregistrer les données
                state = "Backward";
                break;
            case ("Backward"):

                record()    ; // continuer à enregistrer les données
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    //arréter le record des données 
            Debug.Log("Space key was pressed");

                }





                state = "seated 2";
                break;
            case("seated 2"):



                wait_for_time(); // attendre un certain nombre de secondes aléatoires avant de commencer à visualiser 
                state = "visualisation";
                break;
            case("visualisation"):


                if(OVRInput.GetUp(OVRInput.RawButton.A))
            {
                //arrêter le temps de visualisation et l'écrire dans le doc 
                }
                trials +=1;
                UImanager.ChangeText_Trials();
                state = "seated 1";
                break;
        }
    
    }
    void FixedUpdate(){
        
    }

    public void GoBack()
    {
     //envoyer un son dans le casque pour dire de revenir en arrière 
    
    EndOfRoad =true;
     // créer la vision de la fin de la course avec un mur ou quelque chose    
    }
    public void GoForward()
    {
        //envoyer un son dans le casque pour dire de commencer à marcher 
        StartWalking = true;    
        //envoyer une image GO sur l'écran
    }
    public void record ()
    {   if (state == "Forward" || state== "Backward")
    {
// enregistrer et envoyer les données temporelles et spatiales de la personne dans un fichier

    }
    else if (state == "visualisation")
    {
        //enregistrer les données temporelles de la personne dans un fichier 
    }

}
    public void reset_data()
    {
        //reset des données et des variables
        trials = 0;
        
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
}
