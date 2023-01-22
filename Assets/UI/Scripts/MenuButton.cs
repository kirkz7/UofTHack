using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;

    // Update is called once per frame
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1){
				//NEW GAME
				if(thisIndex == 0){
					LoadScene("Loading");
				}
				//Room 1
				if(thisIndex == 1){
					LoadScene("Hammer");
				}
				//Room 2
				if(thisIndex == 2){
					LoadScene("Lock");
				}
				//Quit
				if(thisIndex == 3){
					QuitGame ();
				}
				animator.SetBool ("pressed", true);
			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}else{
			animator.SetBool ("selected", false);
		}
    }
	public void LoadScene(string sceneName){
		SceneManager.LoadScene(sceneName);
	}

	void QuitGame () {
		Application.Quit ();
		Debug.Log("Game is exiting");
		//Just to make sure its working
	}
}
