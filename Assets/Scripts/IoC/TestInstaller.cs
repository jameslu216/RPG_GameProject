using Item;
using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    [SerializeField] private Bag bag;
    public override void InstallBindings()
    {
        Container.Bind<Bag>().FromScriptableObject(this.bag).AsSingle();
    }
}