// Decompiled with JetBrains decompiler
// Type: Guide0111Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
public class Guide0111Menu : BackButtonMenuBase
{
  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public virtual void IbtnBugubook_AnimList3()
  {
    if (this.IsPushAndSet())
      return;
    Guide0114Scene.changeScene(true);
  }

  public virtual void IbtnEnemybook_AnimList2()
  {
    if (this.IsPushAndSet())
      return;
    Guide0113Scene.changeScene(true);
  }

  public virtual void IbtnUnitbook_AnimList1()
  {
    if (this.IsPushAndSet())
      return;
    Guide0112Scene.changeScene(true);
  }

  public override void onBackButton() => this.IbtnBack();
}
