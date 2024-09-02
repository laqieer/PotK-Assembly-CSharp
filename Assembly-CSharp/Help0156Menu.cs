// Decompiled with JetBrains decompiler
// Type: Help0156Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help0156Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtHelp01;
  [SerializeField]
  protected UILabel TxtTitle;
  public NGxScroll scroll;
  public UIScrollView scrollview;

  public virtual void Foreground()
  {
  }

  public virtual void IbtnHelp()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public IEnumerator InitBeginnerNaviTitle(List<BeginnerNaviTitle> bnTitles)
  {
    Help0156Menu help0156Menu = this;
    using (List<BeginnerNaviTitle>.Enumerator enumerator = bnTitles.GetEnumerator())
    {
      if (enumerator.MoveNext())
      {
        BeginnerNaviTitle current = enumerator.Current;
        help0156Menu.TxtTitle.text = current.category.name;
      }
    }
    Future<GameObject> prefabF = Res.Prefabs.help015_6.vscrollhelp6_682_33.Load<GameObject>();
    IEnumerator e = prefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject prefab = prefabF.Result;
    help0156Menu.scroll.Clear();
    int counter = 0;
    foreach (BeginnerNaviTitle bnTitle in bnTitles)
    {
      GameObject gameObject = prefab.Clone();
      Help0156Button component = gameObject.GetComponent<Help0156Button>();
      component.init((BackButtonMenuBase) help0156Menu);
      help0156Menu.scroll.Add(gameObject);
      e = component.setTitleText(bnTitle);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      ++counter;
    }
    help0156Menu.scroll.grid.Reposition();
    help0156Menu.scroll.scrollView.ResetPosition();
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
