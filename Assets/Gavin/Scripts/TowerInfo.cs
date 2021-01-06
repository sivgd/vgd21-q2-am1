using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo : MonoBehaviour
{
    public Camera camera;

    public GameObject towerInfo;

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

            GameObject tower = GetTower(position);

            if (tower != null)
            {
                towerInfo.SetActive(true);
            }
            else
            {
                towerInfo.SetActive(false);
            }
        }
    }
    GameObject GetTower(Vector2 pos)
    {
        RaycastHit2D ray = Physics2D.Raycast(pos, Vector2.zero);
        if (ray.collider != null)
        {
            if (ray.collider.gameObject.tag == "TowerSelect")
            {
                return ray.collider.transform.parent.gameObject;
            }
        }
        return null;
    }
}
