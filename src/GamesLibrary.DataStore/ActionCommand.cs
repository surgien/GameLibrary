using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace GamesLibrary.DataStore.Model
{
    public class Item : ObservableObject
    {
        private object _value;

        public object Value
        {
            get { return _value; }
            set { SetProperty(ref value, value); }
        }

        public object Tooltip { get; set; }
        private bool _isEnabled = true;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }
    }

    /// <summary>
    /// Command-Implementation of ICommand
    /// </summary>
    public class ActionCommand : Item, ICommand
    {
        private Action _action;

        // action:
        // Delegate, das bei Command.Execute() ausgeführt werden soll
        public ActionCommand(Action action, bool isEnabled = true)
        {
            _action = action;
            IsEnabled = isEnabled;
        }

        public ActionCommand(Action action, string icon, string name, bool isEnabled = true) : this(action, isEnabled)
        {
            Icon = icon;
            Title = name;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IsEnabled))
            {
                if (CanExecuteChanged != null)
                    CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (_action != null)
                _action();
        }

        private string _icon;

        public string Icon
        {
            get { return _icon; }
            set { SetProperty(ref _icon, value); }
        }

        private string _name;

        public string Title
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

    }

}