// Decompiled with JetBrains decompiler
// Type: Battle01TipEventBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

public abstract class Battle01TipEventBase : NGBattleMenuBase
{
  [SerializeField]
  private UILabel text;
  [SerializeField]
  private UI2DSprite[] icons;

  protected T cloneIcon<T>(GameObject prefab, int idx = 0) where T : IconPrefabBase
  {
    if (idx >= this.icons.Length)
      return default (T);
    UI2DSprite icon = this.icons[idx];
    icon.enabled = false;
    T component = prefab.CloneAndGetComponent<T>(icon.gameObject);
    NGUITools.AdjustDepth(component.gameObject, icon.depth);
    component.SetBasedOnHeight(icon.height);
    return component;
  }

  protected T getIcon<T>(int idx) where T : IconPrefabBase
  {
    if (idx >= this.icons.Length)
      return default (T);
    IconPrefabBase[] componentsInChildren = this.icons[idx].GetComponentsInChildren<IconPrefabBase>(true);
    return componentsInChildren.Length != 0 ? componentsInChildren[0] as T : default (T);
  }

  protected void selectIcon(int idx)
  {
    for (int index = 0; index < this.icons.Length; ++index)
      this.icons[index].gameObject.SetActive(idx == index);
  }

  protected void disableAllIcon()
  {
    for (int index = 0; index < this.icons.Length; ++index)
      this.icons[index].gameObject.SetActive(false);
  }

  public void setText(string s) => this.text.SetText(s);

  public abstract void setData(BL.DropData e, BL.Unit unit);
}
