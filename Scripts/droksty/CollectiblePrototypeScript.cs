using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePrototypeScript : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private float timeBoost = 25f; // Το boost σε timeLeft που κερδίζει ο παίκτης όταν μαζέψει ένα collectible


    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    void OnTriggerEnter(Collider other) // Έλεγχος για Α. collectible B. Artifact C. Exit
    {
        if (gameObject.tag == "Collectible" && other.name == "Player") { // collectible
        
            // Debug.Log(gameObject.name + " picked up by " + other.name);

            // reserved for κώδικα που έχει σχέση με το GAME OVER MECHANIC

            gameManager.collectibleCounter += 1;
            // Debug.Log(gameManager.collectibleCounter);
            gameManager.collectiblesCollected.text = gameManager.collectibleCounter.ToString();

            gameManager.timer += timeBoost;

            //reserved for κώδικα που έχει σχέση με το GAME OVER MECHANIC
                    
            Destroy(gameObject);

        }
        else if (gameObject.tag == "Artifact" && other.name == "Player") { // artifacts
        
            // Debug.Log(gameObject.name + " picked up by " + other.name);
            gameManager.artifactCounter += 1;
            gameManager.artifactsCollected.text = gameManager.artifactCounter.ToString();

            // reserved for κώδικα που έχει σχέση με Level Advancement
            Destroy(gameObject);
        }
        else if (gameObject.tag == "Exit" && other.name == "Player") { // exit
            
            Debug.Log("Level Complete, go to next Level");
            
            // reserved for κώδικα που έχει σχέση με Level Advancement
        }
    }
        

}
