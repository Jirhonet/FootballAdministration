using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;

namespace FootballAdministration.Models.Sidebar
{
    public class SidebarCategory
    {
        public SidebarCategory(string name, string iconGlyph, Type page = null)
        {
            Name = name;
            IconGlyph = iconGlyph;
            Page = page;
            Children = new ObservableCollection<SidebarCategory>();
        }

        #region Properties
        /// <summary>
        /// The name of the sidebar node
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The icon glyph displayed in the sidebar node
        /// </summary>
        public string IconGlyph
        {
            get;
            set;
        }

        /// <summary>
        /// The page the sidebar item links to
        /// </summary>
        public Type Page
        {
            get;
            set;
        }

        /// <summary>
        /// The children nodes of this node
        /// </summary>
        public ObservableCollection<SidebarCategory> Children
        {
            get;
            set;
        }

        /// <summary>
        /// The icon displayed in the sidebar node
        /// </summary>
        public FontIcon Icon
            => new FontIcon() { Glyph = IconGlyph };
        #endregion

        /// <summary>
        /// Adds a sidebar item/category
        /// </summary>
        /// <param name="name"></param>
        /// <param name="iconGlyph"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public SidebarCategory AddItem(string name, string iconGlyph, Type page = null)
        {
            Children.Add(new SidebarCategory(name, iconGlyph, page));
            return this;
        }

        /// <summary>
        /// Adds a sidebar item/category
        /// </summary>
        /// <param name="name"></param>
        /// <param name="iconGlyph"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public SidebarCategory AddItem(string name, string iconGlyph, Action<SidebarCategory> children = null)
        {
            SidebarCategory category = new SidebarCategory(name, iconGlyph);
            Children.Add(category);
            children?.Invoke(category);
            return this;
        }

        /// <summary>
        /// Adds a sidebar item/category
        /// </summary>
        /// <param name="name"></param>
        /// <param name="iconGlyph"></param>
        /// <param name="page"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public SidebarCategory AddItem(string name, string iconGlyph, Type page = null, Action<SidebarCategory> children = null)
        {
            SidebarCategory category = new SidebarCategory(name, iconGlyph, page);
            Children.Add(category);
            children?.Invoke(category);
            return this;
        }
    }
}
