using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float walkSpeed;
    public float walkSmoothness;

    public float jumpForce;
    public AnimationCurve jumpSmoothness;

    public float gravity;
    public bool dimension2D = true;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        ChangeDimension();
        UpdateMovement();
        JumpInput();
    }

    // CHARACTER MOVEMENT INPUT
    float velocityY = 0.0f;
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    float xMov;
    float zMov;
    void UpdateMovement()
    {

        Vector2 targetDir = new Vector2(zMov, xMov);
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, walkSmoothness);

        velocityY += -gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.x + transform.right * currentDir.y) * walkSpeed + transform.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
    }

    public void ChangeDimension() //Create a switch from
    {
        if (dimension2D)
        {
            zMov = 0;
        }
        else
        {
            zMov = Input.GetAxisRaw(GameConstants.k_AxisNameVertical);
        }

        xMov = Input.GetAxisRaw(GameConstants.k_AxisNameHorizontal);
    }

    // CHARACTER JUMP ACTION
    int jumpCount;
    float timeInAir = 0.0f;
    private void JumpInput()
    {

        if (controller.isGrounded)
        {
            jumpCount = 0;
            velocityY = 0.0f;

        }

        //Debug.Log(jumpInput);
        if (Input.GetButtonDown(GameConstants.k_ButtonNameJump))
        {
            if (jumpCount < 2)
            {
                jumpCount++;
                StartCoroutine(JumpEvent(1));
            }
        }
    }

    bool aboveColl;
    private IEnumerator JumpEvent(float power)
    {
        controller.slopeLimit = 90.0f;

        timeInAir = 0.0f;
        do
        {
            float jumpMult = jumpSmoothness.Evaluate(timeInAir);
            controller.Move(Vector3.up * jumpMult * (jumpForce * power) * Time.deltaTime); // time * gamemanager.gameSpeed
            timeInAir += Time.deltaTime; // time * gamemanager.gameSpeed
            yield return null;
        } while (!controller.isGrounded);

        controller.slopeLimit = 45.0f;
    }
}
    //Vector3 startPos;
    //float heightOfKnock;
    //float knockback;
    //bool getPushed;
    //public void CallKnockback(Vector3 StartPos, float HeightOfKnock, float Knockback, bool GetPushed)
    //{
    //    if(controller.isGrounded)
    //    {
    //        startPos = StartPos;
    //        heightOfKnock = HeightOfKnock;
    //        knockback = Knockback;
    //        getPushed = GetPushed;
    //    }
    //}

    //public IEnumerator KnockBack(Vector3 StartPos, float HeightOfKnock, float Knockback)
    //{

    //        Vector3 targetPos = gameObject.transform.position;
    //        Vector3 heightKnock = new Vector3(0, HeightOfKnock, 0);

    //        timeInAir = 0.0f;
    //        do
    //        {
    //            float jumpMult = jumpSmoothness.Evaluate(timeInAir);
    //            Vector3 knockDirection = (targetPos - StartPos + heightKnock) * jumpMult * Knockback * Time.deltaTime;
    //            controller.Move(knockDirection);
    //            timeInAir += Time.deltaTime;

    //            yield return null;
    //        } while (!controller.isGrounded);

    //    }
    //}
