using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopCategoryButton : MonoBehaviour
{
    public event Action Click;

    [SerializeField] private Button _button;

    [SerializeField] private Image _image;
    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _unselectesColor;

    private void OnEnable() => _button.onClick.AddListener(OnClick);
    private void OnDisable() => _button.onClick.RemoveListener(OnClick);

    public void Select() => _image.color = _selectedColor;
    public void Unselect() => _image.color = _unselectesColor;

    private void OnClick() => Click?.Invoke(); 
}
