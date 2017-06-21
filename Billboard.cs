using UnityEngine;

public class Billboard : MonoBehaviour
{
    [Header("Optional Field")]
    [SerializeField]
    private Camera _camera;

    private void Start()
    {
        if(_camera == null) _camera = Camera.main;

        if (_camera.orthographic)
            transform.LookAt(transform.position - _camera.transform.forward, _camera.transform.up);
        else
            transform.LookAt(_camera.transform.position, _camera.transform.up);
    }
}