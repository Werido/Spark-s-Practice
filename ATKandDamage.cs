using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class ATKandDamage : MonoBehaviour
{
    public enemyType type;
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

    public int getScore { get { return Score; }set { Score = value; } }
    public Animator _animator { get { return animator; } }
    public int hptotal { get { return hpTotal; } }
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

            //针对Monster和Boss的操作 ，从敌人列表中移除，返回对象池，防止控制器影响主角移动
            if (this.tag != TagMgr.Player)
            {
                //奖励生成
                SpawnAward();
                //得分累加
                Score += ScoreAward();

                //此处要改成放回缓存池
                StartCoroutine(pushBack(gameObject));
                //AllCacheController.instance.pushBackItem(gameObject);
                //Destroy(this.gameObject, 1);
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

    IEnumerator pushBack(GameObject _gameObject)
    {
        yield return new WaitForSeconds(1f);
        AllCacheController.instance.pushBackItem(_gameObject);
    }
    #region 击杀奖励

    public virtual int ScoreAward()
    {
        return 0;
    }
    void SpawnAward()
    {
        //根据随机数判断是否生成奖励
        int count = Random.Range(0, 3);
        if (count == 0)
            return;

        int index = Random.Range(0, 3);
        if (index == 1)
        {
            GameObject.Instantiate(Resources.Load("ItemCD"), transform.position + Vector3.up,
                Quaternion.identity);
        }
        else if (index == 0)
        {
            GameObject.Instantiate(Resources.Load("ItemHeath"), transform.position + Vector3.up,
                Quaternion.identity);
        }
        else
        {
            GameObject.Instantiate(Resources.Load("ItemMove"), transform.position + Vector3.up,
                Quaternion.identity);
        }
    }
    #endregion
}
