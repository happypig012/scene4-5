using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogTest2 : MonoBehaviour
{
	[SerializeField]
	private	DialogSystem04	dialogSystem04;
	[SerializeField]
	private	TextMeshProUGUI	textCountdown;
	[SerializeField]
	private	DialogSystem05	dialogSystem05;

	private IEnumerator Start()
	{
		textCountdown.gameObject.SetActive(false);

		// 첫 번째 대사 분기 시작
		yield return new WaitUntil(()=>dialogSystem04.UpdateDialog());

		// 대사 분기 사이에 원하는 행동을 추가할 수 있다.
		textCountdown.gameObject.SetActive(true);
		int count = 3;
		while ( count > 0 )
		{
			textCountdown.text = "반성한 금쪽이는 다시 집으로 돌아갑니다....      " + count.ToString();
			count --;

			yield return new WaitForSeconds(1);
		}
		textCountdown.gameObject.SetActive(false);

		// 두 번째 대사 분기 시작
		yield return new WaitUntil(()=>dialogSystem05.UpdateDialog());

        //textCountdown.gameObject.SetActive(true);

        //yield return new WaitForSeconds(2);

        textCountdown.gameObject.SetActive(true);
        int count1 = 3;
        while (count1 > 0)
        {
			textCountdown.text = "The End  ";
            count1--;

            yield return new WaitForSeconds(1);
        }
        textCountdown.gameObject.SetActive(false);


        UnityEditor.EditorApplication.ExitPlaymode();
	}
}

