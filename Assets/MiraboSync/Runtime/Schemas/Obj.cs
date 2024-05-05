// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.20
// 

using Colyseus.Schema;
using Action = System.Action;

namespace MiraboSync.Colyseus {
	public partial class Obj : Schema {
		[Type(0, "string")]
		public string id = default(string);

		[Type(1, "ref", typeof(Transform))]
		public Transform transform = new Transform();

		[Type(2, "string")]
		public string material = default(string);

		[Type(3, "ref", typeof(RGBA))]
		public RGBA color = new RGBA();

		[Type(4, "string")]
		public string model = default(string);

		[Type(5, "string")]
		public string creator = default(string);

		[Type(6, "string")]
		public string editor = default(string);

		/*
		 * Support for individual property change callbacks below...
		 */

		protected event PropertyChangeHandler<string> __idChange;
		public Action OnIdChange(PropertyChangeHandler<string> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.id));
			__idChange += __handler;
			if (__immediate && this.id != default(string)) { __handler(this.id, default(string)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(id));
				__idChange -= __handler;
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

		protected event PropertyChangeHandler<string> __materialChange;
		public Action OnMaterialChange(PropertyChangeHandler<string> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.material));
			__materialChange += __handler;
			if (__immediate && this.material != default(string)) { __handler(this.material, default(string)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(material));
				__materialChange -= __handler;
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

		protected event PropertyChangeHandler<string> __modelChange;
		public Action OnModelChange(PropertyChangeHandler<string> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.model));
			__modelChange += __handler;
			if (__immediate && this.model != default(string)) { __handler(this.model, default(string)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(model));
				__modelChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<string> __creatorChange;
		public Action OnCreatorChange(PropertyChangeHandler<string> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.creator));
			__creatorChange += __handler;
			if (__immediate && this.creator != default(string)) { __handler(this.creator, default(string)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(creator));
				__creatorChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<string> __editorChange;
		public Action OnEditorChange(PropertyChangeHandler<string> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.editor));
			__editorChange += __handler;
			if (__immediate && this.editor != default(string)) { __handler(this.editor, default(string)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(editor));
				__editorChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(id): __idChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
				case nameof(transform): __transformChange?.Invoke((Transform) change.Value, (Transform) change.PreviousValue); break;
				case nameof(material): __materialChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
				case nameof(color): __colorChange?.Invoke((RGBA) change.Value, (RGBA) change.PreviousValue); break;
				case nameof(model): __modelChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
				case nameof(creator): __creatorChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
				case nameof(editor): __editorChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
