using System.Net;

namespace KuaiDiHelper.HttpHelper
{
    public class HttpResult
    {
        private string _Cookie;
        private System.Net.CookieCollection _CookieCollection;
        private WebHeaderCollection _Header;
        private string _Html;
        private byte[] _ResultByte;
        private HttpStatusCode _StatusCode;
        private string _StatusDescription;

        public string Cookie
        {
            get
            {
                return this._Cookie;
            }
            set
            {
                this._Cookie = value;
            }
        }

        public System.Net.CookieCollection CookieCollection
        {
            get
            {
                return this._CookieCollection;
            }
            set
            {
                this._CookieCollection = value;
            }
        }

        public WebHeaderCollection Header
        {
            get
            {
                return this._Header;
            }
            set
            {
                this._Header = value;
            }
        }

        public string Html
        {
            get
            {
                return this._Html;
            }
            set
            {
                this._Html = value;
            }
        }

        public byte[] ResultByte
        {
            get
            {
                return this._ResultByte;
            }
            set
            {
                this._ResultByte = value;
            }
        }

        public HttpStatusCode StatusCode
        {
            get
            {
                return this._StatusCode;
            }
            set
            {
                this._StatusCode = value;
            }
        }

        public string StatusDescription
        {
            get
            {
                return this._StatusDescription;
            }
            set
            {
                this._StatusDescription = value;
            }
        }
    }
}

