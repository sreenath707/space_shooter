using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid_scp : MonoBehaviour
{
    [SerializeField]
    private GameObject Explosion;
    private spawn_scp spawn_script;
    

    void Start()
    {
        spawn_script = GameObject.Find("spawn manager").GetComponent<spawn_scp>();
        if(spawn_script==null)
        {
            Debug.Log("WWWWRRRRROOOOONNNGGGG");
        }
        
    }


    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90.0f) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "laser")
        {
            Instantiate(Explosion.gameObject, transform.position, Quaternion.identity);
            Destroy(Other.gameObject);
            
            spawn_script.spawn_start();
            Destroy(this.gameObject);
        }
    }
}
