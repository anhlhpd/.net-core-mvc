using System;

namespace Exam_Q2
{
    internal class HttpCookie
    {
        private string v;
        private string lang;

        public HttpCookie(string v, string lang)
        {
            this.v = v;
            this.lang = lang;
        }

        public DateTime Expires { get; internal set; }
    }
}