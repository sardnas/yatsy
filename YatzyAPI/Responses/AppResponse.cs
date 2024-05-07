namespace YatzyAPI.Responses;

public class AppResponse<TResponseItem>
{
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
    public DateTime? ExpireDate { get; set; }
    public IEnumerable<string>? Errors { get; set; }
    public TResponseItem? ResponseItem { get; set; }
}