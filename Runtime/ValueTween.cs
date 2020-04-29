using System;
using ElRaccoone.Tweens.Core;
using UnityEngine;

namespace ElRaccoone.Tweens {
  public static class ValueTween {
    public static Tween<float> TweenValue (this Component self, float to, float duration) =>
      Tween<float>.Add<Driver> (self).Finalize (duration, to);

    public static Tween<float> TweenValue (this GameObject self, float to, float duration) =>
      Tween<float>.Add<Driver> (self).Finalize (duration, to);

    private class Driver : Tween<float> {
      private Action<float> onUpdate = null;
      private bool hasOnUpdate = false;

      public override bool OnInitialize () {
        return true;
      }

      public override float OnGetFrom () {
        return 0;
      }

      public override void OnUpdate (float easedTime) {
        this.valueCurrent = this.InterpolateValue (this.valueFrom, this.valueTo, easedTime);
        if (this.hasOnUpdate == true)
          this.onUpdate (this.valueCurrent);
      }

      public Tween<float> SetOnUpdate (Action<float> onUpdate) {
        this.onUpdate = onUpdate;
        this.hasOnUpdate = true;
        return this;
      }
    }
  }
}