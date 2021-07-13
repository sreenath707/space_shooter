using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_scp : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(0, 8, 0) * Time.deltaTime );
        if(transform.position.y > 8)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
