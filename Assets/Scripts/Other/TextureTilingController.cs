using UnityEngine;
using System.Collections;
using UnityEditor;

/** This script handles individual texture tiling for quad barriers.
 *  @author Eduard
 */
[ExecuteInEditMode]
public class TextureTilingController : MonoBehaviour
{
    /** Texture that should be tiled */
    public Material baseMaterial;

    /** Texture to mesh ratio */
    public Vector3 textureToMesh = Vector3.one;

    /** child quad objects */
    private Renderer[] quads;
    private Vector3 prevScale, prevTextureToMesh;

    /** Manually initialize and retain unique material instances for 
     *  each child quad object to prevent memory leaks. */
    void Awake()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            Material newMaterial = new Material(baseMaterial);
            newMaterial.name = newMaterial.name + " (Instance from TextureTilingInit)";
            renderer.material = newMaterial;
        }
    }

    /** Initialize variables and tiling. */
    void Start()
    {
        quads = GetComponentsInChildren<Renderer>();
        prevScale = gameObject.transform.lossyScale;
        prevTextureToMesh = textureToMesh;
        UpdateTiling();
    }

    /** Check for updates in properties and update tiling accordingly. */
    void Update()
    {
        if (gameObject.transform.lossyScale != prevScale || prevTextureToMesh != textureToMesh)
        {
            // if either the barrier scale changes or texture to mesh variables are changed, preserve changes and update tiling
            prevScale = gameObject.transform.lossyScale;
            prevTextureToMesh = textureToMesh;
            UpdateTiling();
        }
    }

    /** Updates the texture tiling for each child quad proportional 
     *  to the respective barrier dimensions to prevent squeezed textures. */
    void UpdateTiling()
    {
        if (quads != null)
            foreach(Renderer quad in quads)
            {
                switch (quad.name)
                {
                    case "quad_x":
                        quad.sharedMaterial.mainTextureScale = new Vector2(
                            gameObject.transform.lossyScale.z / textureToMesh.z,
                            gameObject.transform.lossyScale.y / textureToMesh.y);
                            break;
                    case "quad_y":
                        quad.sharedMaterial.mainTextureScale = new Vector2(
                            gameObject.transform.lossyScale.x / textureToMesh.x,
                            gameObject.transform.lossyScale.z / textureToMesh.z);
                        break;
                    case "quad_z":
                        quad.sharedMaterial.mainTextureScale = new Vector2(
                            gameObject.transform.lossyScale.x / textureToMesh.x,
                            gameObject.transform.lossyScale.y / textureToMesh.y);
                        break;
                    default:
                        break;
                }
            }
    }
}
