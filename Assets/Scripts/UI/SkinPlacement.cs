using UnityEngine;

public class SkinPlacement : MonoBehaviour
{
    private const string RenderLayer = "SkinRender";
    private GameObject _currentModel;

    public void InstatiateModel(GameObject model)
    {
        if (_currentModel != null)
            Destroy(_currentModel.gameObject);

        _currentModel = Instantiate(model, transform);

        Transform[] children = _currentModel.GetComponentsInChildren<Transform>();

        foreach (var item in children)
            item.gameObject.layer = LayerMask.NameToLayer(RenderLayer);
    }
}
