﻿// Decompiled with JetBrains decompiler
// Type: GuideUnitJob
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GuideUnitJob : MonoBehaviour
{
  [SerializeField]
  private GameObject selectObj;
  [SerializeField]
  private UIButton button;
  private bool isEnable = true;
  private int job_id;
  private Guide01122Menu menu;
  private GuideRaritySelectDialog dialog;

  public Guide01122Menu Menu => this.menu;

  public void pressButton() => this.dialog.onJobButton(this.job_id);

  public void Set(
    Guide01122Menu menu01122,
    GuideRaritySelectDialog dialog,
    bool isEnable,
    int job_id)
  {
    this.menu = menu01122;
    this.dialog = dialog;
    this.isEnable = isEnable;
    this.job_id = job_id;
  }

  public void SetSelect(int select_job_id)
  {
    bool flag = this.job_id == select_job_id;
    this.selectObj.SetActive(flag && this.isEnable);
    if (!(bool) (Object) this.button)
      return;
    this.button.isEnabled = this.isEnable;
    this.button.enabled = !flag;
  }
}
