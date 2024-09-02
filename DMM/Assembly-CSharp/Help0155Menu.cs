// Decompiled with JetBrains decompiler
// Type: Help0155Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Help0155Menu : BackButtonMenuBase
{
  [SerializeField]
  protected GameObject ScrollGrid;
  public NGxScroll scroll;
  public UIScrollView scrollview;
  private GameObject barPrefab;

  public virtual void Foreground()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public IEnumerator InitBeginnerNavi()
  {
    Help0155Menu help0155Menu = this;
    ((IEnumerable<BeginnerNaviCategory>) MasterData.BeginnerNaviCategoryList).OrderBy<BeginnerNaviCategory, int>((Func<BeginnerNaviCategory, int>) (x => x.priority));
    List<BeginnerNaviCategory> categoryList = new List<BeginnerNaviCategory>();
    Future<GameObject> prefabF = Res.Prefabs.help015_5.vscrollhelp5_682_33.Load<GameObject>();
    IEnumerator e = prefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    help0155Menu.barPrefab = prefabF.Result;
    categoryList.Clear();
    help0155Menu.scroll.Clear();
    foreach (BeginnerNaviCategory bnCategory in (IEnumerable<BeginnerNaviCategory>) ((IEnumerable<BeginnerNaviCategory>) MasterData.BeginnerNaviCategoryList).OrderBy<BeginnerNaviCategory, int>((Func<BeginnerNaviCategory, int>) (x => x.priority)))
    {
      GameObject gameObject = help0155Menu.barPrefab.Clone();
      help0155Menu.scroll.Add(gameObject);
      Help0155Button component = gameObject.GetComponent<Help0155Button>();
      component.init((BackButtonMenuBase) help0155Menu);
      component.setNaviText(bnCategory, false);
    }
    help0155Menu.scroll.grid.Reposition();
    help0155Menu.scroll.scrollView.ResetPosition();
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
