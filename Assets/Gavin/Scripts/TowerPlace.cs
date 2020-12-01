using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    public new Camera camera;
    public GameObject roughSlingShotTowerPrefab;
    public Transform towerParent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 offset = new Vector2(0, 0.5f);
            bool canPlace = CheckIfCanPlace(position);
            //print(canPlace);

            if (canPlace)
            {
                Instantiate(roughSlingShotTowerPrefab, position + offset, new Quaternion(), towerParent);
            }
        }

    }

    public bool CheckIfCanPlace(Vector2 position)
    {
        RaycastHit2D ray = Physics2D.Raycast(position, Vector2.zero);
        if (ray.collider == null)
        {
            return true;
        }
        if (ray.collider.name != "RoughMapCantPlaceArea")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
