// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.20
// 

using Colyseus.Schema;
using Action = System.Action;

namespace MiraboSync.Colyseus {
	public partial class SyncRoomState : Schema {
		[Type(0, "map", typeof(MapSchema<Player>))]
		public MapSchema<Player> players = new MapSchema<Player>();

		[Type(1, "map", typeof(MapSchema<Obj>))]
		public MapSchema<Obj> objects = new MapSchema<Obj>();

		[Type(2, "map", typeof(MapSchema<Image>))]
		public MapSchema<Image> images = new MapSchema<Image>();

		[Type(3, "map", typeof(MapSchema<Video>))]
		public MapSchema<Video> videos = new MapSchema<Video>();

		[Type(4, "map", typeof(MapSchema<DrawLine>))]
		public MapSchema<DrawLine> drawLines = new MapSchema<DrawLine>();

		/*
		 * Support for individual property change callbacks below...
		 */

		protected event PropertyChangeHandler<MapSchema<Player>> __playersChange;
		public Action OnPlayersChange(PropertyChangeHandler<MapSchema<Player>> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.players));
			__playersChange += __handler;
			if (__immediate && this.players != null) { __handler(this.players, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(players));
				__playersChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<MapSchema<Obj>> __objectsChange;
		public Action OnObjectsChange(PropertyChangeHandler<MapSchema<Obj>> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.objects));
			__objectsChange += __handler;
			if (__immediate && this.objects != null) { __handler(this.objects, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(objects));
				__objectsChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<MapSchema<Image>> __imagesChange;
		public Action OnImagesChange(PropertyChangeHandler<MapSchema<Image>> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.images));
			__imagesChange += __handler;
			if (__immediate && this.images != null) { __handler(this.images, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(images));
				__imagesChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<MapSchema<Video>> __videosChange;
		public Action OnVideosChange(PropertyChangeHandler<MapSchema<Video>> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.videos));
			__videosChange += __handler;
			if (__immediate && this.videos != null) { __handler(this.videos, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(videos));
				__videosChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<MapSchema<DrawLine>> __drawLinesChange;
		public Action OnDrawLinesChange(PropertyChangeHandler<MapSchema<DrawLine>> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.drawLines));
			__drawLinesChange += __handler;
			if (__immediate && this.drawLines != null) { __handler(this.drawLines, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(drawLines));
				__drawLinesChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(players): __playersChange?.Invoke((MapSchema<Player>) change.Value, (MapSchema<Player>) change.PreviousValue); break;
				case nameof(objects): __objectsChange?.Invoke((MapSchema<Obj>) change.Value, (MapSchema<Obj>) change.PreviousValue); break;
				case nameof(images): __imagesChange?.Invoke((MapSchema<Image>) change.Value, (MapSchema<Image>) change.PreviousValue); break;
				case nameof(videos): __videosChange?.Invoke((MapSchema<Video>) change.Value, (MapSchema<Video>) change.PreviousValue); break;
				case nameof(drawLines): __drawLinesChange?.Invoke((MapSchema<DrawLine>) change.Value, (MapSchema<DrawLine>) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
