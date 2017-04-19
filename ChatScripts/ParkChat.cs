using UnityEngine;
using System.Collections;

public class ParkChat : ChatTextController
{
    void Awake()
    {
        mData = new string[3]{"火枪哥：大胆狗贼，快把公主放下来！\n今天小爷心情好，饶你一条狗命！",
        "狗脸勇：笑话，我不放又如何！\n今天让你尝尝理工伏地魔的厉害！",
        "火枪哥：哎，看来今天又是一场屠杀！"};
    }
}
