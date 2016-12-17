namespace Covalition.Igorary.Mvc.Extensions
{
    public static class MessageTypeExtensions
    {
        public static string AsStyle(this MessageType messageType) {
            switch (messageType) {
                case MessageType.Success: return "alert-success";
                case MessageType.Information: return "alert-info";
                case MessageType.Error: return "alert-danger";
                case MessageType.Warning: return "alert-warning";
            }
            return null;
        }

        public static string AsHeader(this MessageType messageType) {
            switch (messageType) {
                case MessageType.Success: return "Sukces";
                case MessageType.Information: return "Info";
                case MessageType.Error: return "Błąd";
                case MessageType.Warning: return "Ostrzeżenie";
            }
            return null;
        }
    }
}