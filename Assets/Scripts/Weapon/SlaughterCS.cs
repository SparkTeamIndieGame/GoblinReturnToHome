using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaughterCS : WeaponBase
{
    public override void AddAmunicion(float value)
    {
        AmunitionCount.SlaughterCount += value;
    }

    public override void RemoveAmunicion()
    {
        AmunitionCount.SlaughterCount -= 1;
        UseActualAmourCount();
    }

    public override float GetActualScore()
    {
        return AmunitionCount.SlaughterCount;
    }
}
