using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //‰º•ûŒü‚ÉˆÚ“®
    [SerializeField]
    private Vector3 underMove = new Vector3(0, 0, 0);



    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position += underMove * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "BallTag")
        Destroy(this.gameObject);
    }


}
