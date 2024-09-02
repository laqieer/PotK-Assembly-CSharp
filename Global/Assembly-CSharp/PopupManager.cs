// Decompiled with JetBrains decompiler
// Type: PopupManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class PopupManager : Singleton<PopupManager>
{
  [SerializeField]
  private GameObject popupPanel;
  [SerializeField]
  private int defaultDepth = 20;
  private Stack<PopupManager.PopupParts> stack = new Stack<PopupManager.PopupParts>();
  private bool isFinished = true;
  private Queue<IEnumerator> dismissQueue = new Queue<IEnumerator>();

  protected override void Initialize()
  {
  }

  private bool startTween(GameObject o, bool active)
  {
    bool flag = false;
    if (Object.op_Equality((Object) o, (Object) null))
      return false;
    NGTweenParts component = o.GetComponent<NGTweenParts>();
    if (Object.op_Inequality((Object) component, (Object) null))
    {
      flag = true;
      component.forceActive(active);
    }
    return flag;
  }

  public GameObject openAlert(
    GameObject prefab,
    bool unmask = false,
    bool ispile = false,
    EventDelegate ed = null,
    bool isCloned = false,
    bool isViewBack = true,
    bool isNonSe = false)
  {
    this.StartCoroutine(this.playBackground(0.1f, (System.Action) (() => this.SetCurrentScenePush(true))));
    if (ed == null)
      ed = new EventDelegate((MonoBehaviour) this, "onDismiss");
    GameObject gameObject = this.open(prefab, unmask, ispile, isCloned, isViewBack, isNonSe);
    bool flag = true;
    if (Object.op_Inequality((Object) gameObject, (Object) null))
    {
      UIButton[] componentsInChildren = gameObject.GetComponentsInChildren<UIButton>(true);
      if (componentsInChildren.Length > 0)
      {
        flag = false;
        foreach (UIButton uiButton in componentsInChildren)
          uiButton.onClick.Add(ed);
      }
    }
    if (flag)
    {
      UIButton uiButton = ((Component) this.stack.Last<PopupManager.PopupParts>().maskTween).gameObject.AddComponent<UIButton>();
      uiButton.pressed = Color.black;
      uiButton.onClick.Add(ed);
    }
    return gameObject;
  }

  private int thisDepth()
  {
    return this.stack.Any<PopupManager.PopupParts>() ? this.stack.Peek().depth : this.defaultDepth;
  }

  public GameObject open(
    GameObject prefab,
    bool unmask = false,
    bool ispile = false,
    bool isCloned = false,
    bool isViewBack = true,
    bool isNonSe = false)
  {
    this.StartCoroutine(this.playBackground(0.1f, (System.Action) (() => this.SetCurrentScenePush(true))));
    if (!ispile && this.stack.Any<PopupManager.PopupParts>())
    {
      PopupManager.PopupParts popupParts = this.stack.Peek();
      if (Object.op_Inequality((Object) popupParts.maskTween, (Object) null))
        popupParts.maskTween.isActive = false;
      this.startTween(popupParts.popup, false);
    }
    PopupManager.PopupParts popupParts1 = new PopupManager.PopupParts();
    int num1 = this.thisDepth();
    popupParts1.ispile = ispile;
    popupParts1.panel = this.popupPanel.Clone(((Component) this).transform);
    UIPanel component1 = popupParts1.panel.GetComponent<UIPanel>();
    component1.SetAnchor(((Component) this).transform);
    UIPanel uiPanel1 = component1;
    int num2 = num1;
    int num3 = num2 + 1;
    uiPanel1.depth = num2;
    if (!unmask)
    {
      foreach (Component component2 in popupParts1.panel.transform)
      {
        NGTweenParts component3 = component2.GetComponent<NGTweenParts>();
        if (Object.op_Inequality((Object) component3, (Object) null))
        {
          if (isViewBack)
          {
            popupParts1.maskTween = component3;
          }
          else
          {
            UI2DSprite component4 = ((Component) component3).gameObject.GetComponent<UI2DSprite>();
            if (Object.op_Inequality((Object) component4, (Object) null))
              component4.color = new Color(0.0f, 0.0f, 0.0f, 0.01f);
            popupParts1.maskTween = (NGTweenParts) null;
          }
        }
      }
    }
    if (Object.op_Inequality((Object) prefab, (Object) null))
    {
      if (isCloned)
      {
        prefab.SetParent(popupParts1.panel);
        popupParts1.popup = prefab;
      }
      else
        popupParts1.popup = prefab.Clone(popupParts1.panel.transform);
      UIPanel component5 = popupParts1.popup.GetComponent<UIPanel>();
      if (Object.op_Inequality((Object) component5, (Object) null))
      {
        component5.SetAnchor(((Component) this).transform);
        component5.depth = num3++;
      }
      UIPanel[] componentsInChildren = popupParts1.popup.GetComponentsInChildren<UIPanel>(true);
      int num4 = num3;
      foreach (UIPanel uiPanel2 in componentsInChildren)
      {
        uiPanel2.depth += num3;
        if (num4 < uiPanel2.depth)
          num4 = uiPanel2.depth;
      }
      num3 = num4 + 1;
      if (Object.op_Inequality((Object) popupParts1.maskTween, (Object) null))
        popupParts1.maskTween.isActive = true;
      this.startTween(popupParts1.popup, true);
    }
    else
      popupParts1.popup = (GameObject) null;
    popupParts1.depth = num3;
    this.stack.Push(popupParts1);
    if (!isNonSe)
      this.StartCoroutine(this.playBackground(0.1f, (System.Action) (() => Singleton<NGSoundManager>.GetInstance().playSE("SE_1006"))));
    CommonRoot instance = Singleton<CommonRoot>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.resetTouchBlockActive();
    return popupParts1.popup;
  }

  public GameObject unMaskOpen(GameObject prefab) => this.open(prefab, true);

  public void SetCurrentScenePush(bool currentScenePush)
  {
    if (!Object.op_Inequality((Object) Singleton<NGSceneManager>.GetInstance().sceneBase, (Object) null))
      return;
    Singleton<NGSceneManager>.GetInstance().sceneBase.IsPush = currentScenePush;
  }

  public bool dismiss(bool currentScenePush = false)
  {
    if (!this.stack.Any<PopupManager.PopupParts>())
      return false;
    PopupManager.PopupParts parts = this.stack.Pop();
    if (this.stack.Any<PopupManager.PopupParts>())
    {
      PopupManager.PopupParts popupParts = this.stack.Peek();
      if (Object.op_Inequality((Object) popupParts.maskTween, (Object) null))
        popupParts.maskTween.isActive = true;
      if (!parts.ispile && Object.op_Inequality((Object) parts.popup, (Object) null))
        this.startTween(popupParts.popup, true);
    }
    else
      this.StartCoroutine(this.playBackground(0.1f, (System.Action) (() => this.SetCurrentScenePush(currentScenePush))));
    this.dismissQueue.Enqueue(this.dismissWait(parts));
    if (this.dismissQueue.Count == 1)
      this.StartCoroutine(this.doDismissQueue());
    return true;
  }

  public void closeAll(bool currentScenePush = false)
  {
    do
      ;
    while (this.dismiss(currentScenePush));
  }

  [DebuggerHidden]
  private IEnumerator doDismissQueue()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PopupManager.\u003CdoDismissQueue\u003Ec__Iterator8D2()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator dismissWait(PopupManager.PopupParts parts)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PopupManager.\u003CdismissWait\u003Ec__Iterator8D3()
    {
      parts = parts,
      \u003C\u0024\u003Eparts = parts,
      \u003C\u003Ef__this = this
    };
  }

  public void onDismiss() => this.dismiss();

  public void onDismiss(bool currentScenePush) => this.dismiss(currentScenePush);

  public bool isOpen => this.stack.Any<PopupManager.PopupParts>() || !this.isFinished;

  public bool isOpenNoFinish => this.stack.Any<PopupManager.PopupParts>();

  [DebuggerHidden]
  private IEnumerator playBackground(float seconds, System.Action play)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PopupManager.\u003CplayBackground\u003Ec__Iterator8D4()
    {
      seconds = seconds,
      play = play,
      \u003C\u0024\u003Eseconds = seconds,
      \u003C\u0024\u003Eplay = play
    };
  }

  public static void Show(string title, string message, System.Action callback = null)
  {
    Singleton<PopupManager>.GetInstance().StartCoroutine(PopupCommon.Show(title, message, callback));
  }

  public static void ShowYesNo(string title, string message, System.Action yes = null, System.Action no = null)
  {
    PopupCommonOkTitle.Show(title, message, yes, no);
  }

  private class PopupParts
  {
    public GameObject panel;
    public GameObject popup;
    public NGTweenParts maskTween;
    public bool ispile;
    public int depth;
  }
}
