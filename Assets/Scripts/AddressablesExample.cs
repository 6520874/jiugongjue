using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressablesExample : MonoBehaviour
{
    public string addressableAssetName; // The address or key of the asset

    void Start()
    {
        // Load the asset asynchronously
        Addressables.LoadAssetAsync<GameObject>(addressableAssetName).Completed += OnAssetLoaded;
    }

    private void OnAssetLoaded(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            // Instantiate the asset
            Instantiate(obj.Result, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Failed to load the addressable asset.");
        }
    }
}
