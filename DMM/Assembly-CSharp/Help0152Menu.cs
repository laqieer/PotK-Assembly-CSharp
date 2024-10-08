﻿// Decompiled with JetBrains decompiler
// Type: Help0152Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help0152Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtHelp01;
  [SerializeField]
  protected UILabel TxtTitle;
  public NGxScroll scroll;
  public UIScrollView scrollview;
  private string title;

  public string titleName => this.title;

  public virtual void Foreground()
  {
  }

  public virtual void IbtnHelp()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public IEnumerator InitSubCatecory(List<HelpHelp> helps)
  {
    Help0152Menu help0152Menu = this;
    using (List<HelpHelp>.Enumerator enumerator = helps.GetEnumerator())
    {
      if (enumerator.MoveNext())
      {
        HelpHelp current = enumerator.Current;
        help0152Menu.TxtTitle.SetText(current.category.name);
        help0152Menu.title = current.category.name;
      }
    }
    Future<GameObject> prefabF = Res.Prefabs.help015_2.vscrollhelp2_682_33.Load<GameObject>();
    IEnumerator e = prefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject prefab = prefabF.Result;
    help0152Menu.scroll.Clear();
    int counter = 0;
    foreach (HelpHelp help in helps)
    {
      GameObject gameObject = prefab.Clone();
      Help0152Button component = gameObject.GetComponent<Help0152Button>();
      component.init((BackButtonMenuBase) help0152Menu);
      help0152Menu.scroll.Add(gameObject);
      e = component.setTextHelp01(help.subcategory_name, help);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      ++counter;
    }
    help0152Menu.scroll.grid.Reposition();
    help0152Menu.scroll.scrollView.ResetPosition();
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    NGSceneManager instance1 = Singleton<NGSceneManager>.GetInstance();
    if (instance1.backScene())
      return;
    CommonRoot instance2 = Singleton<CommonRoot>.GetInstance();
    NGGameDataManager instance3 = Singleton<NGGameDataManager>.GetInstance();
    instance2.ShowLoadingLayer(0);
    instance3.lastReferenceUnitID = -1;
    instance3.lastReferenceUnitIndex = -1;
    instance1.destroyLoadedScenes();
    instance1.clearStack();
    instance1.changeScene(instance2.startScene, false, instance2.startSceneArgs);
  }

  public override void onBackButton() => this.IbtnBack();
}
