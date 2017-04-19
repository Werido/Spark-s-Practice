using UnityEngine;
using System.Collections;

public class JoyStick : MonoBehaviour
{
    private bool IsPress = false;
    private Transform button;
    public static float h = 0;
    public static float v = 0;

    void Awake()
    {
        button = transform.Find("Button");
    }
    void OnPress(bool isPress)
    {
        this.IsPress = isPress;
        if (isPress==false)
        {
            //点击抬起后Button坐标归零，x，y方向偏移量归零
            button.localPosition = Vector3.zero;
            h = 0;
            v = 0;
        }
    }

    void Update()
    {
        if (IsPress)
        {
            //调整摇杆中心的局部坐标
            Vector2 touchPos = UICamera.lastTouchPosition;
            //摇杆起始感应范围
            if (touchPos.x < 400)
            {
                touchPos -= new Vector2(124, 121);
                float distance = Vector2.Distance(Vector2.zero, touchPos);
                if (distance > 110)
                {
                    touchPos = touchPos.normalized * 110;
                    button.localPosition = touchPos;
                }
                else
                {
                    //把触摸的位置直接设置给Button
                    button.localPosition = touchPos;
                }

                //得到-1到1间的值
                h = touchPos.x / 110;
                v = touchPos.y / 110;
            }
        }
    }
}
