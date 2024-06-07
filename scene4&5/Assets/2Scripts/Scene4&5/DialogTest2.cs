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

		// ù ��° ��� �б� ����
		yield return new WaitUntil(()=>dialogSystem04.UpdateDialog());

		// ��� �б� ���̿� ���ϴ� �ൿ�� �߰��� �� �ִ�.
		textCountdown.gameObject.SetActive(true);
		int count = 3;
		while ( count > 0 )
		{
			textCountdown.text = "�ݼ��� �����̴� �ٽ� ������ ���ư��ϴ�....      " + count.ToString();
			count --;

			yield return new WaitForSeconds(1);
		}
		textCountdown.gameObject.SetActive(false);

		// �� ��° ��� �б� ����
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

