using UnityEngine;
using System.Collections;
using UnityEditor;

[ExecuteInEditMode]
public class TextureTilingController : MonoBehaviour
{

    public Vector3 textureToMesh = Vector3.one;

    private Renderer[] quads;
    private Vector3 prevScale = Vector3.one;
    private Vector3 prevTextureToMesh = Vector3.one;

    void Start()
    {
        prevScale = gameObject.transform.lossyScale;
        prevTextureToMesh = textureToMesh;
        quads = GetComponentsInChildren<Renderer>();

        UpdateTiling();
    }

    void Update()
    {
        // If something has changed
        if (gameObject.transform.lossyScale != prevScale || prevTextureToMesh != textureToMesh)
            UpdateTiling();

        // Maintain previous state variables
        prevScale = gameObject.transform.lossyScale;
        prevTextureToMesh = textureToMesh;
    }

    [ContextMenu("UpdateTiling")]
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