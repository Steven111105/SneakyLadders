using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoardDataSO", menuName = "ScriptableObjects/BoardDataSO")]
public class BoardDataSO : ScriptableObject
{
    [System.Serializable]
    public struct Objects
    {
        public int startPos;
        public int endPos;
    }

    public List<Objects> snakes = new List<Objects>();
    public List<Objects> ladders = new List<Objects>();
    
    public List<int> redTiles = new List<int>();
    public List<int> blueTiles = new List<int>();
    public List<int> greenTiles = new List<int>();
    public List<int> yellowTiles = new List<int>();
    public List<int> whiteTiles = new List<int>();
}
