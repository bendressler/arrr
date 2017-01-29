using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageText : MonoBehaviour {

	public Animator animator;
	private Text damageText;

	public DamageText(float damage){
		damageText.text = damage.ToString ();
	}

	void Start(){
		animator = GetComponentInChildren<Animator> ();
		AnimatorClipInfo[] clipinfo = animator.GetCurrentAnimatorClipInfo (0);
		Destroy (gameObject, clipinfo [0].clip.length);
		damageText = GetComponentInChildren<Text> ();
	}
}
