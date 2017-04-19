using UnityEngine;
using System.Collections;

public class CityChat : ChatTextController
{
    void Awake()
    {
        mData = new string[5]{"火枪哥：我晕怎么画风变得这么快，今年流行工业风么！",
        "狗脸勇：哇，是谁跟不上潮流还不懂礼貌大喊大叫，打扰我睡觉！！",
        "火枪哥：狗贼，终于找到你了，今天不能再让你跑了。",
        "狗脸勇：妈呀，阴魂不散，幸好我这有无数陷阱。\n小的们，拿下！",
        "火枪哥：谢谢提醒，看我用小拳拳锤你胸口！！！(✿◡‿◡)"};
    }
}
