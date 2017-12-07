namespace Sacristan.Utils.Messaging
{
    public delegate void MessengerCallback();
    public delegate void MessengerCallback<T>(T arg1);
    public delegate void MessengerCallback<T, U>(T arg1, U arg2);
    public delegate void MessengerCallback<T, U, V>(T arg1, U arg2, V arg3);
}
