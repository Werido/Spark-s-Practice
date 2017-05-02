using UnityEngine;
using System.Collections;

public class DungeonChat : ChatTextController
{
    void Awake()
    {
        mData = new string[3]{"大姐头：小样，你的小喽啰都太菜了！\n今天本大人心情好，乖乖交出坤臀饶你一条狗命！",
        "颓废翔：笑话，我不放又如何！\n今天让你尝尝理工伏地魔的厉害！",
        "大姐头：哎，看来今天又是一场屠杀！"};
    }
}
