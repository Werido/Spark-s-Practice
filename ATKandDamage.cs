using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class ATKandDamage : MonoBehaviour
{

    public float hp = 100;
    public float normalAttack = 50;
    public float attackDistance = 1;
    protected Animator animator;
    public AudioClip DeathClip;
    public GameObject EndInterface;
    //防止重复赋值
    protected static int Score = 0;

    //记分器
    private GameObject ScoreLabel;
    //怪物血条
    public Slider HpSlider;
    //角色血条
    public UISlider PlayerHpSlider;
    private bool SoundIsPlay = false;
    private int hpTotal;

    //获取animator组件
    protected void Awake()
    {
        animator = this.GetComponent<Animator>();
        hpTotal = (int)hp;
        ScoreLabel = GameObject.Find("ScoreLabel");
        ScoreLabel.GetComponent<UILabel>().text = "Score: " + Score;
    }

    #region 承受伤害处理

    private void SoundAndAnimator()
    {
        //AudioSource.PlayClipAtPoint(DeathClip, transform.position, 1f);
        animator.SetTrigger("Dead");
    }
    public virtual void TakeDamage(float damage)
    {
        if (hp > 0)
        { 
            hp -= damage;
        }
        if (hp>0)
        {
            if (this.tag != TagMgr.Player)
            {
                animator.SetTrigger("Damage");
                //血条控制
                HpSlider.value = hp / hpTotal;
            }
            else
            {
                PlayerHpSlider.value = hp/hpTotal;
            }
        }
        else
        {
            //血条控制
            if (this.tag != TagMgr.Player)
            {
                //血条控制
                HpSlider.value = 0;
                SoundAndAnimator();
            }
            else
            {
                if (SoundIsPlay == false)
                {
                    SoundAndAnimator();
                    SoundIsPlay = true;
                }
                EndInterface.SetActive(true);
                PlayerHpSlider.value = 0; 


            }
            animator.SetTrigger("Dead");

            //针对Monster和Boss的操作 ，从敌人列表中移除，延迟销毁，防止控制器影响主角移动
            if (this.tag != TagMgr.Player)
            {
                //奖励生成
                SpawnAward();
                //得分累加
                Score += ScoreAward();
                Destroy(this.gameObject, 1);
                SpawnMgr._instance.EnemyList.Remove(this.gameObject);

                //this.GetComponent<CharacterController>().enabled = false;
            }
        }

        //打击特效
        if (this.tag == TagMgr.SoulBoss)
        {
            GameObject.Instantiate(Resources.Load("HitBoss"), transform.position + Vector3.up, transform.rotation);
        }
        else if (this.tag == TagMgr.SoulMonster)
        {
            GameObject.Instantiate(Resources.Load("HitMonster"), transform.position + Vector3.up, transform.rotation);
        }
        ScoreLabel.GetComponent<UILabel>().text = "Score: " + Score;
    }
    #endregion

    #region 击杀奖励

    public virtual int ScoreAward()
    {
        return 0;
    }
    void SpawnAward()
    {
        //生成1-2个奖励
        int count = Random.Range(1, 3);
        for (int i = 0; i < count; i++)  
        {
           
            int index = Random.Range(0, 2);
            if (index == 1)
            {
                GameObject.Instantiate(Resources.Load("Item-DualSword"), transform.position + Vector3.up,
                    Quaternion.identity);
            }
            else if(index == 0)
            {
                GameObject.Instantiate(Resources.Load("Item-DualGun"), transform.position + Vector3.up,
                    Quaternion.identity);
            }
        }
    }
    #endregion
}
