using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_scp : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private GameObject Enemy_container;
    bool player_lives=true;
    [SerializeField]
    private GameObject Triple_powerup;
    [SerializeField]
    private GameObject Speed_powerup;
    [SerializeField]
    private GameObject[] powerupID;

    void Start()
    {
        
        
    }

   public void spawn_start()

    {
        StartCoroutine(spawn_Enemy());
        StartCoroutine(spawn_powerup());
    }

    IEnumerator spawn_Enemy()
    {
        while(player_lives)
        {
            Vector3 Enemy_position = new Vector3(Random.Range(-8.0f, 8.0f), 7.0f, 0f);
           GameObject new_enemy = Instantiate(Enemy, Enemy_position, Quaternion.identity);
            new_enemy.transform.parent = Enemy_container.transform;
            yield return new WaitForSeconds(3.0f);
        }
    }

    public void stop_spawn()
    {
        player_lives = false;
    }

    IEnumerator spawn_powerup()
    {
        while(player_lives)
        {
            yield return new WaitForSeconds(Random.Range(7.0f, 13.0f));
            int random = Random.Range(0, 3);
            Instantiate(powerupID[random].gameObject, new Vector3(Random.Range(-8.0f, 8.0f), 7.0f, 0), Quaternion.identity);
        }
                
    }
    
}
