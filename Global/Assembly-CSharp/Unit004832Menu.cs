// Decompiled with JetBrains decompiler
// Type: Unit004832Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit004832Menu : BackButtonMenuBase
{
  [SerializeField]
  public GameObject DirCharaForm1;
  [SerializeField]
  public GameObject DirCharaForm2;
  [SerializeField]
  public UI2DSprite[] LinkCharacter1;
  [SerializeField]
  public UI2DSprite[] LinkCharacter2;
  [SerializeField]
  public UI2DSprite[] LinkCharacter3;
  [SerializeField]
  public UI2DSprite[] LinkCharacter4;
  [SerializeField]
  public UI2DSprite[] LinkCharacter5;
  [SerializeField]
  protected UILabel TxtDescription;
  [SerializeField]
  protected UILabel TxtPopuptitle;
  [SerializeField]
  protected UILabel TxtREADME;
  private PlayerUnit[] selectUnit;
  private PlayerUnit baseUnit;
  private Unit00483Menu menu00483;

  public Unit00468Scene.Mode mode { get; set; }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnPopupYes()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.StartCoroutine(this.combine());
  }

  private void SetCharaForm01()
  {
    this.DirCharaForm1.SetActive(true);
    this.DirCharaForm2.SetActive(false);
  }

  private void SetCharaForm02()
  {
    this.DirCharaForm1.SetActive(false);
    this.DirCharaForm2.SetActive(true);
  }

  [DebuggerHidden]
  public IEnumerator SetSelectedUnitIcons(
    Unit00483Menu menu,
    PlayerUnit[] rariMaterials,
    PlayerUnit basePlayerUnit,
    PlayerUnit[] materialUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004832Menu.\u003CSetSelectedUnitIcons\u003Ec__Iterator2D5()
    {
      menu = menu,
      basePlayerUnit = basePlayerUnit,
      materialUnit = materialUnit,
      rariMaterials = rariMaterials,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EmaterialUnit = materialUnit,
      \u003C\u0024\u003ErariMaterials = rariMaterials,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator combine()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004832Menu.\u003Ccombine\u003Ec__Iterator2D6()
    {
      \u003C\u003Ef__this = this
    };
  }
}
