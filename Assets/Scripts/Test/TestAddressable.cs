using System;
using System.Threading.Tasks;

namespace Test
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.ResourceManagement.AsyncOperations;

    public class TestAddressable : MonoBehaviour
    {
        // Start is called before the first frame update
        async void Awake()
        {
            Debug.Log("异步操作开始");
            await MyAsyncMethod();
            Debug.Log("异步操作完成");
        }
        
        private async Task MyAsyncMethod()
        {
            // 模拟一个耗时操作
            await Task.Delay(2000); // 等待 2 秒
            Debug.Log("在 MyAsyncMethod 中的异步操作");
        }
        

        void Start()
        {
             StartCoroutine(LoadMyAsset2());
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
        
        // Update is called once per frame
        IEnumerator LoadMyAsset2()
        {
            // 异步加载资源
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>("Prefeab/Card");
            
                
            //Task<>  用task去写
            
            // 等待加载完成
            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                // 加载成功
                GameObject myAsset = handle.Result;
                Debug.Log("Asset loaded successfully!");

                // 你可以在这里使用加载的资源，例如实例化它
                var obj = Instantiate(myAsset, this.transform);
                     
                     //Instantiate(myAsset);

                 obj.transform.parent = this.transform;
                 // 当不再需要资源时，释放它
                 // Addressables.Release(handle);
            }
            else
            {
                // 加载失败
                Debug.LogError("Failed to load the asset.");
            }
        }
        
    }

}