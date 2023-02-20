using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObjectToInstantiate;

    private List<GameObject> placedPrefabList = new List<GameObject>();

    [SerializeField]
    private int maxPrefabSpawnCount = 0;
    private int gameObjectToInstantiateCount;

    private GameObject spawnedObject;
    private ARRaycastManager raycastManager;
    private Vector2 touchPosition;

    static readonly List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }
    
    private bool IsPointerOverUIObjects()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsPointerOverUIObjects())
        {
            if (!TryGetTouchPosition(out Vector2 touchPosition))
            {
                return;
            }

            if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPosition = hits[0].pose;

                if (gameObjectToInstantiateCount < maxPrefabSpawnCount)
                {
                    SpawnPrefab(hitPosition);
                }
            }
        }
    }


    public void SetPrefabType(GameObject prefabType)
    {
        gameObjectToInstantiate = prefabType;
    }

    private void SpawnPrefab(Pose hitPosition)
    {
        spawnedObject = Instantiate(gameObjectToInstantiate, hitPosition.position, hitPosition.rotation);
        placedPrefabList.Add(spawnedObject);
        gameObjectToInstantiateCount++;
    }
}
