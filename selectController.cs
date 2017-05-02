using UnityEngine;
using System.Collections.Generic;
using System;

[System.Serializable]
public class gostruct
{
    public GameObject go;
    public List<GameObject> character;
}

public class selectController : MonoBehaviour
{
    string[] strArr = { "理工枪王蔡0君", "最强刺客杨S鹏", "最弱战士陈小勇" };
    public List<gostruct> gostructs;
    private gostruct tempStruct;
    private int goIndex = 0;
    private int characterIndex = 0;
    public UILabel introduceLabel;

    void Update()
    {
        //旋转角度（增加）
        transform.Rotate(new Vector3(0, 1f, 0));
    }

    void Start()
    {
        tempStruct = gostructs[0];
        introduceLabel.text = strArr[0];
    }

    public void turnLeft()
    {
        goIndex--;
        if (goIndex < 0)
            goIndex = 0;
        setGoSelecte(gostructs, goIndex);
        MenuController._instance.goindex = goIndex;
        introduceLabel.text = strArr[goIndex];
    }

    public void turnRight()
    {
        goIndex++;
        if (goIndex > gostructs.Count-1)
            goIndex = gostructs.Count-1;
        setGoSelecte(gostructs, goIndex);
        MenuController._instance.goindex = goIndex;
        introduceLabel.text = strArr[goIndex];
    }

    //遍历Go设置显影
    private void setGoSelecte(List<gostruct> _List, int _index)
    {
        for (int i = 0; i < _List.Count; i++)
        {
            if (i != _index)
                _List[i].go.SetActive(false);
            else
                _List[i].go.SetActive(true);
        }
        tempStruct = _List[_index];

    }

    //遍历Character设置显影
    private void setCharacterSelecte(List<GameObject> _List, int _index)
    {
        for (int i = 0; i < _List.Count; i++)
        {
            if (i != _index)
                _List[i].SetActive(false);
            else
                _List[i].SetActive(true);
        }
    }

    public void turnNext()
    {
        characterIndex++;
        if (characterIndex > tempStruct.character.Count-1)
            characterIndex = tempStruct.character.Count-1;
        MenuController._instance.characterindex = characterIndex;
        setCharacterSelecte(tempStruct.character, characterIndex);
    }

    public void turnLast()
    {
        characterIndex--;
        if (characterIndex < 0)
            characterIndex = 0;
        MenuController._instance.characterindex = characterIndex;
        setCharacterSelecte(tempStruct.character, characterIndex);
    }
}

