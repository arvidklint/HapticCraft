using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public List<GameObject> blocks = new List<GameObject>();
    public Transform spawnPos;
    public GameManager gm;

    float timeout = 2;
    bool spawning = false;

    void Start() {
        StartCoroutine(SpawnBlock());
    }

    IEnumerator SpawnBlock() {
        if (spawning == false) {
            spawning = true;
            int randomInt = Random.Range(0, blocks.Count);
            yield return new WaitForSeconds(timeout);
            GameObject block = (GameObject)Instantiate(blocks[randomInt], spawnPos.position, Quaternion.identity);
            block.GetComponent<FalconRigidBody>().bodyId = gm.GetBlocksCount() + 1;
            gm.AddBlock(block);
            spawning = false;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.layer == 8) {
            StartCoroutine(SpawnBlock());
        }
    }
}
