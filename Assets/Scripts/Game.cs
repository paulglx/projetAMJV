using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private GameObject flag; 
    private float temps; 
    private int numberOfEnemies;
    private GameObject king; 
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private int numberOfSpawn = 10; 


    // Start is called before the first frame update
    void Start()
    {   temps = Time.time;      
        SubscribeToFlag();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numberOfEnemies = enemies.Length;

    }

    // Update is called once per frame
    void Update()
    {
        temps = Time.time;
    }


    private void SetTheKing(GameObject player)
    {
        king = player;
        CreateEnemies(); 
    }

    private void SubscribeToFlag()
    {
        flag = GameObject.Find("Flag");

        if (flag != null)
        {
            flag.GetComponent<FlagManager>().FlagCaptured.AddListener(SetTheKing);
        }
        else
        {
            Debug.LogWarning("The gameObject \"Flag\" is not found in the current scene.");
        }
    }

    private void CreateEnemies()
    {
        for (int i =0; i<numberOfSpawn; i++)
        {
            float x = Random.Range(5f,21*6f); 
            x = king.transform.position.x + x;
            float z = Random.Range(5f,21*6f);
            z = king.transform.position.z + z;

            GameObject nouvelEnemy = Instantiate(enemyPrefab); 
            nouvelEnemy.transform.position = new Vector3(x,0f,z); 
            EnemyController nouvelEnemyContr= nouvelEnemy.GetComponent<EnemyController>();
            Debug.Log(nouvelEnemyContr);
            Debug.Log(new KingChaseState(nouvelEnemyContr, king));
            nouvelEnemyContr.TransitionToState(new KingChaseState(nouvelEnemyContr, king));
            nouvelEnemyContr.SetIsKingChasing();
            numberOfEnemies++; 
        }
    }


    public void OneDie()
    {
        numberOfEnemies -=1;
    }
}
