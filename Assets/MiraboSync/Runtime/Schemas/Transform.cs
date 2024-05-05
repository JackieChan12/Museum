// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.20
// 

using Colyseus.Schema;
using Action = System.Action;

namespace MiraboSync.Colyseus {
	public partial class Transform : Schema {
		[Type(0, "ref", typeof(Vector3))]
		public Vector3 position = new Vector3();

		[Type(1, "ref", typeof(Vector3))]
		public Vector3 rotation = new Vector3();

		[Type(2, "ref", typeof(Vector3))]
		public Vector3 scale = new Vector3();

		/*
		 * Support for individual property change callbacks below...
		 */

		protected event PropertyChangeHandler<Vector3> __positionChange;
		public Action OnPositionChange(PropertyChangeHandler<Vector3> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.position));
			__positionChange += __handler;
			if (__immediate && this.position != null) { __handler(this.position, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(position));
				__positionChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<Vector3> __rotationChange;
		public Action OnRotationChange(PropertyChangeHandler<Vector3> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.rotation));
			__rotationChange += __handler;
			if (__immediate && this.rotation != null) { __handler(this.rotation, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(rotation));
				__rotationChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<Vector3> __scaleChange;
		public Action OnScaleChange(PropertyChangeHandler<Vector3> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.scale));
			__scaleChange += __handler;
			if (__immediate && this.scale != null) { __handler(this.scale, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(scale));
				__scaleChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(position): __positionChange?.Invoke((Vector3) change.Value, (Vector3) change.PreviousValue); break;
				case nameof(rotation): __rotationChange?.Invoke((Vector3) change.Value, (Vector3) change.PreviousValue); break;
				case nameof(scale): __scaleChange?.Invoke((Vector3) change.Value, (Vector3) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
