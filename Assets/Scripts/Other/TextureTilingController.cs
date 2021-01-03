using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TextureTilingController : MonoBehaviour
{

    public Vector3 textureToMesh = Vector3.one;

    private Renderer[] quads;

    Vector3 prevScale = Vector3.one;
    Vector3 prevTextureToMesh = Vector3.one;

    void Start()
    {
        prevScale = gameObject.transform.lossyScale;
        prevTextureToMesh = textureToMesh;
        quads = GetComponentsInChildren<Renderer>();

        this.UpdateTiling();
    }

    void Update()
    {
        // If something has changed
        if (gameObject.transform.lossyScale != prevScale || prevTextureToMesh != textureToMesh)
            this.UpdateTiling();

        // Maintain previous state variables
        this.prevScale = gameObject.transform.lossyScale;
        prevTextureToMesh = textureToMesh;
    }

    [ContextMenu("UpdateTiling")]
    void UpdateTiling()
    {
        // Figure out texture-to-mesh width based on user set texture-to-mesh height
        //float textureToMeshX = ((float)this.texture.width / this.texture.height) * this.textureToMeshZ;

        if (quads != null)
        foreach(Renderer quad in quads)
        {
            switch (quad.name)
            {
                case "quad_x":
                    quad.material.mainTextureScale = new Vector2(
                        gameObject.transform.lossyScale.z / textureToMesh.z,
                        gameObject.transform.lossyScale.y / textureToMesh.y);
                        break;
                case "quad_y":
                    quad.material.mainTextureScale = new Vector2(
                        gameObject.transform.lossyScale.x / textureToMesh.x,
                        gameObject.transform.lossyScale.z / textureToMesh.z);
                    break;
                case "quad_z":
                    quad.material.mainTextureScale = new Vector2(
                        gameObject.transform.lossyScale.x / textureToMesh.x,
                        gameObject.transform.lossyScale.y / textureToMesh.y);
                    break;
                default:
                    break;
            }
        }

        
    }
}