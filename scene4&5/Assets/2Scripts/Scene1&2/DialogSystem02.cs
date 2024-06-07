using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem02 : MonoBehaviour
{
	[SerializeField]
	private	Speaker[]		speakers;					// ��ȭ�� �����ϴ� ĳ���͵��� UI �迭
	[SerializeField]
	private	DialogData[]	dialogs;					// ���� �б��� ��� ��� �迭
	[SerializeField]
	private	bool			isAutoStart = true;			// �ڵ� ���� ����
	private	bool			isFirst = true;				// ���� 1ȸ�� ȣ���ϱ� ���� ����
	private	int				currentDialogIndex = -1;	// ���� ��� ����
	private	int				currentSpeakerIndex = 0;	// ���� ���� �ϴ� ȭ��(Speaker)�� speakers �迭 ����
	private	float			typingSpeed = 0.1f;			// �ؽ�Ʈ Ÿ���� ȿ���� ��� �ӵ�
	private	bool			isTypingEffect = false;     // �ؽ�Ʈ Ÿ���� ȿ���� ���������

    private void Awake()
	{
        //AudioSource audioSource = GetComponent<AudioSource>();
        

        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false, i);
            // ĳ���� �̹����� �Ⱥ��̵��� ����
            speakers[i].spriteRenderer.gameObject.SetActive(false);

        }
       // speakers[4].spriteRenderer.gameObject.SetActive(false);

    }

    private void Setup()
	{
        Color color = speakers[4].spriteRenderer.color;
        color.a = 1;
        speakers[4].spriteRenderer.color = color;

        // ��� ��ȭ ���� ���ӿ�����Ʈ ��Ȱ��ȭ
        for ( int i = 0; i < speakers.Length; ++ i )
		{
			SetActiveObjects(speakers[i], false, i);
            // ĳ���� �̹����� �Ⱥ��̵��� ����
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        
			if(i == 4) { speakers[4].spriteRenderer.gameObject.SetActive(false); }
        }
        speakers[2].spriteRenderer.gameObject.SetActive(false);
    }

    public bool UpdateDialog()
	{
		// ��� �бⰡ ���۵� �� 1ȸ�� ȣ��
		if ( isFirst == true )
		{
			// �ʱ�ȭ. ĳ���� �̹����� Ȱ��ȭ�ϰ�, ��� ���� UI�� ��� ��Ȱ��ȭ
			Setup();

			// �ڵ� ���(isAutoStart=true)���� �����Ǿ� ������ ù ��° ��� ���
			if ( isAutoStart ) SetNextDialog();

			isFirst = false;
		}

		if (Input.GetMouseButtonDown(0) )
		{
			// �ؽ�Ʈ Ÿ���� ȿ���� ������϶� ���콺 ���� Ŭ���ϸ� Ÿ���� ȿ�� ����
			if ( isTypingEffect == true )
			{
				isTypingEffect = false;
				
				// Ÿ���� ȿ���� �����ϰ�, ���� ��� ��ü�� ����Ѵ�
				StopCoroutine("OnTypingText");
				speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
				// ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
				speakers[currentSpeakerIndex].objectArrow.SetActive(true);

				return false;
			}

			// ��簡 �������� ��� ���� ��� ����
			if ( dialogs.Length > currentDialogIndex + 1 )
			{
				SetNextDialog();
			}
			// ��簡 �� �̻� ���� ��� ��� ������Ʈ�� ��Ȱ��ȭ�ϰ� true ��ȯ
			else
			{
				// ���� ��ȭ�� �����ߴ� ��� ĳ����, ��ȭ ���� UI�� ������ �ʰ� ��Ȱ��ȭ
				for ( int i = 0; i < speakers.Length; ++ i )
				{
					SetActiveObjects(speakers[i], false, i);
					// SetActiveObjects()�� ĳ���� �̹����� ������ �ʰ� �ϴ� �κ��� ���� ������ ������ ȣ��
					speakers[i].spriteRenderer.gameObject.SetActive(false);
				}

				return true;
			}
		}

		return false;
	}

	private void SetNextDialog()
	{
		// ���� ȭ���� ��ȭ ���� ������Ʈ ��Ȱ��ȭ
		SetActiveObjects(speakers[currentSpeakerIndex], false, currentSpeakerIndex	);
        //speakers[currentSpeakerIndex].spriteRenderer.gameObject.SetActive(false);
        // ���� ��縦 �����ϵ��� 
       
        currentDialogIndex ++;
		

		// ���� ȭ�� ���� ����
		currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;

		if(currentSpeakerIndex == 2)
		{
			speakers[currentSpeakerIndex].spriteRenderer.gameObject.SetActive(true);
		}
        if (currentSpeakerIndex == 4)
        {
			for(int i = 0; i < 4; i++)
			{
				speakers[i].spriteRenderer.gameObject.SetActive(false);
			}
            speakers[currentSpeakerIndex].spriteRenderer.gameObject.SetActive(true);
        }


        // ���� ȭ���� ��ȭ ���� ������Ʈ Ȱ��ȭ
        SetActiveObjects(speakers[currentSpeakerIndex], true, currentSpeakerIndex);
		// ���� ȭ�� �̸� �ؽ�Ʈ ����
		speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;

        if (dialogs[currentDialogIndex].soundEffect != null)
        {
            SoundManager.instance.PlaySound("talk", dialogs[currentDialogIndex].soundEffect);
        }
		//��� �Ҹ� ��� 

        // ���� ȭ���� ��� �ؽ�Ʈ ����
        //speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
        StartCoroutine("OnTypingText");
		//speakers[currentSpeakerIndex].spriteRenderer.gameObject.SetActive(false);


	}

	private void SetActiveObjects(Speaker speaker, bool visible, int index)
	{
		speaker.imageDialog.gameObject.SetActive(visible);
		speaker.textName.gameObject.SetActive(visible);
		speaker.textDialogue.gameObject.SetActive(visible);

		// ȭ��ǥ�� ��簡 ����Ǿ��� ���� Ȱ��ȭ�ϱ� ������ �׻� false
		speaker.objectArrow.SetActive(false);

		
		//speaker.spriteRenderer.gameObject.SetActive(false);
		
		if(index == 2)
		{
			speaker.spriteRenderer.gameObject.SetActive(visible);
		}
	
	}

	private IEnumerator OnTypingText()
	{
		int index = 0;
		
		isTypingEffect = true;

		// �ؽ�Ʈ�� �ѱ��ھ� Ÿ����ġ�� ���
		while ( index < dialogs[currentDialogIndex].dialogue.Length )
		{
			speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue.Substring(0, index);

			index ++;

            typingSpeed = 0.1f;

            yield return new WaitForSeconds(typingSpeed);
		}

		isTypingEffect = false;

		// ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
		speakers[currentSpeakerIndex].objectArrow.SetActive(true);
	}
}

