using System;
using DG.Tweening;
using UnityEngine;

public class Camerashaker : MonoBehaviour
{
    [SerializeField] Transform _camera;
    [SerializeField] Vector3 pos;
    [SerializeField] Vector3 rot;

    private static event Action Shake;

    public static void Invoke()
    {
        Shake?.Invoke();
    }

    private void OnEnable() => Shake += CameraShake;
    private void OnDisable() => Shake -= CameraShake;

    private void CameraShake()
    {
        _camera.DOComplete();
        _camera.DOShakePosition(0.3f, pos);
        _camera.DOShakeRotation(0.3f, rot);
    }
}
