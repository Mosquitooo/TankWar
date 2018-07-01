using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour {

    // 0：老家 1: 墙 2：障碍 3：敌人4:河流 5: 草 6: 空气墙
    public GameObject[] mapItem;

    private List<Vector3> ItemPosList = new List<Vector3>();
    private Vector3 vPos = new Vector3(0, 0, 0);

    private void Awake()
    {
        print("private void Awake");
        // 实例化老家
        CreateItem(mapItem[0], new Vector3(0, -8, 0), Quaternion.identity);

        // 实例化老家围墙
        CreateItem(mapItem[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(mapItem[1], new Vector3(1, -8, 0), Quaternion.identity);
        for(int i = -1; i <= 1; ++i)
        {
            CreateItem(mapItem[1], new Vector3(i, -7, 0), Quaternion.identity);
        }

        // 创建空气墙
        for(int i = -11; i < 12; ++i)
        {
            CreateItem(mapItem[6], new Vector3(i, -9, 0), Quaternion.identity);
            CreateItem(mapItem[6], new Vector3(i, 9, 0), Quaternion.identity);
        }

        for (int i = -8; i < 9; ++i)
        {
            CreateItem(mapItem[6], new Vector3(-11, i, 0), Quaternion.identity);
            CreateItem(mapItem[6], new Vector3(11, i, 0), Quaternion.identity);
        }

        // 创建地图
        for (int i = 0; i < 25; ++i)
        {
            CreateItem(mapItem[1], CreateRandonPos(), Quaternion.identity);
            CreateItem(mapItem[2], CreateRandonPos(), Quaternion.identity);
            CreateItem(mapItem[4], CreateRandonPos(), Quaternion.identity);
            CreateItem(mapItem[5], CreateRandonPos(), Quaternion.identity);
        }

        // 创建敌人
        InvokeRepeating("CreateEnemy", 1, 5);
    }

    //创建地图元素
    private void CreateItem(GameObject obj, Vector3 position, Quaternion rotation)
    {
        GameObject item = Instantiate(obj, position, rotation);
        item.transform.SetParent(gameObject.transform);
        ItemPosList.Add(position);
    }

    //选择随机位置
    private Vector3 CreateRandonPos()
    {
        while(true)
        {
            vPos.Set(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if(!HasThePos(vPos))
            {
                return vPos;
            }
        }
    }

    // 标记位置
    private bool HasThePos(Vector3 Pos)
    {
        for(int i = 0; i < ItemPosList.Count; ++i)
        {
            if(ItemPosList[i] == Pos)
            {
                return true;
            }
        }

        return false;
    }

    private void CreateEnemy()
    {
        int Idx = Random.Range(0, 3);
        Vector3 Pos = new Vector3(0,0,0);
        if(Idx == 0)
        {
            Pos.Set(-10, 8, 0);
        }
        else if(Idx == 1)
        {
            Pos.Set(0, 8, 0);
        }
        else
        {
            Pos.Set(10, 8, 0);
        }

        CreateItem(mapItem[3], Pos, Quaternion.identity);
    }
}
