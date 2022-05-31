using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TeaFramework.API;
using Terraria.ModLoader;

namespace Terramon.Common.Systems.Loading
{
    public class ContentManifestCollection<TContent, TManifest> : IList<TManifest>
        where TContent : ModType
        where TManifest : IContentManifest
    {
        public delegate TContent ManifestContent(ITeaMod teaMod, TManifest manifest);

        protected readonly ManifestContent ContentManifest;

        protected readonly List<TManifest> ContentManifests = new();

        public ContentManifestCollection(ManifestContent contentManifest) {
            ContentManifest = contentManifest;
        }

        public IEnumerable<TContent> GetContent(ITeaMod teaMod) {
            return ContentManifests.Select(manifest => ContentManifest(teaMod, manifest));
        }

        public void AddAllContent(ITeaMod teaMod) {
            foreach (TContent content in GetContent(teaMod)) teaMod.ModInstance.AddContent(content);
        }

        #region ICollection Impl

        public IEnumerator<TManifest> GetEnumerator() {
            return ContentManifests.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public void Add(TManifest item) {
            ContentManifests.Add(item);
        }

        public void Clear() {
            ContentManifests.Clear();
        }

        public bool Contains(TManifest item) {
            return ContentManifests.Contains(item);
        }

        public void CopyTo(TManifest[] array, int arrayIndex) {
            ContentManifests.CopyTo(array, arrayIndex);
        }

        public bool Remove(TManifest item) {
            return ContentManifests.Remove(item);
        }

        public int Count => ContentManifests.Count;
        public bool IsReadOnly => false;

        #endregion

        #region IList Impl

        public int IndexOf(TManifest item) {
            return ContentManifests.IndexOf(item);
        }

        public void Insert(int index, TManifest item) {
            ContentManifests.Insert(index, item);
        }

        public void RemoveAt(int index) {
            ContentManifests.RemoveAt(index);
        }

        public TManifest this[int index] {
            get => ContentManifests[index];
            set => ContentManifests[index] = value;
        }

        #endregion
    }
}