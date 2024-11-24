using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ArrowFactory", menuName = "Factory/ArrowFactory")]
public class ArrowFactory : ScriptableObject
{
    [SerializeField] private GameObject _default;
    [SerializeField] private GameObject _killer;

    public GameObject GetPrefab(SkinsArrow skinType)
    {
        switch (skinType)
        {
            case SkinsArrow.Defualt:
                return _default;
            case SkinsArrow.Killer:
                return _killer;

            default:
                throw new ArgumentException(nameof(skinType));
        }
    }
}
