﻿using System;
using System.Collections.ObjectModel;

using Epanet.Network.Structures;

namespace Epanet.Network {

    internal class ElementCollection<TItem>:KeyedCollection<string, TItem> where TItem:Element {
        public ElementCollection():base(StringComparer.OrdinalIgnoreCase, 10) { }

        // public new void Add(TItem item) { base.Add(item); }

        public void AddOrReplace(TItem item) {
            string key = GetKeyForItem(item);
            base.Remove(key);
            base.Add(item);
        }

        /*
        public new TItem this[string key] {
            get {

                if (key == null)
                    throw new ArgumentNullException("key");

                if (this.Dictionary != null) {
                    TItem value;
                    return this.Dictionary.TryGetValue(key, out value) 
                        ? value 
                        : default(TItem);
                }

                var comparer = base.Comparer ?? StringComparer.OrdinalIgnoreCase;

                foreach (var item in this.Items)
                    if (comparer.Equals(item.Id, key))
                        return item;

                return default(TItem);
            }
        }
        */

        /*
        public bool TryGetValue(string key, out TItem value) {
            if(key == null)
                throw new ArgumentNullException("key");

            if(base.Dictionary != null)
                return base.Dictionary.TryGetValue(key, out value);

            var comparer = this.Comparer ?? StringComparer.OrdinalIgnoreCase;

            foreach(var item in this.Items) {
                string itemKey = this.GetKeyForItem(item);

                if(comparer.Equals(itemKey, key)) {
                    value = item;
                    return true;
                }
            }

            value = default(TItem);
            return false;
        }
        */

        public TItem GetValueOrDefault(string key) {
            if (key == null)
                throw new ArgumentNullException("key");

            if (Dictionary != null) {
                TItem value;
                return Dictionary.TryGetValue(key, out value) ? value : default(TItem);
            }

            var comparer = Comparer ?? StringComparer.OrdinalIgnoreCase;

            foreach (var item in Items) {
                string itemKey = GetKeyForItem(item);

                if (comparer.Equals(itemKey, key))
                    return item;
            }

            return default(TItem);
        }


        protected override string GetKeyForItem(TItem item) { return item.Name; }
    }

}