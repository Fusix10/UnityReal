using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool DoubleJump;
    bool WallJump;
    public GameObject Feet;
    public List<GameObject> Arm;
    public int PowerJump;
    public float MoveSpeed;
    // Update is called once per frame
    void Update()
    {
        Vector2 test = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        if (Input.GetKey(KeyCode.D))
        {
            if (Feet.GetComponent<OnPlayerFeet>().OnSeul == false)
            {
                test.x += MoveSpeed/2;
            }
            else
            {
                test.x += MoveSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            if (Feet.GetComponent<OnPlayerFeet>().OnSeul == false)
            {
                test.x += -MoveSpeed/2;
            }
            else
            {
                test.x += -MoveSpeed;
            }

        }
        GetComponent<Rigidbody2D>().velocity = test;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Feet.GetComponent<OnPlayerFeet>().OnSeul);
            if(Feet.GetComponent<OnPlayerFeet>().OnSeul == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * PowerJump);
                DoubleJump = true;
                WallJump = true;
            }
            if(DoubleJump == true || WallJump == true)
            {
                Vector2 Test2 = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
                if (DoubleJump == true && Feet.GetComponent<OnPlayerFeet>().OnSeul == false && Arm[0].GetComponent<OnPlayerArm>().OnWall == false && Arm[1].GetComponent<OnPlayerArm>().OnWall == false)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * PowerJump);
                    DoubleJump = false;
                }
                if (WallJump == true && Feet.GetComponent<OnPlayerFeet>().OnSeul == false)
                {
                    if (Arm[0].GetComponent<OnPlayerArm>().OnWall == true)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                        GetComponent<Rigidbody2D>().AddForce(Vector2.up * PowerJump);
                        Test2.x += -MoveSpeed * 3;
                        GetComponent<Rigidbody2D>().velocity = Test2;
                        WallJump = false;
                    }
                    if (Arm[1].GetComponent<OnPlayerArm>().OnWall == true)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                        GetComponent<Rigidbody2D>().AddForce(Vector2.up * (PowerJump * (1 / 3)));
                        GetComponent<Rigidbody2D>().AddForce(Vector2.right * (PowerJump * (1 / 3)*2));
                        WallJump = false;
                    }

                }

            }

        } 
    }
}
