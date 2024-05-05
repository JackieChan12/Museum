// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.20
// 

using Colyseus.Schema;
using Action = System.Action;

namespace MiraboSync.Colyseus {
	public partial class RGBA : Schema {
		[Type(0, "float32")]
		public float R = default(float);

		[Type(1, "float32")]
		public float G = default(float);

		[Type(2, "float32")]
		public float B = default(float);

		[Type(3, "float32")]
		public float A = default(float);

		/*
		 * Support for individual property change callbacks below...
		 */

		protected event PropertyChangeHandler<float> __RChange;
		public Action OnRChange(PropertyChangeHandler<float> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.R));
			__RChange += __handler;
			if (__immediate && this.R != default(float)) { __handler(this.R, default(float)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(R));
				__RChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<float> __GChange;
		public Action OnGChange(PropertyChangeHandler<float> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.G));
			__GChange += __handler;
			if (__immediate && this.G != default(float)) { __handler(this.G, default(float)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(G));
				__GChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<float> __BChange;
		public Action OnBChange(PropertyChangeHandler<float> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.B));
			__BChange += __handler;
			if (__immediate && this.B != default(float)) { __handler(this.B, default(float)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(B));
				__BChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<float> __AChange;
		public Action OnAChange(PropertyChangeHandler<float> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.A));
			__AChange += __handler;
			if (__immediate && this.A != default(float)) { __handler(this.A, default(float)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(A));
				__AChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(R): __RChange?.Invoke((float) change.Value, (float) change.PreviousValue); break;
				case nameof(G): __GChange?.Invoke((float) change.Value, (float) change.PreviousValue); break;
				case nameof(B): __BChange?.Invoke((float) change.Value, (float) change.PreviousValue); break;
				case nameof(A): __AChange?.Invoke((float) change.Value, (float) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
