// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.20
// 

using Colyseus.Schema;
using Action = System.Action;

namespace MiraboSync.Colyseus {
	public partial class Hand : Schema {
		[Type(0, "string")]
		public string state = default(string);

		[Type(1, "ref", typeof(Transform))]
		public Transform transform = new Transform();

		/*
		 * Support for individual property change callbacks below...
		 */

		protected event PropertyChangeHandler<string> __stateChange;
		public Action OnStateChange(PropertyChangeHandler<string> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.state));
			__stateChange += __handler;
			if (__immediate && this.state != default(string)) { __handler(this.state, default(string)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(state));
				__stateChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<Transform> __transformChange;
		public Action OnTransformChange(PropertyChangeHandler<Transform> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.transform));
			__transformChange += __handler;
			if (__immediate && this.transform != null) { __handler(this.transform, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(transform));
				__transformChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(state): __stateChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
				case nameof(transform): __transformChange?.Invoke((Transform) change.Value, (Transform) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
