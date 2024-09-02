// Decompiled with JetBrains decompiler
// Type: Battle01TipEventBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public abstract class Battle01TipEventBase : NGBattleMenuBase
{
  [SerializeField]
  private UILabel text;
  [SerializeField]
  private UI2DSprite[] icons;

  protected T cloneIcon<T>(GameObject prefab, int idx = 0) where T : IconPrefabBase
  {
    if (idx >= this.icons.Length)
      return (T) null;
    UI2DSprite icon = this.icons[idx];
    ((Behaviour) icon).enabled = false;
    T component = prefab.CloneAndGetComponent<T>(((Component) icon).gameObject);
    NGUITools.AdjustDepth(component.gameObject, icon.depth);
    component.SetBasedOnHeight(icon.height);
    return component;
  }

  protected T getIcon<T>(int idx) where T : IconPrefabBase
  {
    if (idx >= this.icons.Length)
      return (T) null;
    IconPrefabBase[] componentsInChildren = ((Component) this.icons[idx]).GetComponentsInChildren<IconPrefabBase>(true);
    return componentsInChildren.Length > 0 ? componentsInChildren[0] as T : (T) null;
  }

  protected void selectIcon(int idx)
  {
    for (int index = 0; index < this.icons.Length; ++index)
      ((Component) this.icons[index]).gameObject.SetActive(idx == index);
  }

  public void setText(string s) => this.text.SetText(s);

  public abstract void setData(BL.DropData e, BL.Unit unit);
}
