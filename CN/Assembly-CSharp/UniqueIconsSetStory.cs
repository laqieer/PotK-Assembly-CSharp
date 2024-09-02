// Decompiled with JetBrains decompiler
// Type: UniqueIconsSetStory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class UniqueIconsSetStory : MonoBehaviour
{
  private const int UNIQUE_ICON_SIZE = 100;
  [HideInInspector]
  public GameObject LinkPrefab;
  [HideInInspector]
  public Transform LinkParent;
  [SerializeField]
  private UISprite BackGround;
  private int spritewidth = 65;
  private int spriteheight = 65;
  private bool notSizeChange;

  [HideInInspector]
  public string name { get; set; }

  [DebuggerHidden]
  public IEnumerator SetIconUnique(
    string name,
    MasterDataTable.CommonRewardType entity_type,
    int entity_id,
    int quantity,
    Transform parent,
    bool nonSizeChange = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIconsSetStory.\u003CSetIconUnique\u003Ec__Iterator235()
    {
      nonSizeChange = nonSizeChange,
      name = name,
      parent = parent,
      entity_type = entity_type,
      entity_id = entity_id,
      quantity = quantity,
      \u003C\u0024\u003EnonSizeChange = nonSizeChange,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003Eentity_type = entity_type,
      \u003C\u0024\u003Eentity_id = entity_id,
      \u003C\u0024\u003Equantity = quantity,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetIconUnique(
    string name,
    Transform parent,
    QuestStoryMission story = null,
    QuestExtraMission extra = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIconsSetStory.\u003CSetIconUnique\u003Ec__Iterator236()
    {
      story = story,
      name = name,
      parent = parent,
      extra = extra,
      \u003C\u0024\u003Estory = story,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator unitCreate(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIconsSetStory.\u003CunitCreate\u003Ec__Iterator237()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator gearCreate(GearGear gear, int quan)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIconsSetStory.\u003CgearCreate\u003Ec__Iterator238()
    {
      gear = gear,
      quan = quan,
      \u003C\u0024\u003Egear = gear,
      \u003C\u0024\u003Equan = quan,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator supplyCreate(SupplySupply supply, int quan)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIconsSetStory.\u003CsupplyCreate\u003Ec__Iterator239()
    {
      supply = supply,
      quan = quan,
      \u003C\u0024\u003Esupply = supply,
      \u003C\u0024\u003Equan = quan,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator moneyCreate(int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIconsSetStory.\u003CmoneyCreate\u003Ec__Iterator23A()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator kisekiCreate(int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIconsSetStory.\u003CkisekiCreate\u003Ec__Iterator23B()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator friendpointCreate(int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIconsSetStory.\u003CfriendpointCreate\u003Ec__Iterator23C()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator medalCreate(int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIconsSetStory.\u003CmedalCreate\u003Ec__Iterator23D()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator keyCreate(int id, int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIconsSetStory.\u003CkeyCreate\u003Ec__Iterator23E()
    {
      id = id,
      count = count,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ticketCreate(int id, int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniqueIconsSetStory.\u003CticketCreate\u003Ec__Iterator23F()
    {
      count = count,
      id = id,
      \u003C\u0024\u003Ecount = count,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  private void AdjustSizeOfIcon(UIWidget widget)
  {
    widget.width = 100;
    widget.height = 100;
  }

  private void SetDepth(GameObject iconObj)
  {
    if (Object.op_Equality((Object) this.BackGround, (Object) null))
      return;
    int depth = this.BackGround.depth;
    foreach (UI2DSprite componentsInChild in iconObj.GetComponentsInChildren<UI2DSprite>(true))
      componentsInChild.depth += depth;
  }
}
