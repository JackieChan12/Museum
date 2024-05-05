// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.20
// 

using Colyseus.Schema;
using Action = System.Action;

namespace MiraboSync.Colyseus {
	public partial class DrawLine : Schema {
		[Type(0, "ref", typeof(RGBA))]
		public RGBA color = new RGBA();

		[Type(1, "float32")]
		public float size = default(float);

		[Type(2, "array", typeof(ArraySchema<Vector3>))]
		public ArraySchema<Vector3> points = new ArraySchema<Vector3>();

		[Type(3, "string")]
		public string style = default(string);

		[Type(4, "string")]
		public string creator = default(string);

		/*
		 * Support for individual property change callbacks below...
		 */

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

		protected event PropertyChangeHandler<float> __sizeChange;
		public Action OnSizeChange(PropertyChangeHandler<float> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.size));
			__sizeChange += __handler;
			if (__immediate && this.size != default(float)) { __handler(this.size, default(float)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(size));
				__sizeChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<ArraySchema<Vector3>> __pointsChange;
		public Action OnPointsChange(PropertyChangeHandler<ArraySchema<Vector3>> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.points));
			__pointsChange += __handler;
			if (__immediate && this.points != null) { __handler(this.points, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(points));
				__pointsChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<string> __styleChange;
		public Action OnStyleChange(PropertyChangeHandler<string> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.style));
			__styleChange += __handler;
			if (__immediate && this.style != default(string)) { __handler(this.style, default(string)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(style));
				__styleChange -= __handler;
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

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(color): __colorChange?.Invoke((RGBA) change.Value, (RGBA) change.PreviousValue); break;
				case nameof(size): __sizeChange?.Invoke((float) change.Value, (float) change.PreviousValue); break;
				case nameof(points): __pointsChange?.Invoke((ArraySchema<Vector3>) change.Value, (ArraySchema<Vector3>) change.PreviousValue); break;
				case nameof(style): __styleChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
				case nameof(creator): __creatorChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
