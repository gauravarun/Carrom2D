using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<UIManager>();
            }

            return _instance;
        }
    }
    public Image powerIndicator;
    public float factor;


    void Update()
    {
        if(GameManager.Instance.striker.GetComponent<Rigidbody2D>().velocity.magnitude == 0 && GameManager.Instance.striker.positionIsSet)
        {
            powerIndicator.fillAmount = Vector2.Distance(GameManager.Instance.striker.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) / factor;
        }
        
        // if (Input.GetKey(KeyCode.UpArrow)) //Increase power of striker
        // {
        //     powerIndicator.fillAmount += Time.deltaTime;
        // }
        // if (Input.GetKey(KeyCode.DownArrow)) //Decrease power of striker
        // {
        //     powerIndicator.fillAmount -= Time.deltaTime;
        // }
    }
}
