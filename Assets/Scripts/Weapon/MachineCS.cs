
public class MachineCS : WeaponBase
{

    public override void AddAmunicion(float value)
    {
        base.AddAmunicion(value);
        AmunitionCount.MachineCount += value;
    }
    public override void RemoveAmunicion()
    {
        AmunitionCount.MachineCount -= 1;
        UseActualAmourCount();
    }
    public override void ChekingAmunicion()
    {
        if (AmunitionCount.MachineCount <= 0)
        {
            base.Event();
            //this.gameObject.SetActive(false);
        }
    }
    public override float GetActualScore()
    {
        return AmunitionCount.MachineCount;
    }
}
