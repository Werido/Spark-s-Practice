using UnityEngine;
using System.Collections;

public class DungeonChat : ChatTextController
{
    void Awake()
    {
        mData = new string[3]{"火枪哥：小样，你的小喽啰都太菜了！\n今天小爷心情好，乖乖交出公主饶你一条狗命！",
        "狗脸勇：笑话，我不放又如何！\n今天让你尝尝理工伏地魔的厉害！",
        "火枪哥：哎，看来今天又是一场屠杀！"};
    }
}
