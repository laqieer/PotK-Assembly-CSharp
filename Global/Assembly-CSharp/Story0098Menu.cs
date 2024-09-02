// Decompiled with JetBrains decompiler
// Type: Story0098Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0098Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private NGxScroll scroll;

  public virtual void Foreground()
  {
  }

  public virtual void IbtnEvent()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_0");
  }

  [DebuggerHidden]
  public IEnumerator InitScene(bool connect)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0098Menu.\u003CInitScene\u003Ec__Iterator48E()
    {
      connect = connect,
      \u003C\u0024\u003Econnect = connect,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ScrollInit(QuestExtraS extra, GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0098Menu.\u003CScrollInit\u003Ec__Iterator48F()
    {
      prefab = prefab,
      extra = extra,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u003Ef__this = this
    };
  }

  public void onOver(GameObject obj)
  {
    if (this.IsPush)
      return;
    ((Component) obj.GetComponent<Story0098Scroll>().IdleSprite).gameObject.SetActive(false);
    ((Component) obj.GetComponent<Story0098Scroll>().PressSprite).gameObject.SetActive(true);
  }

  public void onOut(GameObject obj)
  {
    if (this.IsPush)
      return;
    ((Component) obj.GetComponent<Story0098Scroll>().IdleSprite).gameObject.SetActive(true);
    ((Component) obj.GetComponent<Story0098Scroll>().PressSprite).gameObject.SetActive(false);
  }

  public void changeScene00983(QuestExtraS extra)
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_8_3", false, (object) extra.ID);
  }

  public void changeScene00985(QuestExtraS extra)
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_8_5", false, (object) extra.ID, (object) false);
  }
}
