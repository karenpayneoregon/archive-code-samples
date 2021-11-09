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
        /// <param name="source">CheckedListBox</param>
        /// <returns>List of items checked</returns>
        public static List<string> CheckedList(this CheckedListBox source)
            => source.Items.Cast<string>()
                .Where((item, index) => source.GetItemChecked(index)).Select(item => item)
                .ToList();

        /// <summary>
        /// Get all unchecked items
        /// </summary>
        /// <param name="source">CheckedListBox</param>
        /// <returns>List of items not checked</returns>
        public static List<string> NotCheckedList(this CheckedListBox source)
            => source.Items.Cast<string>()
                .Where((item, index) => !source.GetItemChecked(index)).Select(item => item)
                .ToList();

        /// <summary>
        /// Add new item, set checked to true, select as current item
        /// </summary>
        /// <param name="source">CheckedListBox</param>
        /// <param name="item">Item to check</param>
        public static void AddAsChecked(this CheckedListBox source, string item)
        {
            source.Items.Add(item);
            source.SelectedIndex = source.Items.Count - 1;
            source.SetItemChecked(source.Items.Count - 1, true);
        }

        /// <summary>
        /// Remove current item which represents a <see cref="BackupItem"/>
        /// </summary>
        /// <param name="source">CheckedListBox</param>
        /// <param name="index">SelectedIndex</param>
        public static void RemoveBackItem(this CheckedListBox source, int index)
        {
            source.Items.RemoveAt(index);
            source.SelectedIndex = index == 0 && source.Items.Count > 0 ? 0 : index - 1;
        }
    }
}
