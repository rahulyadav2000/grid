using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public int columns, rows;
    public GameObject Tile;
    // Start is called before the first frame update
    void Start()
    {
        var sprite = Tile.GetComponent<SpriteRenderer>();
        var pixelperunit = sprite.sprite.pixelsPerUnit;
        var width = sprite.sprite.rect.width /pixelperunit;
        var startX = -columns * 0.5f * width+width*0.5f;
        var startY = -rows * 0.5f * width +width*0.5f;
        for (int i=0;i<rows;i++)
        {
            for (int k = 0; k < columns; k++)
            {
                var instance=Instantiate(Tile,new Vector2(startX+(k*width),startY+(i*width)), Quaternion.identity);
                instance.transform.SetParent(transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(point, Camera.main.transform.forward);
            if(hit)
            {
                if (hit.collider.gameObject.GetComponent<Tile>().walkable == false)
                {
                    hit.collider.gameObject.GetComponent<Tile>().walkable = true;
                }
                else if (hit.collider.gameObject.GetComponent<Tile>().walkable == true)
                {
                    hit.collider.gameObject.GetComponent<Tile>().walkable = false;
                }
                
            }
            hit.collider.GetComponent<Tile>().OnClick();

        }
     
    }
}
