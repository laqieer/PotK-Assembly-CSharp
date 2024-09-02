// Decompiled with JetBrains decompiler
// Type: DetailMenuScrollViewBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System.Collections;
using UnitDetails;
using UnityEngine;

public class DetailMenuScrollViewBase : MonoBehaviour
{
  public bool isEarthMode;
  public bool isMemory;

  public Control controlFlags { get; private set; }

  public void setControlFlags(Unit0042Scene menu)
  {
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    this.setControlFlags(menu.bootParam.controlFlags);
  }

  public void setControlFlags(Control flags) => this.controlFlags = flags;

  public virtual bool Init(PlayerUnit playerUnit, PlayerUnit baseUnit)
  {
    this.gameObject.SetActive(true);
    return true;
  }

  public virtual IEnumerator setModel(
    PlayerUnit playerUnit,
    GameObject modelPrefab,
    Vector3 modelPos,
    bool light,
    System.Action action = null)
  {
    yield break;
  }

  public virtual IEnumerator initAsync(
    PlayerUnit playerUnit,
    bool limitMode,
    bool isMaterial,
    GameObject[] prefabs = null)
  {
    yield break;
  }

  protected virtual void setText(UILabel label, int v) => label.SetTextLocalize(v);

  public virtual void EndScene()
  {
  }

  public virtual void MarkAsChanged()
  {
  }

  public virtual IEnumerator initAsyncDiffMode(
    PlayerUnit playerUnit,
    PlayerUnit prevUnit,
    IDetailMenuContainer menuContainer)
  {
    yield break;
  }

  protected void inactivateGameObject<T>(T co) where T : Component
  {
    if (!((UnityEngine.Object) co != (UnityEngine.Object) null))
      return;
    co.gameObject.SetActive(false);
  }

  protected void inactivateGameObject(GameObject go)
  {
    if (!((UnityEngine.Object) go != (UnityEngine.Object) null))
      return;
    go.SetActive(false);
  }
}
