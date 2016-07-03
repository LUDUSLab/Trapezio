using UnityEngine;
using System.Collections;

public class PlayOneRandomSound : StateMachineBehaviour {

    [SerializeField]
    private AudioClip[] SoundClips;
    [SerializeField]
    private string AudioSourceName = "Audio Source";
    private AudioSource source;
    private Random rng;
    private int randomNumber;
    private float timeStartedClip;
    private float realTime, timeStarted;

    private bool canSound = false;
    
    public float AnimationTime = 3f;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        //if(!stateInfo.IsName("BamBam_Power_Up"))
        
        source = GameObject.Find(AudioSourceName).GetComponent<AudioSource>();
        source.mute = false;

        timeStarted = Time.realtimeSinceStartup;
        //PlayRandomSound(stateInfo);
        canSound = true;
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        source.mute = false;
        //SoundClips[randomNumber].length
        realTime = Time.realtimeSinceStartup;
        //se a musica acabou
        if(realTime - timeStartedClip > SoundClips[randomNumber].length)
        {
            //roda outra
            canSound = true;
            //PlayRandomSound(stateInfo);
        }
        //Debug.Log(stateInfo.length);
        //<!--playrandom sound
        ///*
        if (canSound)
        {
            randomNumber = Random.Range(0, SoundClips.Length - 1);
            if (SoundClips[randomNumber].length < AnimationTime - (Time.realtimeSinceStartup - timeStarted))
            {
                source.Stop();
                source.Play();
                source.PlayOneShot(SoundClips[randomNumber]);
                timeStartedClip = Time.realtimeSinceStartup;
                canSound = false;
            }
        }
        //*/
        //-->
    }

    private void PlayRandomSound(AnimatorStateInfo info)
    {
        randomNumber = Random.Range(0, SoundClips.Length - 1);
        //enquanto não achar um som que caiba na duração
        while(SoundClips[randomNumber].length > AnimationTime - (Time.realtimeSinceStartup - timeStarted))
        {
            randomNumber = Random.Range(0, SoundClips.Length);
        }
        source.PlayOneShot(SoundClips[randomNumber]);
        timeStartedClip = Time.realtimeSinceStartup;
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
