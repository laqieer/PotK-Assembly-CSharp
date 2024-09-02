// Decompiled with JetBrains decompiler
// Type: Startup00012Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Startup00012Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private NGxScrollMasonry scrollMasonry;
  [SerializeField]
  private List<GameObject> categoryList;
  [SerializeField]
  private UILabel badgeDisplay;
  public UIPanel panel;
  public UIWidget widget;
  public UITextList textList;
  public GameObject scrollViewObj;
  public GameObject logContainer;
  public GameObject newSpriteObj;
  public int oldDay = -7;
  private UIScrollView scrollView;
  private UILabel label;
  private List<GameObject> cloneList = new List<GameObject>();
  public GameObject scrollBar;
  public bool isContinue = true;
  public bool unRead;
  private bool isScroll;
  [SerializeField]
  private string nextSceneName;
  private string title;

  protected virtual int GetWidth() => 532;

  public List<GameObject> CategoryList
  {
    get => this.categoryList;
    set => this.categoryList = value;
  }

  public UILabel BadgeDisplay
  {
    get => this.badgeDisplay;
    set => this.badgeDisplay = value;
  }

  public string NextSceneName
  {
    get => this.nextSceneName;
    set => this.nextSceneName = value;
  }

  protected virtual bool DeleteTitle() => false;

  public virtual void IbtnClose()
  {
    if (this.IsPushAndSet() || Singleton<NGGameDataManager>.GetInstance().InfoOrLoginBonusJump())
      return;
    MypageScene.ChangeScene(false);
  }

  public virtual void IbtnList()
  {
    if (this.IsPushAndSet())
      return;
    this.EndScene();
    Singleton<NGSceneManager>.GetInstance().changeScene(this.NextSceneName, true);
  }

  [DebuggerHidden]
  public IEnumerator InitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00012Menu.\u003CInitAsync\u003Ec__Iterator12C()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void EndScene()
  {
    foreach (Component child in ((Component) this.scrollMasonry.Scroll).transform.GetChildren())
      Object.Destroy((Object) child.gameObject);
    this.scrollMasonry.Reset();
  }

  [DebuggerHidden]
  public IEnumerator InitSceneAsync(OfficialInformationArticle info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00012Menu.\u003CInitSceneAsync\u003Ec__Iterator12D()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    MypageScene.ChangeScene(false);
    DetailController.Release();
  }
}
