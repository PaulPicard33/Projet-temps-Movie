using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    public List<double> Max_distances;
     public int count_max_distances; // liste des distances
     public bool record;
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
        reset_data();
        Max_distances = UImanager.Distance_list();
        shuffle(Max_distances);
    }

    // Update is called once per frame
    void Update()
    {   UImanager.ResetButton.onClick.AddListener(reset_data);  
        if (trials <= int.Parse(UImanager.NumberOfTrials.text[0].ToString()))
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
    void FixedUpdate()
    {    
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
    
    public void reset_data()
    {
        //reset des données et des variables
        trials = 0;
        count_max_distances =0;
        state = "seated1";
        
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
    public List<double> shuffle(List<double> output)
    {
        int i;
    for( i=0; i<output.Count; i++)
        {   int rng = UnityEngine.Random.Range(0, output.Count);// le but ici est de shuffle la liste des temps d'attente possible 
            double temp  = output[rng];
            output[i] = temp;
            output[rng] = output[i];

        }

        return((output));
    }
}
