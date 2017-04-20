using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour {
    public UISlider mSlider;
    public UILabel mLabell;

    // 异步对象
    private AsyncOperation async;

    void Start () {
        StartCoroutine(LoadScene(LevelSelect.instance().LevelIndex));
        //预设加载完成后才设置
        mSlider.value = 0;
        SetLabelInfo(mSlider.GetComponent<UISlider>().value);
    }
	

	void LateUpdate () {
        mSlider.value = async.progress;
        print(mSlider.value);
        SetLabelInfo(mSlider.value);
    }

    IEnumerator LoadScene(int Level)
    {
        yield return new WaitForEndOfFrame();
        async = SceneManager.LoadSceneAsync(Level);

        //加载完毕自动进入场景
        yield return async;

        Destroy(this.gameObject);
    }

    void SetLabelInfo(float value)
    {
        if (mLabell != null)
        {
            mLabell.text = (mSlider.value * 100).ToString("0.0") + "%";
        }
    }
}
