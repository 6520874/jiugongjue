namespace Test
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.ResourceManagement.AsyncOperations;

    public class TestAddressable : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
             StartCoroutine(LoadMyAsset());
        }

        IEnumerator LoadMyAsset()
        {
            // 异步加载资源
            AsyncOperationHandle<Material> handle = Addressables.LoadAssetAsync<Material>("MyAsset");
        
            // 等待加载完成
            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                // 加载成功
                Material myAsset = handle.Result;
                Debug.Log("Asset loaded successfully!");

                // 你可以在这里使用加载的资源，例如实例化它
                // Instantiate(myAsset);

                // 当不再需要资源时，释放它
                Addressables.Release(handle);
            }
            else
            {
                // 加载失败
                Debug.LogError("Failed to load the asset.");
            }
        }
    }

}