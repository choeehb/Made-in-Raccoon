using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildAssetBundles : MonoBehaviour {

    private const BuildAssetBundleOptions option    = BuildAssetBundleOptions.None;
    private const BuildTarget buildTarget           = BuildTarget.Android;

    [MenuItem("Bundles/Build AssetBundles")]
    public static void BuildAllAssetBundles()
        => BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", option, buildTarget);

}
