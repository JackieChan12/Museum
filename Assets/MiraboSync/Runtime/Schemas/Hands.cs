// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.20
// 

using Colyseus.Schema;
using Action = System.Action;

namespace MiraboSync.Colyseus {
	public partial class Hands : Schema {
		[Type(0, "ref", typeof(Hand))]
		public Hand left = new Hand();

		[Type(1, "ref", typeof(Hand))]
		public Hand right = new Hand();

		/*
		 * Support for individual property change callbacks below...
		 */

		protected event PropertyChangeHandler<Hand> __leftChange;
		public Action OnLeftChange(PropertyChangeHandler<Hand> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.left));
			__leftChange += __handler;
			if (__immediate && this.left != null) { __handler(this.left, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(left));
				__leftChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<Hand> __rightChange;
		public Action OnRightChange(PropertyChangeHandler<Hand> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.right));
			__rightChange += __handler;
			if (__immediate && this.right != null) { __handler(this.right, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(right));
				__rightChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(left): __leftChange?.Invoke((Hand) change.Value, (Hand) change.PreviousValue); break;
				case nameof(right): __rightChange?.Invoke((Hand) change.Value, (Hand) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
