using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TextureTilingInit : MonoBehaviour
{
    public Material baseMaterial;

    void Awake()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            Material newMaterial = new Material(baseMaterial);
            newMaterial.name = newMaterial.name + " (Instance from TextureTilingInit)";
            renderer.material = newMaterial;
        }
    }
}
