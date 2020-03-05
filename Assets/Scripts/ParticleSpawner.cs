using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public GameObject SpawnedParticlePrefab;
    public Canvas OwnerCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var clickedPosition = Input.mousePosition;
            var newPrehub = Instantiate(SpawnedParticlePrefab);

            Vector2 localPoint;
            var canvasRect = OwnerCanvas.GetComponent<RectTransform>();

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, clickedPosition, OwnerCanvas.worldCamera, out localPoint);

            newPrehub.transform.SetParent(this.transform, false);
            var pos = newPrehub.GetComponent<RectTransform>().anchoredPosition;

            newPrehub.GetComponent<RectTransform>().anchoredPosition = localPoint;
            newPrehub.SetActive(true);
        }
    }
}
