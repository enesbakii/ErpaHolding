using System.Text.Json.Serialization;

namespace ErpaHolding.Business.Responce
{
    public class CustomResponseDto<T>
    {
        public T? Data { get; set; }
        public List<CustomValidationError>? CustomValidationErrors { get; set; }

        public List<string>? Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }


        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T>()
            {
                Data = data,
                StatusCode = statusCode,
            };
        }
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T>()
            {
                StatusCode = statusCode,
            };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<CustomValidationError> errors)
        {
            
            return new CustomResponseDto<T>()
            {
                StatusCode = statusCode,
                Errors = errors.Select(e => e.ErrorMessage).ToList()
            };
        }


        public static CustomResponseDto<T> Fail(int statusCode, string error, T data)
        {

            return new CustomResponseDto<T>()
            {
                StatusCode = statusCode,
                Errors = new List<string> { error },
                Data = data
               
            };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string errors)
        {
            return new CustomResponseDto<T>()
            {
                StatusCode = statusCode,
                Errors = new List<string> { errors }
            };
        }

    }
}
