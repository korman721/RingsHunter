using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RingFactory", menuName = "Factory/RingFactory")]
public class RingFactory : ScriptableObject
{
    [SerializeField] GameObject[] _greenPeace;
    [SerializeField] GameObject[] _defauld;

    public GameObject[] GetPrefab(SkinsRing skinType)
    {
        switch (skinType)
        {
            case SkinsRing.Defualt:
                return _defauld;
            case SkinsRing.GreenPeace:
                return _greenPeace;

            default:
                throw new ArgumentException(nameof(skinType));
        }
    }
}
