// Decompiled with JetBrains decompiler
// Type: BGChange
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BGChange : MonoBehaviour
{
  [SerializeField]
  private GameObject current;
  public bool NotTween;

  public GameObject Current => this.current;

  [DebuggerHidden]
  public IEnumerator asyncBgAnim(QuestBG.AnimApply set, float duration = 0)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BGChange.\u003CasyncBgAnim\u003Ec__Iterator26D()
    {
      set = set,
      duration = duration,
      \u003C\u0024\u003Eset = set,
      \u003C\u0024\u003Eduration = duration
    };
  }

  [DebuggerHidden]
  public IEnumerator QuestBGprefabCreate(int L, int M = 0, bool Hard = false, int XL = 1)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BGChange.\u003CQuestBGprefabCreate\u003Ec__Iterator26E()
    {
      L = L,
      M = M,
      XL = XL,
      Hard = Hard,
      \u003C\u0024\u003EL = L,
      \u003C\u0024\u003EM = M,
      \u003C\u0024\u003EXL = XL,
      \u003C\u0024\u003EHard = Hard,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ExtraBGprefabCreate(string name)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BGChange.\u003CExtraBGprefabCreate\u003Ec__Iterator26F()
    {
      name = name,
      \u003C\u0024\u003Ename = name
    };
  }

  public void ChangeCurrentBGprefab(int M, int XL, bool Hard = false)
  {
    QuestBG backgroundComponent = Singleton<CommonRoot>.GetInstance().getBackgroundComponent<QuestBG>();
    backgroundComponent.Current = backgroundComponent.current_l;
    backgroundComponent.changeActive(false);
    this.M_BGAnimation(M, true, Hard);
  }

  [DebuggerHidden]
  public IEnumerator BGprefabCreate(bool mustCreate, int L, int M = 0, int XL = 1)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BGChange.\u003CBGprefabCreate\u003Ec__Iterator270()
    {
      L = L,
      mustCreate = mustCreate,
      \u003C\u0024\u003EL = L,
      \u003C\u0024\u003EmustCreate = mustCreate,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator EarthBGprefabCreate(string name)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BGChange.\u003CEarthBGprefabCreate\u003Ec__Iterator271()
    {
      name = name,
      \u003C\u0024\u003Ename = name
    };
  }

  public void CrossToL(bool toHome = false)
  {
    this.getCurrentBG();
    if (!Object.op_Equality((Object) this.current, (Object) Singleton<CommonRoot>.GetInstance().getBackgroundComponent<QuestBG>().current_xl))
      return;
    this.CrossFadeBG(toHome);
  }

  public void CrossToXL(bool toHome = false)
  {
    this.getCurrentBG();
    if (!Object.op_Equality((Object) this.current, (Object) Singleton<CommonRoot>.GetInstance().getBackgroundComponent<QuestBG>().current_l))
      return;
    this.CrossFadeBG(toHome);
  }

  public void CrossFadeBG(bool toHome)
  {
    this.getCurrentBG();
    QuestBG backgroundComponent = Singleton<CommonRoot>.GetInstance().getBackgroundComponent<QuestBG>();
    UI2DSprite component = this.current.GetComponent<UI2DSprite>();
    UI2DSprite currentNext = !Object.op_Inequality((Object) this.current, (Object) backgroundComponent.current_xl) ? backgroundComponent.current_l.GetComponent<UI2DSprite>() : backgroundComponent.current_xl.GetComponent<UI2DSprite>();
    ((Component) component).gameObject.SetActive(true);
    ((Component) currentNext).gameObject.SetActive(true);
    component.depth = 10;
    currentNext.depth = 1;
    TweenAlpha cross = ((Component) component).gameObject.GetOrAddComponent<TweenAlpha>();
    ((Component) component).GetComponent<UI2DSprite>().alpha = 1f;
    ((Component) currentNext).GetComponent<UI2DSprite>().alpha = 1f;
    cross.delay = 0.0f;
    cross.duration = 1f;
    cross.to = 0.0f;
    cross.from = 1f;
    cross.onFinished.Clear();
    backgroundComponent.Current = ((Component) currentNext).gameObject;
    EventDelegate.Set(cross.onFinished, (EventDelegate.Callback) (() =>
    {
      cross.value = 1f;
      currentNext.depth = 10;
      if (!toHome)
        return;
      this.StartCoroutine(this.CheckStageBG());
    }));
    cross.ResetToBeginning();
    cross.PlayForward();
  }

  public void getCurrentBG()
  {
    if (Singleton<CommonRoot>.GetInstance().hasBackground())
    {
      this.current = (GameObject) null;
    }
    else
    {
      QuestBG backgroundComponent = Singleton<CommonRoot>.GetInstance().getBackgroundComponent<QuestBG>();
      this.current = !Object.op_Equality((Object) backgroundComponent, (Object) null) ? backgroundComponent.Current : (GameObject) null;
    }
  }

  public bool ComparisonBackground(GameObject prefab)
  {
    this.getCurrentBG();
    return Object.op_Equality((Object) this.current, (Object) null) || Object.op_Equality((Object) ((Component) this.current.transform.parent).GetComponent<QuestBG>(), (Object) null) || !(((Component) this.current.transform.parent).GetComponent<QuestBG>().namePrefab == prefab.GetComponent<QuestBG>().namePrefab);
  }

  public void M_BGAnimation(int clickNum, bool quick = false, bool Hard = false)
  {
    bool TweenToS = true;
    if (quick)
      this.NotTween = true;
    QuestBG backgroundComponent = Singleton<CommonRoot>.GetInstance().getBackgroundComponent<QuestBG>();
    switch (clickNum)
    {
      case 1:
        if (quick)
        {
          backgroundComponent.Toggle(QuestBG.AnimApply.Button1, 0.0f);
          break;
        }
        backgroundComponent.Toggle(QuestBG.AnimApply.Button1);
        break;
      case 2:
        if (quick)
        {
          backgroundComponent.Toggle(QuestBG.AnimApply.Button2, 0.0f);
          break;
        }
        backgroundComponent.Toggle(QuestBG.AnimApply.Button2);
        break;
      case 3:
        if (quick)
        {
          backgroundComponent.Toggle(QuestBG.AnimApply.Button3, 0.0f);
          break;
        }
        backgroundComponent.Toggle(QuestBG.AnimApply.Button3);
        break;
      case 4:
        if (quick)
        {
          backgroundComponent.Toggle(QuestBG.AnimApply.Button4, 0.0f);
          break;
        }
        backgroundComponent.Toggle(QuestBG.AnimApply.Button4);
        break;
      case 5:
        if (quick)
        {
          backgroundComponent.Toggle(QuestBG.AnimApply.Button5, 0.0f);
          break;
        }
        backgroundComponent.Toggle(QuestBG.AnimApply.Button5);
        break;
      case 10:
        if (quick)
          backgroundComponent.Toggle(QuestBG.AnimApply.LMainPostion, 0.0f);
        else
          backgroundComponent.Toggle(QuestBG.AnimApply.LMainPostion);
        TweenToS = false;
        break;
    }
    if (Hard)
      return;
    backgroundComponent.ClickTweenV(TweenToS, quick);
  }

  public void BlackHangingBackGround(bool toHard, bool quick = false)
  {
    this.getCurrentBG();
    if (Object.op_Equality((Object) this.Current, (Object) null))
      Debug.LogWarning((object) "Current BackGround == null !!");
    else
      Singleton<CommonRoot>.GetInstance().getBackgroundComponent<QuestBG>().Darken(toHard, quick);
  }

  [DebuggerHidden]
  public IEnumerator CheckStageBG()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BGChange.\u003CCheckStageBG\u003Ec__Iterator272()
    {
      \u003C\u003Ef__this = this
    };
  }
}
