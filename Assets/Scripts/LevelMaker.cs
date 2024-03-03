using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaker : MonoBehaviour {

    public GameObject BrickPrefab;
    // prefabs的父类：Bricks1和Bricks2
    public GameObject Bricks1;
    public GameObject Bricks2;
    
    // 存储关卡中砖块生成bool数据
    private bool[,] mapData1;
    private bool[,] mapData2;

    public int mapWidth = 12;
    public int mapLength = 14;
    // 砖块生成边界位置
    public float brick1_min_x = -27f;
    public float brick2_min_x = 15f;
    public float brick_min_z = 1f;
    public float brick_y = -0.76f;

    static readonly System.Random random = new System.Random();

    void Start() {
        mapData1 = GenerateBricksData(false);
        mapData2 = GenerateBricksData(true);

        for (int x = 0; x < mapWidth; x++) {
            for (int z = 0; z < mapLength; z++) {
                // Player1's bricks
                if (mapData1[x, z]) {
                    CreateChildPrefab(BrickPrefab, Bricks1, x * 1 + brick1_min_x, brick_y, z * 2 + brick_min_z);
                }
                // Player2's bricks
                if (mapData2[x, z]) {
                    CreateChildPrefab(BrickPrefab, Bricks2, x * 1 + brick2_min_x, brick_y, z * 2 + brick_min_z);
                }
            }
        }
    }

    void Update() {
        
    }

    // TODO: 公平性问题：Player1和Player2的bricksMap不一样
    bool[,] GenerateBricksData(bool isReversed) {
        // 存储每个位置是否有砖块的数据,初始化为全0
        bool[,] data = new bool[mapWidth, mapLength];
        for (int y = 0; y < mapWidth; y++) {
            for (int x = 0; x < mapLength; x++) {
                data[y, x] = false;
            }
        }

        for (int y = 0; y < mapWidth; y++) {
            // 是否启用跳过模式（隔块放置）
            bool skipPattern = random.Next(1, 3) == 1;
            bool skipFlag = random.Next(1, 3) == 1;

            for (int x = 0; x < mapLength; x++) {
                if (skipFlag && skipPattern) {
                    skipFlag = !skipFlag;
                    continue;
                } else {
                    skipFlag = !skipFlag;
                }

                // 放置砖块
                data[y, x] = true;
            }
        }

        // 是否反转（Player2需反转）
        if (isReversed) {
            for (int y = 0; y < mapWidth / 2; y++) {
                int r_y = mapWidth - y - 1;
                for (int x = 0; x < mapLength; x++) {
                    bool temp = data[y, x];
                    data[y, x] =  data[r_y, x];
                    data[r_y, x] = temp;
                }
            }
        }
        return data;
    }

    // 创建child预制件
    void CreateChildPrefab(GameObject prefab, GameObject parent, float x, float y, float z) {
        var myPrefab = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
        myPrefab.transform.parent = parent.transform;
    }
}
