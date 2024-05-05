// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.20
// 

using Colyseus.Schema;
using Action = System.Action;

namespace MiraboSync.Colyseus {
	public partial class Image : Schema {
		[Type(0, "ref", typeof(Transform))]
		public Transform transform = new Transform();

		[Type(1, "string")]
		public string uri = default(string);

		/*
		 * Support for individual property change callbacks below...
		 */

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

		protected event PropertyChangeHandler<string> __uriChange;
		public Action OnUriChange(PropertyChangeHandler<string> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.uri));
			__uriChange += __handler;
			if (__immediate && this.uri != default(string)) { __handler(this.uri, default(string)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(uri));
				__uriChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(transform): __transformChange?.Invoke((Transform) change.Value, (Transform) change.PreviousValue); break;
				case nameof(uri): __uriChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
