namespace StrumskaSlava.Web.Infrastructure
{
    public static class DefaultPictures
    {
        public const string NewsUrl = "/Images/defaults/news.svg";

        public const string ProductUrl = "/Images/defaults/product.svg";

        public const string PlayerUrl = "/Images/defaults/player.svg";

        public static string News(string pictureUrl) => OrDefault(pictureUrl, NewsUrl);

        public static string Product(string pictureUrl) => OrDefault(pictureUrl, ProductUrl);

        public static string Player(string pictureUrl) => OrDefault(pictureUrl, PlayerUrl);

        // Value for an img onerror attribute: swaps in the default when the picture cannot be loaded
        // (e.g. it was deleted from Cloudinary). Clearing onerror prevents a loop if the default fails too.
        public static string OnError(string defaultUrl) => $"this.onerror=null;this.src='{defaultUrl}';";

        // Same as OnError, and also replaces the text of the element with the given id
        public static string OnError(string defaultUrl, string noteElementId, string noteText) =>
            OnError(defaultUrl) + $"document.getElementById('{noteElementId}').textContent='{noteText}';";

        private static string OrDefault(string pictureUrl, string defaultUrl) =>
            string.IsNullOrWhiteSpace(pictureUrl) ? defaultUrl : pictureUrl;
    }
}
