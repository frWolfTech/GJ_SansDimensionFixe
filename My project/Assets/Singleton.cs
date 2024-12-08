using UnityEngine;

public class SingletonGlobal : MonoBehaviour
{
    private static SingletonGlobal instance;

    public static SingletonGlobal Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject("SingletonGlobal");
                instance = singletonObject.AddComponent<SingletonGlobal>();
                DontDestroyOnLoad(singletonObject);
            }
            return instance;
        }
    }

    public bool hasChomper = false;
    public bool hasFlameThrower = false;
    public bool hasEraser = false;
}
