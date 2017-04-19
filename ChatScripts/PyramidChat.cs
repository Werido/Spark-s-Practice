using UnityEngine;
using System.Collections;

public class PyramidChat : ChatTextController
{
    void Awake()
    {
        mData = new string[3]{"火枪哥：靠，狗脸勇你不是黑暗系的么，怎么老家在埃及╮(╯▽╰)╭\n无所谓了，今天救出公主，顺便带公主游览一下埃及风光~~",
        "狗脸勇：骷髅可杀不可辱。。。。。。。。。\n今天你的对手可不是小喽啰了，让我和你决一死战！",
        "火枪哥：终于要全剧终了，再陪你玩玩吧O(∩_∩)O"};
    }
}
