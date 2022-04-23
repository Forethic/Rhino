using System;
using System.Windows.Input;

namespace Rhino.Mvvm
{
    /// <summary>
    /// 实现了 ICommand 的响应命令类
    /// </summary>
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<object> _action;
        private readonly Predicate<object> _predicate = (obj) => true;

        public RelayCommand(Action<object> action, Predicate<object> predicate = null)
        {
            _action = action;
            if (predicate != null)
            {
                _predicate = predicate;
            }
        }

        public bool CanExecute(object parameter) => _predicate(parameter);

        public void Execute(object parameter) => _action(parameter);
    }
}