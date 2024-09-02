// Decompiled with JetBrains decompiler
// Type: Quest0024StoryButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class Quest0024StoryButton : MonoBehaviour
{
  [SerializeField]
  private UISprite LockCircle;
  [SerializeField]
  private UISprite UnLockCircle;
  [SerializeField]
  private UI2DSprite IdleSprite;
  [SerializeField]
  private UI2DSprite PressSprite;
  public FloatButton ibtnStory;
  [SerializeField]
  private UISprite newSprite;
  [SerializeField]
  private UISprite clearSprite;
  [SerializeField]
  private GameObject missionAchevement;
  [SerializeField]
  private UILabel missionAchevementCount;
  [SerializeField]
  private UISprite missionAchevementComplete;
  [SerializeField]
  private UISprite Bonus;
  private float StartDelay;
  private bool clickMySelf;
  [SerializeField]
  private UnityEngine.Sprite[] StoryBtnSprites;
  private const int NORMAL = 0;
  private const int HARD = 1;
  private int ButtonResourcePathNumber;
  private int ButtonMnumber;
  public EventDelegate onClick;

  public int PathNumber
  {
    set => this.ButtonResourcePathNumber = value;
  }

  public int Mnumber
  {
    get => this.ButtonMnumber;
    set => this.ButtonMnumber = value;
  }

  public bool isActive() => this.UnLockCircle.gameObject.activeSelf;

  public void Lock()
  {
    this.LockCircle.gameObject.SetActive(true);
    this.clearSprite.gameObject.SetActive(false);
    this.newSprite.gameObject.SetActive(false);
    this.ibtnStory.gameObject.SetActive(false);
    this.IdleSprite.gameObject.SetActive(false);
    this.PressSprite.gameObject.SetActive(false);
    this.UnLockCircle.gameObject.SetActive(false);
    this.missionAchevement.SetActive(false);
    this.Bonus.gameObject.SetActive(false);
  }

  public void UnLock(bool clearflag, bool newflag)
  {
    this.LockCircle.gameObject.SetActive(false);
    this.clearSprite.gameObject.SetActive(clearflag);
    this.newSprite.gameObject.SetActive(newflag);
    this.ibtnStory.gameObject.SetActive(true);
    this.UnLockCircle.gameObject.SetActive(true);
    this.missionAchevement.SetActive(true);
    this.missionAchevementComplete.gameObject.SetActive(false);
    this.missionAchevementCount.gameObject.SetActive(false);
  }

  public void MissionAchevement(int nowCount, int allCount)
  {
    if (allCount == 0)
    {
      this.missionAchevementComplete.transform.parent.gameObject.SetActive(false);
    }
    else
    {
      bool flag = nowCount == allCount;
      this.missionAchevementComplete.gameObject.SetActive(flag);
      this.missionAchevementCount.gameObject.SetActive(!flag);
      if (flag)
        return;
      this.missionAchevementCount.SetTextLocalize("[ffff00]" + nowCount.ToString() + "[-]" + string.Format("/{0}", (object) allCount));
    }
  }

  public void playButtonReverseTween()
  {
    this.ibtnStory.enabled = true;
    TweenAlpha component1 = this.GetComponent<TweenAlpha>();
    TweenPosition component2 = this.GetComponent<TweenPosition>();
    this.StartDelay = component2.delay;
    component1.delay = 0.0f;
    component2.delay = 0.0f;
    EventDelegate.Set(this.GetComponent<TweenPosition>().onFinished, new EventDelegate.Callback(this.ReturnButtonTweenValue));
  }

  public void changeClickMySelf()
  {
    TweenPosition component = this.GetComponent<TweenPosition>();
    component.from.y -= (float) (2.0 * ((double) component.from.y - (double) component.to.y));
    component.delay = 0.0f;
    this.clickMySelf = !this.clickMySelf;
  }

  public void ReturnButtonTweenValue()
  {
    if (this.clickMySelf)
      this.changeClickMySelf();
    TweenAlpha component1 = this.GetComponent<TweenAlpha>();
    TweenPosition component2 = this.GetComponent<TweenPosition>();
    double startDelay = (double) this.StartDelay;
    component1.delay = (float) startDelay;
    component2.delay = this.StartDelay;
  }

  public IEnumerator InitButton(bool hard, Quest00240723Menu.StoryMode mode)
  {
    IEnumerator e = this.SetSpritePaths(hard, mode);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    EventDelegate.Set(this.ibtnStory.onClick, this.onClick);
    EventDelegate.Set(this.ibtnStory.onOver, (EventDelegate.Callback) (() => this.OverOrOut(true, hard)));
    EventDelegate.Set(this.ibtnStory.onOut, (EventDelegate.Callback) (() => this.OverOrOut(false, hard)));
    this.OverOrOut(false, hard);
  }

  public void SetBonus(int bonusCategory)
  {
    if (bonusCategory == 0)
    {
      this.Bonus.gameObject.SetActive(false);
    }
    else
    {
      string name = string.Format("slc_Bonus_{0}.png__GUI__quest_bonus_sozai__quest_bonus_sozai_prefab", (object) bonusCategory);
      UISpriteData sprite = this.Bonus.atlas.GetSprite(name);
      if (sprite != null)
      {
        this.Bonus.gameObject.SetActive(true);
        this.Bonus.spriteName = name;
        UIWidget component = this.Bonus.GetComponent<UIWidget>();
        Vector3 localPosition = component.transform.localPosition;
        component.SetRect(0.0f, 0.0f, (float) sprite.width, (float) sprite.height);
        component.transform.localPosition = localPosition;
      }
      else
        this.Bonus.gameObject.SetActive(false);
    }
  }

  private void OverOrOut(bool over, bool hard)
  {
    if (hard)
    {
      this.IdleSprite.gameObject.SetActive(!over);
      this.PressSprite.gameObject.SetActive(over);
    }
    else
    {
      this.IdleSprite.gameObject.SetActive(!over);
      this.PressSprite.gameObject.SetActive(over);
    }
  }

  private IEnumerator SetSpritePaths(bool hard, Quest00240723Menu.StoryMode mode)
  {
    string str1 = mode != Quest00240723Menu.StoryMode.EverAfter ? (mode != Quest00240723Menu.StoryMode.LostRagnarok ? (mode != Quest00240723Menu.StoryMode.IntegralNoah ? "story_btns" : "story_btns_IntegralNoah") : "story_btns_LostRagnarok") : "story_btns_EverAfter";
    string str2 = "Prefabs/quest002_4/" + str1 + "/btn_sprite/";
    string presspath;
    IEnumerator e;
    if (!hard)
    {
      string path = str2 + string.Format("{0}_idle", (object) this.ButtonResourcePathNumber);
      presspath = str2 + string.Format("{0}_pressed", (object) this.ButtonResourcePathNumber);
      if (!Singleton<ResourceManager>.GetInstance().Contains(path) || !Singleton<ResourceManager>.GetInstance().Contains(presspath))
      {
        path = "Prefabs/quest002_4/" + str1 + "/btn_sprite/1_idle";
        presspath = "Prefabs/quest002_4/" + str1 + "/btn_sprite/1_pressed";
      }
      e = this.CreateSprite(path, this.IdleSprite);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      e = this.CreateSprite(presspath, this.PressSprite);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      presspath = (string) null;
    }
    else
    {
      string path = str2 + string.Format("{0}_hard_idle", (object) this.ButtonResourcePathNumber);
      presspath = str2 + string.Format("{0}_hard_pressed", (object) this.ButtonResourcePathNumber);
      if (!Singleton<ResourceManager>.GetInstance().Contains(path) || !Singleton<ResourceManager>.GetInstance().Contains(presspath))
      {
        path = "Prefabs/quest002_4/" + str1 + "/btn_sprite/1_hard_idle";
        presspath = "Prefabs/quest002_4/" + str1 + "/btn_sprite/1_hard_pressed";
      }
      e = this.CreateSprite(path, this.IdleSprite);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      e = this.CreateSprite(presspath, this.PressSprite);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      presspath = (string) null;
    }
  }

  private IEnumerator CreateSprite(string path, UI2DSprite spriteobj)
  {
    Future<Texture2D> futureIdle = Singleton<ResourceManager>.GetInstance().Load<Texture2D>(path);
    IEnumerator e = futureIdle.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    Texture2D result = futureIdle.Result;
    UnityEngine.Sprite spr = UnityEngine.Sprite.Create(result, new Rect(0.0f, 0.0f, (float) result.width, (float) result.height), new Vector2(0.5f, 0.5f), 1f, 100U, SpriteMeshType.FullRect);
    spr.name = result.name;
    this.AtacheSprite(spr, spriteobj);
  }

  private void AtacheSprite(UnityEngine.Sprite spr, UI2DSprite sprobj)
  {
    sprobj.width = Mathf.FloorToInt(spr.rect.width);
    sprobj.height = Mathf.FloorToInt(spr.rect.height);
    sprobj.sprite2D = spr;
  }
}
