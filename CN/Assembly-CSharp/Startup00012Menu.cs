// Decompiled with JetBrains decompiler
// Type: Startup00012Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  private string title = string.Empty;

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
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage001_8_1", true);
  }

  [DebuggerHidden]
  public IEnumerator InitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00012Menu.\u003CInitAsync\u003Ec__Iterator16E()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void EndScene()
  {
    foreach (Object clone in this.cloneList)
      Object.Destroy(clone);
    this.cloneList.Clear();
  }

  [DebuggerHidden]
  public IEnumerator InitSceneAsync(OfficialInformationArticle info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00012Menu.\u003CInitSceneAsync\u003Ec__Iterator16F()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  private int SetText(GameObject obj, string str, int yTop, int size = 20)
  {
    GameObject go = obj.Clone(this.scrollViewObj.transform);
    this.label = go.GetComponent<UILabel>();
    this.label.SetDimensions(this.GetWidth(), 1);
    this.label.fontSize = size;
    this.label.SetText(str);
    NGUITools.UpdateWidgetCollider(go);
    go.transform.parent = this.scrollViewObj.transform;
    go.transform.localPosition = new Vector3(0.0f, (float) -yTop, 0.0f);
    this.cloneList.Add(go);
    return this.label.height;
  }

  [DebuggerHidden]
  private static IEnumerator SetSprite(
    GameObject obj,
    string sceneName,
    string param,
    string imgUrl,
    int swidth,
    int sheight,
    List<GameObject> list,
    Transform trans,
    int scrollHeight)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00012Menu.\u003CSetSprite\u003Ec__Iterator170()
    {
      obj = obj,
      trans = trans,
      sceneName = sceneName,
      param = param,
      swidth = swidth,
      sheight = sheight,
      imgUrl = imgUrl,
      scrollHeight = scrollHeight,
      list = list,
      \u003C\u0024\u003Eobj = obj,
      \u003C\u0024\u003Etrans = trans,
      \u003C\u0024\u003EsceneName = sceneName,
      \u003C\u0024\u003Eparam = param,
      \u003C\u0024\u003Eswidth = swidth,
      \u003C\u0024\u003Esheight = sheight,
      \u003C\u0024\u003EimgUrl = imgUrl,
      \u003C\u0024\u003EscrollHeight = scrollHeight,
      \u003C\u0024\u003Elist = list
    };
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage");
  }
}
