using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler   //IPointerClickHandler : 인터페이스
{
    private Canvas uiCanvas = default;
    private RectTransform itemRect = default;

    private GameObject sdPlayer = default;

    private bool isDraging = false;

    public delegate void MyLogFunc(object message);
    public MyLogFunc myLogFunc;

    private System.Action<object, int, int> myAction;
    private delegate void myAction001(object message, int number1, int number2);

    private System.Func<float, float, int, int, string> myFunc;
    private delegate string myFunction001(float f1, float f2, int i1, int i2);

    private void Awake()
    {
        uiCanvas = GFunc.GetRootObj("UiCanvas").GetComponent<Canvas>();
        itemRect = GetComponent<RectTransform>();

        //sdPlayer = GFunc.GetRootObj("Set Costume_03 SD Misaki");
        //GameObject MisakiLeftEye = sdPlayer.FindChildObj("Eye_L");
        //Debug.LogFormat("Misaki is null {0}, Misaki's left eye is null {1}", sdPlayer == null, MisakiLeftEye == null);

        isDraging = false;

        //myLogFunc myLogFunc = Debug.Log;
        // => 이런 형태를 람다식/구문 이라고 한다.
        myLogFunc = (object obj_) =>
        {
            Debug.Log("이 로그가 잘 찍히는지 테스트");
            Debug.Log("넘겨받은 메세지는");
            Debug.Log(obj_);

            Debug.Log("여기서 number 값을 정상적으로 사용할 수 있을까?");
        };

        myLogFunc("이제부터 이 로그 함수는 제 껍니다.");
    }

    // Start is called before the first frame update
    void Start()
    {
        //itemRect.anchoredPosition += new Vector2(100f, 0f);     //앵커드 포지션
        //itemRect.localPosition += new Vector3(100f, 0f,0f);     //로컬 포지션
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 마우스 눌렀을 경우
    public void OnPointerDown(PointerEventData eventData)
    {
        isDraging = true;

        Debug.Log("마우스 왼쪽버튼 클릭한 바로 그 순간");
    }

    // 아이템 드래그 움직이기
    public void OnDrag(PointerEventData eventData)
    {
        if (isDraging == true)
        {
            // LEGACY:
            //itemRect.anchoredPosition += eventData.delta;
            itemRect.anchoredPosition += (eventData.delta / uiCanvas.scaleFactor);

            //Debug.LogFormat("아이콘을 움직일 준비가 되었음. -> {0}", eventData.delta);
        }
    }

    // 마우스 눌렀다 뺏을 경우
    public void OnPointerUp(PointerEventData eventData)
    {
        isDraging = false;
    }

    // 마우스 클릭한 경우
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("이거 함수 만든거 뿐인데 정말로 클릭이 되나??");
    }
}
