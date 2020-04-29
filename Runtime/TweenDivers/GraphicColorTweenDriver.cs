using ElRaccoone.Tweens.Core;
using UnityEngine;
using UnityEngine.UI;

namespace ElRaccoone.Tweens.TweenDrivers {
  [AddComponentMenu ("")]
  public class GraphicColorTweenDriver : Tween<Color> {
    private Graphic graphic;

    public override bool OnInitialize () {
      this.graphic = this.gameObject.GetComponent<Graphic> ();
      return this.graphic != null;
    }

    public override Color OnGetFrom () {
      return this.graphic.color;
    }

    public override void OnUpdate (float easedTime) {
      this.valueCurrent.r = this.InterpolateValue (this.valueFrom.r, this.valueTo.r, easedTime);
      this.valueCurrent.g = this.InterpolateValue (this.valueFrom.g, this.valueTo.g, easedTime);
      this.valueCurrent.b = this.InterpolateValue (this.valueFrom.b, this.valueTo.b, easedTime);
      this.valueCurrent.a = this.InterpolateValue (this.valueFrom.a, this.valueTo.a, easedTime);
      this.graphic.color = this.valueCurrent;
    }
  }
}