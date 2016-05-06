using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public List<GameObject> blocks = new List<GameObject>();

    public void AddBlock(GameObject block) {
        blocks.Add(block);
    }

    public void RemoveBlockAt(int index) {
        if (index >= 0 && index <= blocks.Count) {
            blocks.RemoveAt(index);
        }
    }

    public void RemoveBlock(GameObject block) {
        if (blocks.Contains(block)) {
            blocks.Remove(block);
        }
    }

    public GameObject GetBlock(int index) {
        if (index >= 0 && index <= blocks.Count) {
            return blocks[index];
        } else {
            return null;
        }
    }

    public int GetBlocksCount() {
        return blocks.Count;
    }
}
