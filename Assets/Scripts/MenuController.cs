using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	//AboutImage组件
	public GameObject AboutImage;

	//声明用来接收
    public	Slider slider;

	//声明退出游戏按钮
	public Button ExitGameBtn;

	//声明关于按钮
	public Button AboutBtn;

	//进度条开关
	bool Load =false;

	//继续暂停游戏
	public Text ControlTimeBtn;

	//继续暂停 开关
	bool ConTimeState = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Load==true)
			slider.value += 0.5f;
		if (slider.value >= 100f)
			Invoke("ChangeScen", 1f);
	}

	//打开关于作者
	public void AboutBtnClick()
    {
		AboutImage.SetActive(true);
    }

	//关闭关于作者
	public void ExitBtnClick()
	{
		AboutImage.SetActive(false);
	}

	//加载进入游戏场景
	public void StartGameBtnClick()
	{
		EnemyInfo.num = 0;
		//当点击进入游戏按钮，禁用其他按钮
		ExitGameBtn.interactable = false;
		AboutBtn.interactable = false;
		//进度条进行加载
		Load = true;
	}

	//跳转游戏场景
	void ChangeScen()
    {
		//跳转游戏场景
		SceneManager.LoadScene(1);
	}

	//重新开始游戏跳转场景
	public void RePlayGameBtnClick()
	{
		//防止暂停时返回场景所以当返回主界面时
		//将时间控制恢复正常
		Time.timeScale = 1.0f;
		//跳转到菜单场景
		SceneManager.LoadScene(0);
	}

	//退出游戏
	public void ExitGameBtnClick()
    {
		//未打包情况下的退出程序
		//UnityEditor.EditorApplication.isPlaying = false;

		//退出程序
		Application.Quit();
    }

	//继续游戏/暂停游戏
	public void ControlTimeClick()
	{
        if (ConTimeState)
        {
			ConTimeState = false;
			Time.timeScale = 1.0f;
			ControlTimeBtn.text = "暂停游戏";
        }
        else
        {
			ConTimeState = true;
			Time.timeScale = 0f;
			ControlTimeBtn.text = "继续游戏";
		}
	}
}
