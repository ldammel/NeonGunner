using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SnapshotMode : MonoBehaviour
{
    [SerializeField]
    private bool useCanvas = true;

    [SerializeField]
    private SnapshotCanvas snapshotCanvasPrefab;

    private SnapshotCanvas snapshotCanvas;
    
    private Shader neonShader;
    private Shader bloomShader;


    private List<SnapshotFilter> filters = new List<SnapshotFilter>();

    private int filterIndex = 0;

    private void Awake()
    {
        // Add a canvas to show the current filter name and the controls.
        if (useCanvas)
        {
            snapshotCanvas = Instantiate(snapshotCanvasPrefab);
        }

        // Find all shader files.
        neonShader = Shader.Find("Snapshot/Neon");
        bloomShader = Shader.Find("Snapshot/Bloom");

        // Create all filters.
        filters.Add(new NeonFilter("Neon", Color.cyan, bloomShader, 
            new BaseFilter("", Color.white, neonShader)));
        filters.Add(new BloomFilter("Bloom", Color.white, bloomShader));
    }

    private void Update()
    {
        int lastIndex = filterIndex;

        // Change the filter name when appropriate.
        if(useCanvas && lastIndex != filterIndex)
        {
            snapshotCanvas.SetFilterProperties(filters[filterIndex]);
        }
    }

    // Delegate OnRenderImage() to a SnapshotFilter object.
    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        filters[filterIndex].OnRenderImage(src, dst);
    }
}
