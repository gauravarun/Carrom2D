using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Striker : MonoBehaviour

{
    Rigidbody2D rigidbody;
    public LineRenderer visualizerLine;
    Vector2 StartPostion;
    Vector2 direction;
    Vector3 worldMousePos;
    
    Transform arrowTransform;
    Transform selfTransform;
    public int strikerSpeed = 500;
    bool hasStriked = false;
    public bool positionIsSet = false;
    

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
        StartPostion = transform.position;
        selfTransform = transform;
    }

    void Update()
    {

        worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();

        if (!hasStriked && !positionIsSet)
        {
            selfTransform.position = new Vector2(Mathf.Clamp(worldMousePos.x, -2.58f, 2.57f), StartPostion.y);
        }

        if (positionIsSet && rigidbody.velocity.magnitude == 0)
        {
            visualizerLine.SetPosition(0,selfTransform.position);
            visualizerLine.SetPosition(1,worldMousePos);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!positionIsSet)
            {
                positionIsSet = true;
            }
        }
    }

    public void StrikerReset()
    {
        rigidbody.velocity = Vector2.zero;
        hasStriked = false;
        positionIsSet = false;
    }
    public void ShootStriker()
    {

        rigidbody.AddForce(direction * GameManager.Instance.CalculateStrikerForce());
        hasStriked = true;
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space) && rigidbody.velocity.magnitude == 0)
        {
            ShootStriker();

        }
        if (rigidbody.velocity.magnitude < 0.2f && rigidbody.velocity.magnitude != 0)
        {
            StrikerReset();
        }
        
    }
}

