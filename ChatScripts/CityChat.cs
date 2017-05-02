using UnityEngine;
using System.Collections;

public class CityChat : ChatTextController
{
    void Awake()
    {
        mData = new string[5]{"大姐头：我晕怎么画风变得这么快，今年流行工业风么！",
        "颓废翔：哇，是谁跟不上潮流还不懂礼貌大喊大叫，打扰我睡觉！！",
        "大姐头：狗贼，终于找到你了，今天不能再让你跑了。",
        "颓废翔：妈呀，阴魂不散，幸好我这有无数陷阱。\n小的们，拿下！",
        "大姐头：谢谢提醒，看我用小拳拳锤你胸口！！！(✿◡‿◡)"};
    }
}
