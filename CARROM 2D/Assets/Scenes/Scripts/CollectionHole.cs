using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionHole : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Coins") //|| collider.gameObject.tag == "striker")
        {
            GameManager.Instance.CoinCollected(collider.gameObject);
        }
        if (collider.gameObject.tag == "striker")
        {
            collider.GetComponent<Striker>().StrikerReset();
            // collider.transform.position = new Vector3(0,-3.1944f,0);
        }
    }
}

