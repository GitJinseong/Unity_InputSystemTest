using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static partial class GFunc
{
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }


    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {
#if DEBUG_MODE
        Debug.LogWarning(message);
#endif
    }

    //! GameObject �޾Ƽ� Text ������Ʈ ã�Ƽ� text �ʵ� �� �����ϴ� �Լ�
    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if (textComponent == null || textComponent == default) { return; }

        textComponent.text = text;
    }

    // LoadScene �Լ� �����Ѵ�.
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //! Ư�� ������Ʈ�� �ڽ� ������Ʈ�� ��ġ�ؼ� ������Ʈ�� ã���ִ� �Լ�
    public static T FindChildComponent<T>(
        this GameObject targetObj_, string objName_) where T : Component
    {
        T searchResultComponent = default(T);
        GameObject searchResultObj = default(GameObject);

        searchResultObj = targetObj_.FindChildObj(objName_);
        if (searchResultObj != null || searchResultObj != default)
        {
            searchResultComponent = searchResultObj.GetComponent<T>();
        }

        return searchResultComponent;
    }   // FindChildComponent()

    //! Ư�� ������Ʈ�� �ڽ� ������Ʈ�� ��ġ�ؼ� ã���ִ� �Լ�
    //�˰����� : DFS
    public static GameObject FindChildObj(
        this GameObject targetObj_, string objName_)    //����Լ�
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;

        for (int i = 0; i < targetObj_.transform.childCount; i++)
        {
            searchTarget = targetObj_.transform.GetChild(i).gameObject;
            if (searchTarget.name.Equals(objName_))
            {
                searchResult = searchTarget;
                return searchResult;
            }       //if : ���� ã�� ���� ������Ʈ�� ã�� ���
            else
            {
                searchResult = FindChildObj(searchTarget, objName_);

                if (searchResult == null || searchResult == default) { /*Pass*/}
                else { return searchResult; }
            }       //else : ���� ã�� ���� ������Ʈ�� ���� ��ã�� ���
        }   //loop: Ž�� Ÿ�� ������Ʈ�� �ڽ� ������Ʈ ������ŭ ��ȸ�ϴ� ����

        return searchResult;
    }       //FindChildObj()

    // ���� ���� �̸��� �����Ѵ�.
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    //! Ȱ��ȭ �� ���� ���� ��Ʈ ������Ʈ�� ��ġ�ؼ� ã���ִ� �Լ�
    public static GameObject GetRootObj(string objName_)
    {
        Scene activeScene_ = SceneManager.GetActiveScene();
        GameObject[] rootObjs_ = activeScene_.GetRootGameObjects();

        GameObject targetObj_ = default;
        foreach (GameObject rootObj_ in rootObjs_)
        {
            if (rootObj_.name.Equals(objName_))
            {
                targetObj_ = rootObj_;
                return targetObj_;
            }
            else { continue; }
        }

        return targetObj_;
        // GetRootObj_;
    }


    //! �� ���͸� ���Ѵ�.
    // this Vector3 origin�� ScrollingObject���� transforn.position�� ���Ѵ�.
    public static Vector2 AddVector(this Vector3 origin, Vector2 addVector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addVector;
        return result;
    }

    //! ������Ʈ�� �����ϴ��� ���θ� üũ�ϴ� �Լ�
    public static bool IsValid<T>(this T target) where T : Component
    {
        if (target == null || target == default) { return false; }
        else { return true; }
    }

    //! ����Ʈ�� ��ȿ���� ���θ� üũ�ϴ� �Լ�
    public static bool IsValid<T>(this List<T> target)
    {
        bool isInvalid = (target == null || target == default);
        isInvalid = isInvalid || target.Count == 0;

        if (isInvalid == true) { return false; }
        else { return true; }
    }
}