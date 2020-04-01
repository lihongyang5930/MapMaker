using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MindOne.Core.Services
{
    public class DockManager
    {
        Control _parent;
        DockingManager _dockingManager;

        public DockManager(DockingManager dockingManager, Control parent)
        {
            _dockingManager = dockingManager;
            _parent         = parent;
            _dockingManager.DockControlActivated += (s, e) => DockControlActivated?.Invoke(s, e);
        }

        public event DockActivationChangedEventHandler DockControlActivated;

        public void ShowDocument(Control view, string title, bool closeButtonVisibility = true)
        {
            _dockingManager.SetDockLabel    (view, title);
            _dockingManager.SetDockAbility  (view, DockAbility.All);
            _dockingManager.SetWindowMode   (view, WindowMode.Document);
            _dockingManager.ActivateControl (view);
            _dockingManager.SetEnableDocking(view, true);
            _dockingManager.SetCloseButtonVisibility(view, closeButtonVisibility);
        }

        public bool GetDockVisible(Control view)
        {
            return _dockingManager.GetDockVisibility(view);
        }
        public void SetDockVisible(Control view, bool isVisible)
        {
            _dockingManager.SetDockVisibility(view, isVisible);
        }

        public void InitializeDockLeft(Control view, string title = null, int width = 200)
        {
            InitializeDock(view, DockingStyle.Left, title, width);
        }
        public void InitializeDockRight(Control view, string title = null, int width = 200)
        {
            InitializeDock(view, DockingStyle.Right, title, width);
        }
        public void InitializeDockBottom(Control view, string title = null, int width = 200)
        {
            InitializeDock(view, DockingStyle.Bottom, title, width);
        }
        public void InitializeDock(Control view, DockingStyle dockingStyle, string title = null, int width = 200)
        {
            _dockingManager.SetDockLabel     (view, title ?? view.Text ?? "Dr.Pipe");
            _dockingManager.SetEnableDocking (view, true);
            _dockingManager.SetDockAbility   (view, DockAbility.All);
            _dockingManager.DockControl      (view, _parent, dockingStyle, width);
            _dockingManager.SetDockVisibility(view, false);
        }
    }
}
