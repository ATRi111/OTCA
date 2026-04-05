using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Entity
{
    protected bool isObstacle;
    public override bool IsObstacle => true;

}
