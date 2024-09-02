// Decompiled with JetBrains decompiler
// Type: LockFreeQueue`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Threading;

#nullable disable
public class LockFreeQueue<T>
{
  public int head;
  public int tail;
  public T[] items;
  private int capacity;

  public LockFreeQueue()
    : this(64)
  {
  }

  public LockFreeQueue(int count)
  {
    this.items = new T[count];
    this.tail = this.head = 0;
    this.capacity = count;
  }

  public int Count => this.tail - this.head;

  public bool IsEmpty() => this.head == this.tail;

  public void Clear() => this.head = this.tail = 0;

  private bool IsFull() => this.tail - this.head >= this.capacity;

  public void Enqueue(T item)
  {
    while (this.IsFull())
      Thread.Sleep(1);
    this.items[this.tail % this.capacity] = item;
    ++this.tail;
  }

  public T Dequeue()
  {
    if (this.IsEmpty())
      return default (T);
    T obj = this.items[this.head % this.capacity];
    ++this.head;
    return obj;
  }
}
