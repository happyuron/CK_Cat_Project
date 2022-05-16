using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;

    [field: SerializeField] bool dontDestroyOnLoad;
    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<T>();
        }
        else
        {
            Debug.LogError($"Failed to Instantiate {typeof(T).Name} since it already exist");
        }


        if (dontDestroyOnLoad)
        {
            T[] tmp = FindObjectsOfType<T>();
            if (tmp.Length > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
