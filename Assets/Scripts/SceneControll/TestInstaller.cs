using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    public GameObject player;

    public override void InstallBindings()
    {
        Container.Bind<GameObject>().FromInstance(player);
    }
}