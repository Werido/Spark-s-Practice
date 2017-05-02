using UnityEngine;
using System.Collections;

public class CampFireChat : ChatTextController
{
    void Awake()
    {
        mData = new string[3]{"大姐头：追了一天累死我了，腿长了不起么/(ㄒoㄒ)/~~\n哇，这里有个营地，小心为上！",
        "颓废翔：哈哈哈哈哈，来不及了，我的马仔们等你好久了！\n早上算是给你点自信心，省得死了跟人说我颓废翔欺负小学生。",
        "大姐头：士可杀不可辱，今晚让你明白！"};
    }
}
