// Decompiled with JetBrains decompiler
// Type: GuildMapStorageScroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System.Collections;
using UnityEngine;

public class GuildMapStorageScroll : MonoBehaviour
{
  [SerializeField]
  private UILabel lblMapName;
  [SerializeField]
  private UILabel lblCost;
  [SerializeField]
  private UILabel lblDescription;
  [SerializeField]
  private GameObject dyn_map_thumb_container;
  private System.Action<PlayerGuildTown> actionSelect;
  private PlayerGuildTown guildTown;
  private bool isPush;

  private bool isPushAndSet()
  {
    if (this.isPush)
      return true;
    this.isPush = true;
    return false;
  }

  public IEnumerator InitializeAsync(
    PlayerGuildTown guildTown,
    System.Action<PlayerGuildTown> actionSelect)
  {
    this.lblMapName.SetTextLocalize(guildTown.master.name);
    this.lblCost.SetTextLocalize(guildTown.master.cost_capacity);
    this.lblDescription.SetTextLocalize(guildTown.master.description);
    CreateIconObject orAddComponent = this.dyn_map_thumb_container.GetOrAddComponent<CreateIconObject>();
    if ((UnityEngine.Object) orAddComponent != (UnityEngine.Object) null)
    {
      IEnumerator e = orAddComponent.CreateThumbnail(MasterDataTable.CommonRewardType.guild_town, guildTown.master.ID, visibleBottom: false);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    this.actionSelect = actionSelect;
    this.guildTown = guildTown;
  }

  public void onThumbnailButton()
  {
    if (this.isPushAndSet() || this.actionSelect == null)
      return;
    this.actionSelect(this.guildTown);
    this.isPush = false;
  }
}
