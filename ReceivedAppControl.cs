using System;

namespace Tizen.Applications
{
    public class ReceivedAppControl
    {
        public string ApplicationId
        {
            get
            {
                return String.Empty;
            }
        }
        public string CallerApplicationId
        {
            get
            {
                return String.Empty;
            }
        }
        public bool IsReplyRequest
        {
            get
            {
                bool value = false;
                return value;
            }
        }
    }
}
