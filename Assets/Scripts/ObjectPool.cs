﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool Instance;
    public static ObjectPool instance
    {
        set 
        {
            if (Instance == null)
                instance = value; 
        }
        get { return Instance; }
    }

    public enum OBJECT_TYPE
    {
        JEM
    };

    public Transform objectTr;

    // public GameObject jem_prefab;

    // Queue<JemObject> jem_queue = new Queue<JemObject>();

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 현재 오브젝트 풀에서 꺼내 쓸 자원이 없을 경우 새로운 오브젝트를 풀에 추가하는 함수
    /// </summary>
    /// <param name="type">생성할 오브젝트 종류</param>
    /// <param name="tr">생성 위치를 위한 부모 Transform</param>
    /// <param name="pos">생성 위치</param>
    private T CreateNewObject<T>(OBJECT_TYPE type, Transform tr, Vector3 pos) where T : MonoBehaviour
    {
        T newObj = null;

        switch (type)
        {
            // case OBJECT_TYPE.JEM: newObj = Instantiate(jem_prefab, pos, Quaternion.identity, tr).GetComponent<T>(); break;
        }

        newObj.gameObject.SetActive(false);
        return newObj;
    }

    /// <summary>
    /// (tr)을 부모 오브젝트로 삼고 (pos) 월드 포지션으로 (type) 종류에 해당하는 오브젝트를 풀에서 꺼내는 함수
    /// </summary>
    /// <param name="type">생성할 오브젝트 종류</param>
    /// <param name="tr">생성 위치를 위한 부모 Transform</param>
    /// <param name="pos">생성 위치</param>
    public static T GetObject<T>(OBJECT_TYPE type, Transform tr, Vector3 pos) where T : MonoBehaviour
    {
        int count = GetCount(type);
        if (count > 0)
        {
            T obj = null;

            switch (type)
            {
                // case OBJECT_TYPE.JEM: obj = instance.jem_queue.Dequeue().GetComponent<T>(); break;
            }

            obj.transform.SetParent(tr);
            obj.transform.position = pos;
            obj.gameObject.SetActive(true);

            return obj;
        }
        else
        {
            var newObj = instance.CreateNewObject<T>(type, tr, pos);
            newObj.transform.SetParent(tr);
            newObj.transform.position = pos;
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    /// <summary>
    /// (type) 종류에 해당하는 (obj) 오브젝트를 풀로 돌려보내는 함수
    /// </summary>
    /// <param name="type">돌려보낼 오브젝트 종류</param>
    /// <param name="obj">오브젝트 풀로 돌려보낼 Instance Object</param>
    public static void ReturnObject<T>(OBJECT_TYPE type, T obj) where T : MonoBehaviour
    {
        if (obj == null)
        {
            Debug.LogError("Return Object is Failed.");
            return;
        }
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(instance.transform);

        switch (type)
        {
            // case OBJECT_TYPE.JEM: instance.jem_queue.Enqueue(obj.GetComponent<JemObject>()); break;
        }
    }

    /// <summary>
    /// 현재까지 풀에 생성된 (type)에 해당하는 오브젝트 개수를 반환하는 함수
    /// </summary>
    /// <param name="type">수를 세릴 오브젝트 종류</param>
    private static int GetCount(OBJECT_TYPE type)
    {
        int count = 0;

        switch (type)
        {
            // case OBJECT_TYPE.JEM: count = instance.jem_queue.Count; break;
        }

        return count;
    }
}
