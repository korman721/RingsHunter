using UnityEngine;
[CreateAssetMenu(fileName = "ShopItemViewFactory", menuName = "GameShop/ShopItemViewFactory")]
public class ShopItemViewFactory : ScriptableObject
{
    [SerializeField] private ShopItemView _arrowSkinItemPrefab;
    [SerializeField] private ShopItemView _ringSkinItemPrefab;
    [SerializeField] private ShopItemView _backSkinItemPrefab;

    public ShopItemView Get(ShopItem shopItem, Transform parent)
    {
        ShopItemVisitor visitor = new ShopItemVisitor(_arrowSkinItemPrefab, _backSkinItemPrefab, _ringSkinItemPrefab);
        visitor.Visit(shopItem);

        ShopItemView instance = Instantiate(visitor.Prefab, parent);
        instance.Initialize(shopItem);

        return instance;
    }

    private class ShopItemVisitor : IShopItemVisitor
    {
        private ShopItemView _arrowSkinItemPrefab;
        private ShopItemView _backSkinItemPrefab;
        private ShopItemView _ringSkinItemPrefab;

        public ShopItemVisitor(ShopItemView arrowSkinItemPrefab, ShopItemView backSkinItemPrefab, ShopItemView ringSkinItemPrefab)
        {
            _arrowSkinItemPrefab = arrowSkinItemPrefab;
            _backSkinItemPrefab = backSkinItemPrefab;
            _ringSkinItemPrefab = ringSkinItemPrefab;
        }
        public ShopItemView Prefab { get; private set; }

        public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

        public void Visit(SkinsArrowItem skinsArrowItem) => Prefab = _arrowSkinItemPrefab;
        public void Visit(SkinsBackgroundItem skinsBackgroundItem) => Prefab = _backSkinItemPrefab;
        public void Visit(RingSkinsItem ringSkinsItem) => Prefab = _ringSkinItemPrefab;
    }
}
