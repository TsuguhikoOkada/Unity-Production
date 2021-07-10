using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
	public static float CountDownTime;  // �J�E���g�_�E���^�C��
	public Text TextCountDown;              // �\���p�e�L�X�gUI

	// Use this for initialization
	void Start()
	{
		CountDownTime = 60.0F;  // �J�E���g�_�E���J�n�b�����Z�b�g
	}

	// Update is called once per frame
	void Update()
	{
		// �J�E���g�_�E���^�C���𐮌`���ĕ\��
		TextCountDown.text = String.Format("Time: {0:00.00}", CountDownTime);
		// �o�ߎ����������Ă���
		CountDownTime -= Time.deltaTime;
		// 0.0�b�ȉ��ɂȂ�����J�E���g�_�E���^�C����0.0�ŌŒ�i�~�܂����悤�Ɍ�����j
		if (CountDownTime <= 0.0F)
		{
			CountDownTime = 0.0F;
		}
	}
}
