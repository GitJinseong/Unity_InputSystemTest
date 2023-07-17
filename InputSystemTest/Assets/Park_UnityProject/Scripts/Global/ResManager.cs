using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResManager : MonoBehaviour
{
    public ItemDrag itemDrag = default;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ResManager 는 Assets 폴더 하위에서 리소스를 모두 찾아오는 역할.");
        Debug.Log("1번째 Call 해야 함.");

        itemDrag.myLogFunc("ResManager에서 로그 찍는 중..");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
