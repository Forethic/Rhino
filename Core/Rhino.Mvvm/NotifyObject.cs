using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Rhino.Mvvm
{
    /// <summary>
    /// 实现了 <see cref="INotifyPropertyChanged"/> 的通知类
    /// </summary>
    public class NotifyObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 仅当field与value不相等时更新属性值，并且通知属性值发生变化
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="field">属性的对应字段</param>
        /// <param name="value">属性的新值</param>
        /// <param name="updateBeforeAction">更新之前的操作</param>
        /// <param name="updateAfterAction">更新之后的操作</param>
        /// <param name="propertyName">通知变化的属性名称</param>
        protected void Update<T>(ref T field, T value, Action<T, T> updateBeforeAction = null, Action<T, T> updateAfterAction = null, [CallerMemberName] string propertyName = null)
        {
            updateBeforeAction?.Invoke(field, value);
            if (!Equals(field, value))
            {
                field = value;
            }
            updateAfterAction?.Invoke(field, value);
            RaisePropertyChanged(propertyName);
        }

        /// <summary>
        /// 强制更新属性值，并且通知属性值发生变化
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="field">属性的对应字段</param>
        /// <param name="value">属性的新值</param>
        /// <param name="updateBeforeAction">更新之前的操作</param>
        /// <param name="updateAfterAction">更新之后的操作</param>
        /// <param name="propertyName">通知变化的属性名称</param>
        protected void Coerce<T>(ref T field, T value, Action<T, T> updateBeforeAction = null, Action<T, T> updateAfterAction = null, [CallerMemberName] string propertyName = null)
        {
            updateBeforeAction?.Invoke(field, value);
            field = value;
            updateAfterAction?.Invoke(field, value);
            RaisePropertyChanged(propertyName);
        }

        /// <summary>
        /// 通知属性值发生变化
        /// </summary>
        /// <param name="propertyName">通知变化的属性名称</param>
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}