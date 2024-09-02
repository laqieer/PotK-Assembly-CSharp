// Decompiled with JetBrains decompiler
// Type: ArmorSythesisAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ArmorSythesisAnim : MonoBehaviour
{
  public List<MeshRenderer> thum_list;
  public List<ArmorSythesisAnim.MeshIDList> mesh_id_list;
  public List<GameObject> energy_list;
  public MeshRenderer target_thum;

  public ArmorSythesisAnim.MeshIDList AddMeshIdList(
    MeshRenderer mesh,
    PlayerItem playerItem,
    GameObject obj)
  {
    ArmorSythesisAnim.MeshIDList meshIdList = new ArmorSythesisAnim.MeshIDList();
    meshIdList.mesh = mesh;
    meshIdList.playerItem = playerItem;
    meshIdList.SetCloneIcon(obj);
    if (this.mesh_id_list == null)
      this.mesh_id_list = new List<ArmorSythesisAnim.MeshIDList>();
    this.mesh_id_list.Add(meshIdList);
    return meshIdList;
  }

  public class MeshIDList
  {
    public MeshRenderer mesh;
    public AnimationItemIcon icon;

    public PlayerItem playerItem { get; set; }

    public AnimationItemIcon SetCloneIcon(GameObject obj)
    {
      if (Object.op_Equality((Object) this.icon, (Object) null))
        this.icon = obj.Clone(((Component) this.mesh).transform).GetComponent<AnimationItemIcon>();
      ((Component) this.icon).transform.localPosition = new Vector3(0.0f, 0.0f, -0.05f);
      ((Object) ((Component) this.icon).gameObject).name = "AnimationItemIcon";
      this.icon.Set(this.playerItem);
      return this.icon;
    }
  }
}
