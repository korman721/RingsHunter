using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopContent", menuName = "GameShop/ShopContent")]
public class ShopContent : ScriptableObject
{
    [SerializeField] private List<SkinsArrowItem> _skinsArrowItems;
    [SerializeField] private List<SkinsBackgroundItem> _skinsBackgroundItems;
    [SerializeField] private List<RingSkinsItem> _ringSkinsItems;

    public IEnumerable<SkinsArrowItem> SkinsArrowItems => _skinsArrowItems;
    public IEnumerable<SkinsBackgroundItem> SkinsBackgroundItems => _skinsBackgroundItems;
    public IEnumerable<RingSkinsItem> RingSkinsItems => _ringSkinsItems;

    private void OnValidate()
    {
        var skinsArrowDuplicates = _skinsArrowItems.GroupBy(item => item.SkinType)
            .Where(array => array.Count() > 1);

        if (skinsArrowDuplicates.Count() > 0)
            throw new InvalidOperationException(nameof(_skinsArrowItems));

        var skinsBackgroundDuplicates = _skinsBackgroundItems.GroupBy(item => item.SkinType)
            .Where(array => array.Count() > 1);

        if (skinsBackgroundDuplicates.Count() > 0)
            throw new InvalidOperationException(nameof(_skinsBackgroundItems));

        var skinsRingDuplicates = _ringSkinsItems.GroupBy(item => item.SkinType)
            .Where(array => array.Count() > 1);

        if (skinsRingDuplicates.Count() > 0)
            throw new InvalidOperationException(nameof(_ringSkinsItems));
    }
}
