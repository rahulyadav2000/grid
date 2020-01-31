using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool walkable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if(walkable == true)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (walkable== false)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
