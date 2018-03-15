using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace KuaiDiHelper.HttpHelper
{
    public class HttpItem
    {
        private string _Accept = "text/html, application/xhtml+xml, */*";
        private string _CerPath = string.Empty;
        private X509CertificateCollection _ClentCertificates;
        private string _ContentType = "text/html";
        private string _Cookie = string.Empty;
        private System.Text.Encoding _Encoding = null;
        private bool _expect100continue = true;
        private System.Net.ICredentials _ICredentials = CredentialCache.DefaultCredentials;
        private DateTime? _IfModifiedSince = null;
        private bool _KeepAlive = true;
        private string _Method = "GET";
        private string _Postdata = string.Empty;
        private byte[] _PostdataByte = null;
        private PostDataType _PostDataType = PostDataType.String;
        private System.Text.Encoding _PostEncoding;
        private Version _ProtocolVersion;
        private int _ReadWriteTimeout = 0x7530;
        private string _Referer = string.Empty;
        private ResultCookieType _ResultCookieType = ResultCookieType.String;
        private int _Timeout = 0x186a0;
        private string _URL = string.Empty;
        private string _UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
        private System.Net.WebProxy _WebProxy;
        private bool allowautoredirect = false;
        private int connectionlimit = 0x400;
        private System.Net.CookieCollection cookiecollection = null;
        private WebHeaderCollection header = new WebHeaderCollection();
        private bool isToLower = false;
        private string proxyip = string.Empty;
        private string proxypwd = string.Empty;
        private string proxyusername = string.Empty;
        private ResultType resulttype = ResultType.String;

        public string Accept
        {
            get
            {
                return this._Accept;
            }
            set
            {
                this._Accept = value;
            }
        }

        public bool Allowautoredirect
        {
            get
            {
                return this.allowautoredirect;
            }
            set
            {
                this.allowautoredirect = value;
            }
        }

        public string CerPath
        {
            get
            {
                return this._CerPath;
            }
            set
            {
                this._CerPath = value;
            }
        }

        public X509CertificateCollection ClentCertificates
        {
            get
            {
                return this._ClentCertificates;
            }
            set
            {
                this._ClentCertificates = value;
            }
        }

        public int Connectionlimit
        {
            get
            {
                return this.connectionlimit;
            }
            set
            {
                this.connectionlimit = value;
            }
        }

        public string ContentType
        {
            get
            {
                return this._ContentType;
            }
            set
            {
                this._ContentType = value;
            }
        }

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
                return this.cookiecollection;
            }
            set
            {
                this.cookiecollection = value;
            }
        }

        public System.Text.Encoding Encoding
        {
            get
            {
                return this._Encoding;
            }
            set
            {
                this._Encoding = value;
            }
        }

        public bool Expect100Continue
        {
            get
            {
                return this._expect100continue;
            }
            set
            {
                this._expect100continue = value;
            }
        }

        public WebHeaderCollection Header
        {
            get
            {
                return this.header;
            }
            set
            {
                this.header = value;
            }
        }

        public System.Net.ICredentials ICredentials
        {
            get
            {
                return this._ICredentials;
            }
            set
            {
                this._ICredentials = value;
            }
        }

        public DateTime? IfModifiedSince
        {
            get
            {
                return this._IfModifiedSince;
            }
            set
            {
                this._IfModifiedSince = value;
            }
        }

        public bool IsToLower
        {
            get
            {
                return this.isToLower;
            }
            set
            {
                this.isToLower = value;
            }
        }

        public bool KeepAlive
        {
            get
            {
                return this._KeepAlive;
            }
            set
            {
                this._KeepAlive = value;
            }
        }

        public int MaximumAutomaticRedirections { get; set; }

        public string Method
        {
            get
            {
                return this._Method;
            }
            set
            {
                this._Method = value;
            }
        }

        public string Postdata
        {
            get
            {
                return this._Postdata;
            }
            set
            {
                this._Postdata = value;
            }
        }

        public byte[] PostdataByte
        {
            get
            {
                return this._PostdataByte;
            }
            set
            {
                this._PostdataByte = value;
            }
        }

        public PostDataType PostDataType
        {
            get
            {
                return this._PostDataType;
            }
            set
            {
                this._PostDataType = value;
            }
        }

        public System.Text.Encoding PostEncoding
        {
            get
            {
                return this._PostEncoding;
            }
            set
            {
                this._PostEncoding = value;
            }
        }

        public Version ProtocolVersion
        {
            get
            {
                return this._ProtocolVersion;
            }
            set
            {
                this._ProtocolVersion = value;
            }
        }

        public string ProxyIp
        {
            get
            {
                return this.proxyip;
            }
            set
            {
                this.proxyip = value;
            }
        }

        public string ProxyPwd
        {
            get
            {
                return this.proxypwd;
            }
            set
            {
                this.proxypwd = value;
            }
        }

        public string ProxyUserName
        {
            get
            {
                return this.proxyusername;
            }
            set
            {
                this.proxyusername = value;
            }
        }

        public int ReadWriteTimeout
        {
            get
            {
                return this._ReadWriteTimeout;
            }
            set
            {
                this._ReadWriteTimeout = value;
            }
        }

        public string Referer
        {
            get
            {
                return this._Referer;
            }
            set
            {
                this._Referer = value;
            }
        }

        public ResultCookieType ResultCookieType
        {
            get
            {
                return this._ResultCookieType;
            }
            set
            {
                this._ResultCookieType = value;
            }
        }

        public ResultType ResultType
        {
            get
            {
                return this.resulttype;
            }
            set
            {
                this.resulttype = value;
            }
        }

        public int Timeout
        {
            get
            {
                return this._Timeout;
            }
            set
            {
                this._Timeout = value;
            }
        }

        public string URL
        {
            get
            {
                return this._URL;
            }
            set
            {
                this._URL = value;
            }
        }

        public string UserAgent
        {
            get
            {
                return this._UserAgent;
            }
            set
            {
                this._UserAgent = value;
            }
        }

        public System.Net.WebProxy WebProxy
        {
            get
            {
                return this._WebProxy;
            }
            set
            {
                this._WebProxy = value;
            }
        }
    }
}

