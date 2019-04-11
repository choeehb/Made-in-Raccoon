using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssetBundle : MonoBehaviour {

    private static LoadAssetBundle instance;

    public static void LoadLocal(string bundleName, int version, Action<AssetBundle> callback)
        => Load(Application.streamingAssetsPath + "/" + bundleName, version, callback);

    public static void Load(string bundleURL, int version, Action<AssetBundle> callback)
    {
        if (instance == null)
            instance = new GameObject("LoadAssetBundle").AddComponent<LoadAssetBundle>();
        instance.StartCoroutine(instance.DownloadAndCache(bundleURL, version, callback));
    }

    private IEnumerator DownloadAndCache(string bundleURL, int version, Action<AssetBundle> callback)
    {
        while(!Caching.ready)
            yield return null;
        using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL))
        {
            yield return uwr.SendWebRequest();
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);
            callback(bundle);
        }
    }
}
