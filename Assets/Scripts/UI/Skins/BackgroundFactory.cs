using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundFactory", menuName = "Factory/BackgroundFactory")]
public class BackgroundFactory : ScriptableObject
{
    [SerializeField] private GameObject _default;
    [SerializeField] private GameObject _sky;

    public GameObject GetPrefab(SkinsBackground skinType)
    {
        switch (skinType)
        {
            case SkinsBackground.Defualt:
                return _default;
            case SkinsBackground.Sky:
                return _sky;

            default:
                throw new ArgumentException(nameof(skinType));
        }
    }
}
