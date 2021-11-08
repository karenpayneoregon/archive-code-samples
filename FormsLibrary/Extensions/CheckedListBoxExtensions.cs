using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FormsLibrary.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="CheckedListBox"/>
    /// </summary>
    public static class CheckedListBoxExtensions
    {
        /// <summary>
        /// Get all checked items
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<string> CheckedList(this CheckedListBox source)
            => source.Items.Cast<string>()
                .Where((item, index) => source.GetItemChecked(index)).Select(item => item)
                .ToList();

        /// <summary>
        /// Get all unchecked items
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<string> NotCheckedList(this CheckedListBox source)
            => source.Items.Cast<string>()
                .Where((item, index) => !source.GetItemChecked(index)).Select(item => item)
                .ToList();

        /// <summary>
        /// Add new item, set checked to true, select as current item
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        public static void AddAsChecked(this CheckedListBox source, string item)
        {
            source.Items.Add(item);
            source.SelectedIndex = source.Items.Count - 1;
            source.SetItemChecked(source.Items.Count - 1, true);
        }
    }
}
