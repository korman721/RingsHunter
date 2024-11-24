using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ShopItemView : MonoBehaviour, IPointerClickHandler
{
    public event Action<ShopItemView> Click;

    [SerializeField] private Sprite _standartBack, _lightBack;
    [SerializeField] private Image _contentImage, _lockImage;

    [SerializeField] private IntValueView _priceView;

    [SerializeField] private Image _selectedText;


    private Image _backgroundImage;

    public ShopItem Item { get; private set; }
    public bool IsLock { get; private set; }

    public int Price => Item.Price;
    public GameObject Model => Item.Model;

    public GameObject StaticModel => Item.StaticModel;

    public void OnPointerClick(PointerEventData eventData) => Click?.Invoke(this);

    public void Initialize(ShopItem item)
    {
        _backgroundImage = GetComponent<Image>();
        _backgroundImage.sprite = _standartBack;

        Item = item;

        _contentImage.sprite = item.Image;

        _priceView.Show(Price);
    }

    public void Lock()
    {
        IsLock = true;
        _lockImage.gameObject.SetActive(IsLock);
        _priceView.Show(Price);
    }
    public void Unlock()
    {
        IsLock = false;
        _lockImage.gameObject.SetActive(IsLock);
        _priceView.Hide();
    }
    public void Select() => _selectedText.gameObject.SetActive(true);
    public void Unselect() => _selectedText.gameObject.SetActive(false);
    public void HighLight() => _backgroundImage.sprite = _lightBack;
    public void UnHighLight() => _backgroundImage.sprite = _standartBack;

}
