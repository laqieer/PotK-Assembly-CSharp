// Decompiled with JetBrains decompiler
// Type: BattlePanelParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class BattlePanelParts : BattleMonoBehaviour
{
  public Material[] cellMaterials;
  private BL.BattleModified<BL.Panel> modified;
  private FieldButton attackButton;
  private FieldButton healButton;
  private FieldButton loadingButton;
  private GameObject fieldEventEffect;

  private FieldButton cloneButton(GameObject prefab)
  {
    FieldButton component = prefab.CloneAndGetComponent<FieldButton>(((Component) this).transform);
    ((Component) component).transform.localPosition = this.getLocalPosition();
    return component;
  }

  public void setGuardArea(GameObject prefab)
  {
    prefab.Clone(((Component) this).transform).transform.localPosition = this.getLocalPosition();
  }

  public void initButtons(GameObject attack, GameObject heal, GameObject loading)
  {
    this.attackButton = this.cloneButton(attack);
    this.attackButton.isActive = false;
    this.healButton = this.cloneButton(heal);
    this.healButton.isActive = false;
    this.loadingButton = this.cloneButton(loading);
    this.loadingButton.isActive = false;
  }

  public void setAttackButton(GameObject prefab)
  {
    if (Object.op_Equality((Object) this.attackButton, (Object) null))
      this.attackButton = this.cloneButton(prefab);
    this.attackButton.isActive = true;
    if (Object.op_Inequality((Object) this.healButton, (Object) null))
      this.healButton.isActive = false;
    if (!Object.op_Inequality((Object) this.loadingButton, (Object) null))
      return;
    this.loadingButton.isActive = false;
  }

  public void setHealButton(GameObject prefab)
  {
    if (Object.op_Equality((Object) this.healButton, (Object) null))
      this.healButton = this.cloneButton(prefab);
    this.healButton.isActive = true;
    if (Object.op_Inequality((Object) this.attackButton, (Object) null))
      this.attackButton.isActive = false;
    if (!Object.op_Inequality((Object) this.loadingButton, (Object) null))
      return;
    this.loadingButton.isActive = false;
  }

  public void setLoadingButton(GameObject prefab)
  {
    if (Object.op_Equality((Object) this.loadingButton, (Object) null))
      this.loadingButton = this.cloneButton(prefab);
    this.loadingButton.isActive = true;
    if (Object.op_Inequality((Object) this.attackButton, (Object) null))
      this.attackButton.isActive = false;
    if (!Object.op_Inequality((Object) this.healButton, (Object) null))
      return;
    this.healButton.isActive = false;
  }

  public void hideButton()
  {
    if (Object.op_Inequality((Object) this.attackButton, (Object) null))
      this.attackButton.isActive = false;
    if (Object.op_Inequality((Object) this.healButton, (Object) null))
      this.healButton.isActive = false;
    if (!Object.op_Inequality((Object) this.loadingButton, (Object) null))
      return;
    this.loadingButton.isActive = false;
  }

  public void buttonDown(bool v)
  {
    if (Object.op_Inequality((Object) this.attackButton, (Object) null) && this.attackButton.isActive)
      this.attackButton.isDown = v;
    if (Object.op_Inequality((Object) this.healButton, (Object) null) && this.healButton.isActive)
      this.healButton.isDown = v;
    if (!Object.op_Inequality((Object) this.loadingButton, (Object) null) || !this.loadingButton.isActive)
      return;
    this.loadingButton.isDown = v;
  }

  public void setPanel(BL.Panel panel)
  {
    this.modified = BL.Observe<BL.Panel>(panel);
    this.env.panelResource[panel].gameObject = ((Component) this).gameObject;
    if (!panel.hasEvent || !Object.op_Inequality((Object) this.env.dropDataResource[panel.fieldEvent].prefab, (Object) null))
      return;
    if (Object.op_Inequality((Object) this.fieldEventEffect, (Object) null))
      Object.Destroy((Object) this.fieldEventEffect);
    this.fieldEventEffect = this.env.dropDataResource[panel.fieldEvent].prefab.Clone(((Component) this).transform);
    this.fieldEventEffect.transform.localPosition = this.getLocalPosition();
  }

  public Vector3 getLocalPosition()
  {
    return new Vector3(0.0f, ((Component) this).GetComponent<PanelInit>().panelHeightNonScale + 0.1f, 0.0f);
  }

  public BL.Panel getPanel() => this.modified.value;

  public float getHeight() => ((Component) this).GetComponent<PanelInit>().panelHeight;

  private Material attributeMaterial(BL.Panel panel)
  {
    if (panel.checkAttribute(BL.PanelAttribute.test))
      return this.cellMaterials[4];
    if (panel.checkAttribute(BL.PanelAttribute.target_heal))
      return this.cellMaterials[3];
    if (panel.checkAttribute(BL.PanelAttribute.target_attack))
      return this.cellMaterials[5];
    if (panel.checkAttribute(BL.PanelAttribute.heal_range))
      return this.cellMaterials[3];
    if (panel.checkAttribute(BL.PanelAttribute.attack_range))
      return this.cellMaterials[5];
    if (panel.checkAttribute(BL.PanelAttribute.moving))
      return this.cellMaterials[7];
    if (panel.checkAttribute(BL.PanelAttribute.playermove))
      return this.cellMaterials[1];
    if (panel.checkAttribute(BL.PanelAttribute.neutralmove) || panel.checkAttribute(BL.PanelAttribute.enemymove))
      return this.cellMaterials[2];
    return panel.checkAttribute(BL.PanelAttribute.danger) ? this.cellMaterials[4] : this.cellMaterials[0];
  }

  protected override void LateUpdate_Battle()
  {
    if (!this.modified.isChangedOnce())
      return;
    BL.Panel panel = this.modified.value;
    Material material = this.attributeMaterial(panel);
    if (Object.op_Inequality((Object) ((Component) this).GetComponent<Renderer>().material, (Object) material))
      ((Component) this).GetComponent<Renderer>().material = material;
    if (!Object.op_Inequality((Object) this.fieldEventEffect, (Object) null) || panel.hasEvent)
      return;
    Object.Destroy((Object) this.fieldEventEffect);
    this.fieldEventEffect = (GameObject) null;
  }
}
