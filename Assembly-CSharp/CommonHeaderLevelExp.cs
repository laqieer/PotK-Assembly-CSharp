// Decompiled with JetBrains decompiler
// Type: CommonHeaderLevelExp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using UnityEngine;

public class CommonHeaderLevelExp : MonoBehaviour
{
  public UILabel _lbl_level;
  public UILabel _lbl_remain_exp;
  public GameObject _go_exp_gauge;
  private Vector3 _exp_gauge_scale;

  private void Start()
  {
    if (!(bool) (Object) this._go_exp_gauge)
      return;
    this._exp_gauge_scale = this._go_exp_gauge.transform.localScale;
  }

  public void updateData()
  {
    Player current = Player.Current;
    if ((bool) (Object) this._lbl_level)
      this._lbl_level.SetTextLocalize(current.level.ToString());
    if ((bool) (Object) this._lbl_remain_exp)
      this._lbl_remain_exp.SetTextLocalize(current.exp_next.ToString());
    if (!(bool) (Object) this._go_exp_gauge)
      return;
    this._go_exp_gauge.transform.localScale = current.exp_next == 0 ? this._exp_gauge_scale : new Vector3(this._exp_gauge_scale.x * (float) current.exp / (float) (current.exp + current.exp_next), this._exp_gauge_scale.y, this._exp_gauge_scale.z);
  }
}
