using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public float startTimeBtwSpawn; 
    private float timeBtwSpawn;//time delay giua cac lan spawn

    public GameObject[] enemies;

    public WeaponManager weaponManager;

    //public List<Spawner> spawners;

    private PlayerController player;
    int maxEnemy = 5;
    int roundCount = 0;



    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }


    //Ham GetRandomIndices dung de lấy ngẫu nhiên một số lượng k chỉ số từ 0 đến n - 1 mà không có chỉ số nào lặp lại.
    public List<int> GetRandomIndices(int n, int k)
    {
        //Tạo danh sách chứa tất cả các chỉ số từ 0 đến n-1
        List<int> allIndices = new List<int>();
        for (int i = 0; i < n; i++)
        {
            allIndices.Add(i);
        }

        //Tạo danh sách để lưu các chỉ số ngẫu nhiên:
        List<int> randomIndices = new List<int>();

        //Sử dụng thuật toán Fisher-Yates để xáo trộn ngẫu nhiên các chỉ số:
        int remainingItems = n;
        for (int i = 0; i < k; i++)
        {
            //Với mỗi lần lặp, phương thức chọn một chỉ số ngẫu nhiên từ danh sách các chỉ số còn lại 
            int randomIndex = UnityEngine.Random.Range(0, remainingItems);

            randomIndices.Add(allIndices[randomIndex]);//sau đó thêm chỉ số này vào danh sách

            //Sau đó, phương thức di chuyển chỉ số cuối cùng trong danh sách về vị trí hiện tại của chỉ số được chọn
            //và giảm số lượng các chỉ số còn lại đi một đơn vị
            allIndices[randomIndex] = allIndices[remainingItems - 1];
            remainingItems--;
        }

        return randomIndices;
    }


    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int randEnemyCount = UnityEngine.Random.Range(2, maxEnemy);
            if (weaponManager.Enemies.Count <= 5)
                randEnemyCount = UnityEngine.Random.Range(maxEnemy - 2, maxEnemy);

            List<int> randomIndex = GetRandomIndices(maxEnemy, randEnemyCount);

            foreach (int index in randomIndex)
            {
                int randEnemy = UnityEngine.Random.Range(0, enemies.Length);
                //spawners[index].spawnEnemy(enemies[randEnemy]);
            }
            timeBtwSpawn = startTimeBtwSpawn;

            roundCount++;
            if (roundCount > 10)
            {
                roundCount = 0;
                //maxEnemy = Mathf.Max(spawners.Count, maxEnemy + 1);
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
