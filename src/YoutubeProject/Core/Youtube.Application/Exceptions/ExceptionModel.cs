using Newtonsoft.Json;

namespace Youtube.Application.Exceptions;

public class ExceptionModel : ErrorStatusCode
{
    public IEnumerable<string> Errors { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this,formatting: Formatting.Indented);
    }
}
public class  ErrorStatusCode
{
    public int StatusCode { get; set;}
}
