using UnityEngine;
using System.Collections;

public class ParkChat : ChatTextController
{
    void Awake()
    {
        mData = new string[3]{"大姐头：大胆狗贼，快把坤臀放下来！\n今天本大人心情好，饶你一条狗命！",
        "颓废翔：笑话，我不放又如何！\n今天让你尝尝理工伏地魔的厉害！",
        "大姐头：哎，看来今天又是一场屠杀！"};
    }
}
