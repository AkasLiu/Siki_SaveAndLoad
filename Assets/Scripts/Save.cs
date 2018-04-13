using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Save类 定义了需要保存的数据
[System.Serializable]
public class Save{

    public List<int> livingTargetPositions = new List<int>();
    public List<int> livingMonsterTypes = new List<int>();

    public int shootNum = 0;
    public int score = 0;
}
