using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSotre.Common
{
    public interface ICatalog
    {
    
        /// <summary>
        /// Adds a <see cref="IContent.cs"/> item to the catalog.
        /// </summary>
        /// <param name="content">Takes a falid item that implements the <see cref="IContent.cs"/>.</param>
        void Add(IContent content);

        /// <summary>
        /// Matches a speciffed numbers of items, by title, from the list and returns them as a <see cref="IEnumerable"/>  collection.
        /// </summary>
        /// <param name="title">Takes a title to match by.</param>
        /// <param name="numberOfContentElementsToList">Takes a seciffied amount to return.</param>
        /// <returns>Returns them as a <see cref="IEnumerable"/>  collection with the matched itmes.</returns>
        IEnumerable<IContent> GetListContent(string title, Int32 numberOfContentElementsToList);

        /// <summary>
        /// Updates all the items with a speciffed url to a new url.
        /// </summary>
        /// <param name="oldUrl">Takes the url to search for.</param>
        /// <param name="newUrl">Takes the url witch will repalce the old url.</param>
        /// <returns>Returns the numbers of modiffied items.</returns>
        Int32 UpdateContent(string oldUrl, string newUrl);
    }
}
