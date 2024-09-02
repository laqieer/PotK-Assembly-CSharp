// Decompiled with JetBrains decompiler
// Type: Quest0024StoryButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest0024StoryButton : MonoBehaviour
{
  private const int NORMAL = 0;
  private const int HARD = 1;
  [SerializeField]
  private UISprite LockCircle;
  [SerializeField]
  private UISprite UnLockCircle;
  [SerializeField]
  private UI2DSprite IdleSprite;
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
  private Sprite[] StoryBtnSprites;
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

  public bool isActive() => ((Component) this.UnLockCircle).gameObject.activeSelf;

  public void Lock()
  {
    ((Component) this.LockCircle).gameObject.SetActive(true);
    ((Component) this.clearSprite).gameObject.SetActive(false);
    ((Component) this.newSprite).gameObject.SetActive(false);
    ((Component) this.ibtnStory).gameObject.SetActive(false);
    ((Component) this.IdleSprite).gameObject.SetActive(false);
    ((Component) this.UnLockCircle).gameObject.SetActive(false);
    this.missionAchevement.SetActive(false);
    ((Component) this.Bonus).gameObject.SetActive(false);
  }

  public void UnLock(bool clearflag, bool newflag)
  {
    ((Component) this.LockCircle).gameObject.SetActive(false);
    ((Component) this.clearSprite).gameObject.SetActive(clearflag);
    ((Component) this.newSprite).gameObject.SetActive(newflag);
    ((Component) this.ibtnStory).gameObject.SetActive(true);
    ((Component) this.UnLockCircle).gameObject.SetActive(true);
    this.missionAchevement.SetActive(true);
    ((Component) this.missionAchevementComplete).gameObject.SetActive(false);
    ((Component) this.missionAchevementCount).gameObject.SetActive(false);
  }

  public void MissionAchevement(int nowCount, int allCount)
  {
    if (allCount == 0)
    {
      ((Component) ((Component) this.missionAchevementComplete).transform.parent).gameObject.SetActive(false);
    }
    else
    {
      bool flag = nowCount == allCount;
      ((Component) this.missionAchevementComplete).gameObject.SetActive(flag);
      ((Component) this.missionAchevementCount).gameObject.SetActive(!flag);
      if (flag)
        return;
      this.missionAchevementCount.SetTextLocalize("[ffff00]" + nowCount.ToString() + "[-]" + string.Format("/{0}", (object) allCount));
    }
  }

  public void playButtonReverseTween()
  {
    ((Behaviour) this.ibtnStory).enabled = true;
    TweenAlpha component1 = ((Component) this).GetComponent<TweenAlpha>();
    TweenPosition component2 = ((Component) this).GetComponent<TweenPosition>();
    this.StartDelay = component2.delay;
    component1.delay = 0.0f;
    component2.delay = 0.0f;
    EventDelegate.Set(((Component) this).GetComponent<TweenPosition>().onFinished, new EventDelegate.Callback(this.ReturnButtonTweenValue));
  }

  public void changeClickMySelf()
  {
    TweenPosition component = ((Component) this).GetComponent<TweenPosition>();
    component.from.y -= (float) (2.0 * ((double) component.from.y - (double) component.to.y));
    component.delay = 0.0f;
    this.clickMySelf = !this.clickMySelf;
  }

  public void ReturnButtonTweenValue()
  {
    if (this.clickMySelf)
      this.changeClickMySelf();
    TweenAlpha component1 = ((Component) this).GetComponent<TweenAlpha>();
    TweenPosition component2 = ((Component) this).GetComponent<TweenPosition>();
    component1.delay = this.StartDelay;
    component2.delay = this.StartDelay;
  }

  [DebuggerHidden]
  public IEnumerator InitButton(bool hard)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0024StoryButton.\u003CInitButton\u003Ec__Iterator21E()
    {
      hard = hard,
      \u003C\u0024\u003Ehard = hard,
      \u003C\u003Ef__this = this
    };
  }

  public void SetBonus(int bonusCategory)
  {
    if (bonusCategory == 0)
    {
      ((Component) this.Bonus).gameObject.SetActive(false);
    }
    else
    {
      string name = string.Format("slc_Bonus_{0}.png__GUI__quest_bonus_sozai__quest_bonus_sozai_prefab", (object) bonusCategory);
      UISpriteData sprite = this.Bonus.atlas.GetSprite(name);
      if (sprite != null)
      {
        ((Component) this.Bonus).gameObject.SetActive(true);
        this.Bonus.spriteName = name;
        UIWidget component = ((Component) this.Bonus).GetComponent<UIWidget>();
        Vector3 localPosition = ((Component) component).transform.localPosition;
        component.SetRect(0.0f, 0.0f, (float) sprite.width, (float) sprite.height);
        ((Component) component).transform.localPosition = localPosition;
      }
      else
      {
        Debug.LogWarning((object) ("Bonus texture was not found for path " + name));
        ((Component) this.Bonus).gameObject.SetActive(false);
      }
    }
  }

  private void OverOrOut(bool over, bool hard)
  {
    this.IdleSprite.color = !over ? Consts.GetInstance().UI_SPRITE_NORMAL_COLOR : Consts.GetInstance().UI_SPRITE_HIGHLIGHT_COLOR;
    ((Component) this.IdleSprite).gameObject.SetActive(true);
  }

  [DebuggerHidden]
  private IEnumerator SetSpritePaths(bool hard)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0024StoryButton.\u003CSetSpritePaths\u003Ec__Iterator21F()
    {
      hard = hard,
      \u003C\u0024\u003Ehard = hard,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateSprite(string path, UI2DSprite spriteobj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0024StoryButton.\u003CCreateSprite\u003Ec__Iterator220()
    {
      path = path,
      spriteobj = spriteobj,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003Espriteobj = spriteobj,
      \u003C\u003Ef__this = this
    };
  }

  private void AtacheSprite(Sprite spr, UI2DSprite sprobj)
  {
    UI2DSprite ui2Dsprite1 = sprobj;
    Rect rect1 = spr.rect;
    int num1 = Mathf.FloorToInt(((Rect) ref rect1).width);
    ui2Dsprite1.width = num1;
    UI2DSprite ui2Dsprite2 = sprobj;
    Rect rect2 = spr.rect;
    int num2 = Mathf.FloorToInt(((Rect) ref rect2).height);
    ui2Dsprite2.height = num2;
    sprobj.sprite2D = spr;
  }
}
