using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardTankMovement : AbstractTankMovementModule
{
    public override Vector2 GetMovementDirection()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), 0);
        //return direction.normalized;
        return direction;
    }

    //void FixedUpdate()
    //{
    //    ApplyMovement(GetMovementDirection());

    //    Debug.Log("Direction = " + GetMovementDirection());
    //}
}
