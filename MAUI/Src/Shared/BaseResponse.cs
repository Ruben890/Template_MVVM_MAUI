using Shared.Enums;

namespace Shared
{
    public class BaseResponse
    {
        public const char ERROR = 'E';

        private ResponseType _responseType;

        public ResponseType ResponseType
        {
            get
            {
                return (Type == ERROR) ? ResponseType.SAP_Error : _responseType;
            }
            set
            {
                _responseType = value;
            }
        }

        public char? Type { get; set; }

        public string? Description { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? ModifiedTime { get; set; }
    }
}
