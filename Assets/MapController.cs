using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject room;

    // Start is called before the first frame update
    void Start()
    {
        Random.seed = 1706;
        // Random.seed = 5;
        // Random.seed = 10;
        CreateMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateMap()
    {
        int defaultX = 1;
        int defaultY = 1;
        CreateRom(defaultX, defaultY);
        for (int i = 0; i < 4; i++)
        {
            int tempdefaultX = defaultX;
            int tempdefaultY = defaultY;
            int caveLength = (int)Random.Range(1, 10);
            for (int j = 0; j < caveLength; j++)
            {
                switch (i)
                {
                    case 0:
                        //WEST
                        tempdefaultX += 35;
                        CreateRom(-tempdefaultX, tempdefaultY);
                        break;
                    case 1:
                        //NORTH
                        tempdefaultY += 35;
                        CreateRom(tempdefaultX, tempdefaultY);
                        break;
                    case 2:
                        //EAST
                        tempdefaultX += 35;
                        CreateRom(tempdefaultX, tempdefaultY);
                        break;
                    case 3:
                        //SOUTH
                        tempdefaultY += 35;
                        CreateRom(tempdefaultX, -tempdefaultY);
                        break;
                }
            }
        }
    }

    void CreateRom(int x, int y)
    {
        Instantiate(room, new Vector3(x, y, 1), Quaternion.identity);
    }
}
