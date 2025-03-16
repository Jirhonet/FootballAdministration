using FootballAdministration.Models.Sidebar;
using System;
using System.Collections.ObjectModel;

namespace FootballAdministration.Utils.Sidebar
{
    public class SidebarBuilder
    {
        private ObservableCollection<SidebarCategory> _children;
        
        public SidebarBuilder()
        {
            _children = new ObservableCollection<SidebarCategory>();
        }

        /// <summary>
        /// Creates a new sidebar
        /// </summary>
        /// <returns></returns>
        public static SidebarBuilder CreateSidebar()
        {
            return new SidebarBuilder();
        }

        /// <summary>
        /// Adds a sidebar item/category
        /// </summary>
        /// <param name="name"></param>
        /// <param name="iconGlyph"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public SidebarBuilder AddItem(string name, string iconGlyph, Type page = null)
        {
            _children.Add(new SidebarCategory(name, iconGlyph, page));
            return this;
        }

        /// <summary>
        /// Adds a sidebar item/category
        /// </summary>
        /// <param name="name"></param>
        /// <param name="iconGlyph"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public SidebarBuilder AddItem(string name, string iconGlyph, Action<SidebarCategory> children = null)
        {
            SidebarCategory category = new SidebarCategory(name, iconGlyph);
            _children.Add(category);
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
        public SidebarBuilder AddItem(string name, string iconGlyph, Type page = null, Action<SidebarCategory> children = null)
        {
            SidebarCategory category = new SidebarCategory(name, iconGlyph, page);
            _children.Add(category);
            children?.Invoke(category);
            return this;
        }

        public ObservableCollection<SidebarCategory> Build()
        {
            return _children;
        }
    }
}
