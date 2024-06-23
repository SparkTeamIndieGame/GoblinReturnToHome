public class GunCS : WeaponBase
{

    public override void AddAmunicion(float value)
    {
        base.AddAmunicion(value);
        AmunitionCount.GunCount += value;
        //UseActualAmourCount();
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
            //this.gameObject.SetActive(false);
        }
    }
    public override float GetActualScore()
    {
        return AmunitionCount.GunCount;
    }
}
