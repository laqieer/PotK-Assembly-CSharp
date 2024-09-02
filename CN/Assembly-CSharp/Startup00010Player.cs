﻿// Decompiled with JetBrains decompiler
// Type: Startup00010Player
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Startup00010Player : MonoBehaviour
{
  public Animator animatorControll;
  public BoxCollider weraponCollider;
  public bool attackFlag;
  public int state;

  public bool Attack()
  {
    this.animatorControll.SetTrigger("isAttack");
    if (!this.attackFlag)
      this.state = 1;
    return true;
  }

  public void FixedUpdate()
  {
    switch (this.state)
    {
      case 0:
        ((Collider) this.weraponCollider).enabled = false;
        this.weraponCollider.size = new Vector3(1f, 2f, 3f);
        this.attackFlag = false;
        break;
      case 1:
        ((Collider) this.weraponCollider).enabled = true;
        this.weraponCollider.size = new Vector3(1f, 2f, 3f);
        this.attackFlag = true;
        this.state = 2;
        break;
      case 2:
        this.state = 3;
        break;
      case 3:
        this.weraponCollider.size = new Vector3(10f, 10f, 10f);
        this.state = 0;
        break;
    }
  }
}
