using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地
/// </summary>
public class Ground : Entity
{
    protected bool isObstacle;
    public override bool IsObstacle => true;

}
