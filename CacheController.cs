using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class CacheController<T,Temp>
{

    private LinkedList<T> enableList;
    private LinkedList<T> AllList;
    private LinkedList<T> BeUseList;

    private Temp _m_tTemp;
    private int _m_iMaxNum;

    public CacheController(T _t, Temp _temp)
    {
        _m_tTemp = _temp;
        enableList = new LinkedList<T>();
        AllList = new LinkedList<T>();
        BeUseList = new LinkedList<T>();
    }
        
    public void init(int _minNum, int _maxNum)
    {
        _m_iMaxNum = _maxNum;
        if (_m_tTemp != null)
        {
            Debug.LogError("cachecontroller has been created.");
            return;
        }

        for (int i =0; i<_minNum;i++)
        {
            T t = createItem(_m_tTemp);
            AllList.AddLast(t);
            enableList.AddLast(t);
        }
    }

    public void discard()
    {
        for (int i =0;i<AllList.Count;i++)
        {
            T temp = AllList.First.Value;
            discardItem(temp);
            AllList.RemoveFirst();
        }

        AllList.Clear();
        enableList.Clear();
        BeUseList.Clear();
    }

    public T popItem()
    {
        if (enableList.Count > 0)
        {
            BeUseList.AddLast(enableList.First.Value);
            enableList.RemoveFirst();
            return BeUseList.Last.Value;
        }
        AllList.AddLast(createItem(_m_tTemp));
        BeUseList.AddLast(AllList.Last.Value);
        return BeUseList.Last.Value;
    }

    public void pushBackItem(T _t)
    {
        if (_t == null)
        {
            Debug.LogError("push back Item is null");
            return;
        }

        BeUseList.Remove(_t);
        if(AllList.Count > _m_iMaxNum)
        {
            Debug.LogError("discard" + _m_iMaxNum);
            AllList.Remove(_t);
            discardItem(_t);
        }else
        {
            resetItem(_t);
            enableList.AddLast(_t);
            BeUseList.Remove(_t);
        }
        //Debug.LogWarning("已放回对象池");
    }

    public abstract void discardItem(T _t);
    public abstract T createItem(Temp _temp);
    public abstract void resetItem(T _t);
}
