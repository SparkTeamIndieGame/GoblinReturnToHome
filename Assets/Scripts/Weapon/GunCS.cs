public class GunCS : WeaponBase
{

    public override void AddAmunicion(float value)
    {
        AmunitionCount.GunCount += value;
    }

    public override void RemoveAmunicion()
    {
        AmunitionCount.GunCount -= 1;
        UseActualAmourCount();
    }

    public override void ChekingAmunicion()
    {
        if (AmunitionCount.GunCount <= 0)
        {
            base.Event();
        }
    }

    public override float GetActualScore()
    {
        return AmunitionCount.GunCount;
    }
}
