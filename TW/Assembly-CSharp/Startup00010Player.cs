﻿// Decompiled with JetBrains decompiler
// Type: Startup00010Player
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
