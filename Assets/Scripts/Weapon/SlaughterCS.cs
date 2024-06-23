using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaughterCS : WeaponBase
{
    public override void AddAmunicion(float value)
    {
        base.AddAmunicion(value);
        AmunitionCount.SlaughterCount += value;
    }
    public override void RemoveAmunicion()
    {
        AmunitionCount.SlaughterCount -= 1;
        UseActualAmourCount();
    }
    //public override void ChekingAmunicion()
    //{
    //    if (AmunitionCount.SlaughterCount <= 0)
    //    {
    //        //base.Event();
    //        this.gameObject.SetActive(false);
    //    }
    //}
    public override float GetActualScore()
    {
        return AmunitionCount.SlaughterCount;
    }
}
