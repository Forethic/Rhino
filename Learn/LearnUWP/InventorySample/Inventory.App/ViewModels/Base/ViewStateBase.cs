namespace Inventory.ViewModels
{
    public class ViewStateBase
    {
        public ViewStateBase Clone() => MemberwiseClone() as ViewStateBase;
    }
}