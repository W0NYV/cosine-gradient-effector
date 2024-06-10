using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosineGradientEffector : MonoBehaviour
{
    [SerializeField] RenderTexture _in;
    [SerializeField] RenderTexture _out;
    [SerializeField] Material _mat;

    private void Update()
    {
        Graphics.Blit(_in, _out, _mat);
    }
}
