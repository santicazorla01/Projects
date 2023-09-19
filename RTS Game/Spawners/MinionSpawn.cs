using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawn : MonoBehaviour
{
    [Header("Minions Prefabs")]
    [SerializeField] private GameObject[] minions;

    public float swarmerInterval = 0.5f;
    public Transform spawnerPos;
    float spawnX;
    float spawnY;
    public float offsetX;
    public float offsetY;

    public AgentMovement agentMovement;

    private void Update()
    {
        spawnX = spawnerPos.position.x + offsetX;
        spawnY = spawnerPos.position.y + offsetY;
        
        if (agentMovement.selected)
        {
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                StartCoroutine(spawnMinion(swarmerInterval, minions[0]));
            }
        }
    }

    private IEnumerator spawnMinion(float intreval, GameObject minion){
        yield return new WaitForSeconds(0);
        GameObject newMinion = Instantiate(minion, new Vector3((spawnX), (spawnY), 0), Quaternion.identity);
        //StartCoroutine(spawnMinion(intreval, minion)); ---------------------/To spawn infinite minions
    }

    private void Start() {
        //only test
        
        
    }
}
