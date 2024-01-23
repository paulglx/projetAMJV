using UnityEditor;
using UnityEngine;

public static class Extensions
{
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        if (gameObject.TryGetComponent<T>(out T t))
        {
            Debug.Log("GET: " + gameObject.name + " has got a " + typeof(T) + " so I get it");
            return t;
        }
        else
        {
            Debug.Log("ADD: " + gameObject.name + " has no " + typeof(T) + " so I create it");
            return gameObject.AddComponent<T>();
        }
    }
}