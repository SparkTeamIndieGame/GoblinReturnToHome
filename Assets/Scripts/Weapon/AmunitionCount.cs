using UnityEngine;
public class AmunitionCount : MonoBehaviour
{
    public static float SlaughterCount, GunCount, ShotGunCount, MachineCount;

    private void Update()
    {
        print($" рогатка: {SlaughterCount}  пистолет: {GunCount}  дробовик {ShotGunCount} автомат: {MachineCount}");
    }
}
