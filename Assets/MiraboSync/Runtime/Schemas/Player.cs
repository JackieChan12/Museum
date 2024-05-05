// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.20
// 

using Colyseus.Schema;
using Action = System.Action;

namespace MiraboSync.Colyseus {
	public partial class Player : Schema {
		[Type(0, "ref", typeof(Hands))]
		public Hands hands = new Hands();

		[Type(1, "ref", typeof(Transform))]
		public Transform head = new Transform();

		[Type(2, "ref", typeof(Vector3))]
		public Vector3 position = new Vector3();

		[Type(3, "ref", typeof(Vector3))]
		public Vector3 rotation = new Vector3();

		[Type(4, "ref", typeof(RGBA))]
		public RGBA color = new RGBA();

		[Type(5, "string")]
		public string avatarId = default(string);

		[Type(6, "string")]
		public string currentClientId = default(string);

		[Type(7, "boolean")]
		public bool connected = default(bool);

		/*
		 * Support for individual property change callbacks below...
		 */

		protected event PropertyChangeHandler<Hands> __handsChange;
		public Action OnHandsChange(PropertyChangeHandler<Hands> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.hands));
			__handsChange += __handler;
			if (__immediate && this.hands != null) { __handler(this.hands, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(hands));
				__handsChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<Transform> __headChange;
		public Action OnHeadChange(PropertyChangeHandler<Transform> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.head));
			__headChange += __handler;
			if (__immediate && this.head != null) { __handler(this.head, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(head));
				__headChange -= __handler;
			};
		}

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

		protected event PropertyChangeHandler<RGBA> __colorChange;
		public Action OnColorChange(PropertyChangeHandler<RGBA> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.color));
			__colorChange += __handler;
			if (__immediate && this.color != null) { __handler(this.color, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(color));
				__colorChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<string> __avatarIdChange;
		public Action OnAvatarIdChange(PropertyChangeHandler<string> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.avatarId));
			__avatarIdChange += __handler;
			if (__immediate && this.avatarId != default(string)) { __handler(this.avatarId, default(string)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(avatarId));
				__avatarIdChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<string> __currentClientIdChange;
		public Action OnCurrentClientIdChange(PropertyChangeHandler<string> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.currentClientId));
			__currentClientIdChange += __handler;
			if (__immediate && this.currentClientId != default(string)) { __handler(this.currentClientId, default(string)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(currentClientId));
				__currentClientIdChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<bool> __connectedChange;
		public Action OnConnectedChange(PropertyChangeHandler<bool> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.connected));
			__connectedChange += __handler;
			if (__immediate && this.connected != default(bool)) { __handler(this.connected, default(bool)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(connected));
				__connectedChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(hands): __handsChange?.Invoke((Hands) change.Value, (Hands) change.PreviousValue); break;
				case nameof(head): __headChange?.Invoke((Transform) change.Value, (Transform) change.PreviousValue); break;
				case nameof(position): __positionChange?.Invoke((Vector3) change.Value, (Vector3) change.PreviousValue); break;
				case nameof(rotation): __rotationChange?.Invoke((Vector3) change.Value, (Vector3) change.PreviousValue); break;
				case nameof(color): __colorChange?.Invoke((RGBA) change.Value, (RGBA) change.PreviousValue); break;
				case nameof(avatarId): __avatarIdChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
				case nameof(currentClientId): __currentClientIdChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
				case nameof(connected): __connectedChange?.Invoke((bool) change.Value, (bool) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
