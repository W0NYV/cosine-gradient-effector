using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosineGradientEffector : MonoBehaviour
{
    [SerializeField] RenderTexture _in;
    [SerializeField] RenderTexture _out;
    [SerializeField] Material _mat;

    private Vector4 _phase;
    private Vector4 _amplitude;
    private Vector4 _freq;
    private Vector4 _offset;

    private void Update()
    {
        Graphics.Blit(_in, _out, _mat);
    }

    public void SetApplyValue(float value)
    {
        _mat.SetFloat("_ApplyValue", value);
    }

    public void SetPhaseR(float value)
    {
        _phase = new Vector4(value, _phase.y, _phase.z, _phase.w);
        _mat.SetVector("_Phase", _phase);
    }

    public void SetPhaseG(float value)
    {
        _phase = new Vector4(_phase.x, value, _phase.z, _phase.w);
        _mat.SetVector("_Phase", _phase);
    }

    public void SetPhaseB(float value)
    {
        _phase = new Vector4(_phase.x, _phase.y, value, _phase.w);
        _mat.SetVector("_Phase", _phase);
    }

    public void SetAmpR(float value)
    {
        _amplitude = new Vector4(value, _amplitude.y, _amplitude.z, _amplitude.w);
        _mat.SetVector("_Amplitude", _amplitude);
    }

    public void SetAmpG(float value)
    {
        _amplitude = new Vector4(_amplitude.x, value, _amplitude.z, _amplitude.w);
        _mat.SetVector("_Amplitude", _amplitude);
    }

    public void SetAmpB(float value)
    {
        _amplitude = new Vector4(_amplitude.x, _amplitude.y, value, _amplitude.w);
        _mat.SetVector("_Amplitude", _amplitude);
    }

    public void SetFreqR(float value)
    {
        _freq = new Vector4(value, _freq.y, _freq.z, _freq.w);
        _mat.SetVector("_Frequency", _freq);
    }

    public void SetFreqG(float value)
    {
        _freq = new Vector4(_freq.x, value, _freq.z, _freq.w);
        _mat.SetVector("_Frequency", _freq);
    }

    public void SetFreqB(float value)
    {
        _freq = new Vector4(_freq.x, _freq.y, value, _freq.w);
        _mat.SetVector("_Frequency", _freq);
    }

    public void SetOffsetR(float value)
    {
        _offset = new Vector4(value, _offset.y, _offset.z, _offset.w);
        _mat.SetVector("_Offset", _offset);
    }

    public void SetOffsetG(float value)
    {
        _offset = new Vector4(_offset.x, value, _offset.z, _offset.w);
        _mat.SetVector("_Offset", _offset);
    }

    public void SetOffsetB(float value)
    {
        _offset = new Vector4(_offset.x, _offset.y, value, _offset.w);
        _mat.SetVector("_Offset", _offset);
    }
}
