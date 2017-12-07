using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalTapOnColliderController : MonoBehaviour
{
    private const float RaycastDistance = Mathf.Infinity;

    [System.Serializable]
    private class LayerMaskHitEvent
    {
        [SerializeField]
        private string name;

        [SerializeField]
        private LayerMask layerMask;

        [SerializeField]
        private UnityEvent hitEvent;

        public LayerMask LayerMask { get { return layerMask; } }
        public UnityEvent HitEvent { get { return hitEvent; } }
    }

    [SerializeField]
    LayerMaskHitEvent[] layerMaskHitEvents;

    //Cache
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

        for (int i = 0; i < layerMaskHitEvents.Length; i++)
        {
            LayerMaskHitEvent layerMaskHitEvent = layerMaskHitEvents[i];

            if (Physics.Raycast(ray, out hit, RaycastDistance, layerMaskHitEvent.LayerMask))
            {
                if (layerMaskHitEvent.HitEvent != null) layerMaskHitEvent.HitEvent.Invoke();
                break;
            }
        }
    }
}
