#define VERBOSE

using UnityEngine;
using UnityEngine.Events;

public class TapOnColliderController : MonoBehaviour
{
    private const float RaycastDistance = Mathf.Infinity;

    [SerializeField]
    private UnityEvent OnTapped;

    private Collider _collider;
    private Camera _camera;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _camera = Camera.main;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) HandleInputPos(Input.mousePosition);
#elif UNITY_ANDROID || UNITY_IOS

        Touch touch = Input.GetTouch(0);

        if(touch.phase == TouchPhase.Began)
        {
            HandleInputPos(touch.position);
        }
#endif
    }

    private void HandleInputPos(Vector3 screenPos)
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        if (_collider.Raycast(ray, out hit, RaycastDistance))
        {
#if VERBOSE
            Debug.LogFormat("TapOnColliderController tapped on: {0} pos: {1} ", hit.collider.gameObject.name, hit.point);
#endif

            if (OnTapped != null) OnTapped.Invoke();
        }
    }

}